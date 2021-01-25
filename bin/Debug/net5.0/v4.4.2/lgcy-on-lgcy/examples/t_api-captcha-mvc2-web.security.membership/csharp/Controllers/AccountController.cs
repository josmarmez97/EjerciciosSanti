using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Security.Principal;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using System.Web.Security;
using Mvc20CaptchaExampleCSharp.Models;

using BotDetect.Web.Mvc;

namespace Mvc20CaptchaExampleCSharp.Controllers
{

    [HandleError]
    public class AccountController : Controller
    {

        public IFormsAuthenticationService FormsService { get; set; }
        public IMembershipService MembershipService { get; set; }

        protected override void Initialize(RequestContext requestContext)
        {
            if (FormsService == null) { FormsService = new FormsAuthenticationService(); }
            if (MembershipService == null) { MembershipService = new AccountMembershipService(); }

            base.Initialize(requestContext);
        }

        // **************************************
        // URL: /Account/LogOn
        // **************************************

        public ActionResult LogOn()
        {
            return View();
        }

        [HttpPost]
        [CaptchaValidationActionFilter("CaptchaCode", "LoginCaptcha", "Your input doesn't match displayed characters.")]
        public ActionResult LogOn(LogOnModel model, string returnUrl)
        {
            if (ModelState.IsValid)
            {
                // this example is to demonstrate captcha integration, so we will ignore functionality requires database connection
                FormsService.SignIn(model.UserName, model.RememberMe);
                if (!String.IsNullOrEmpty(returnUrl))
                {
                    return Redirect(returnUrl);
                }
                else
                {
                    return RedirectToAction("Index", "Home");
                }
                //if (MembershipService.ValidateUser(model.UserName, model.Password))
                //{
                //    FormsService.SignIn(model.UserName, model.RememberMe);
                //    if (!String.IsNullOrEmpty(returnUrl))
                //    {
                //        return Redirect(returnUrl);
                //    }
                //    else
                //    {
                //        return RedirectToAction("Index", "Home");
                //    }
                //}
                //else
                //{
                //    ModelState.AddModelError("", "The user name or password provided is incorrect.");
                //}
            }

            // If we got this far, something failed, redisplay form
            return View(model);
        }

        // **************************************
        // URL: /Account/LogOff
        // **************************************

        public ActionResult LogOff()
        {
            FormsService.SignOut();

            return RedirectToAction("Index", "Home");
        }

        // **************************************
        // URL: /Account/Register
        // **************************************

        public ActionResult Register()
        {
            ViewData["PasswordLength"] = MembershipService.MinPasswordLength;

            // when the View is accessed directly and not posted, we clear any
            // remembered CAPTCHA solving state. 
            // The users only have to solve the CAPTCHA once within a single 
            // registration, but if they reload the Register page later,
            // it is shown again. 
            // Otherwise, they could register an unlimited number of accounts 
            // within a single Session after solving the CAPTCHA only once.
            MvcCaptcha.ResetCaptcha("RegistrationCaptcha");

            return View();
        }

        [HttpPost]
        [CaptchaValidationActionFilter("CaptchaCode", "RegistrationCaptcha", "Your input doesn't match displayed characters.")]
        public ActionResult Register(RegisterModel model)
        {
            if (ModelState.IsValid)
            {
                // this example is to demonstrate captcha integration, so we will ignore functionality requires database connection
                FormsService.SignIn(model.UserName, false);
                return RedirectToAction("Index", "Home");
                /* Attempt to register the user
                MembershipCreateStatus createStatus = MembershipService.CreateUser(model.UserName, model.Password, model.Email);

                if (createStatus == MembershipCreateStatus.Success)
                {
                    FormsService.SignIn(model.UserName, false); // createPersistentCookie //
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    ModelState.AddModelError("", AccountValidation.ErrorCodeToString(createStatus));
                }
                */
            }

            // If we got this far, something failed, redisplay form
            ViewData["PasswordLength"] = MembershipService.MinPasswordLength;
            return View(model);
        }

        // **************************************
        // URL: /Account/ChangePassword
        // **************************************

        [Authorize]
        public ActionResult ChangePassword()
        {
            ViewData["PasswordLength"] = MembershipService.MinPasswordLength;
            return View();
        }

        [Authorize]
        [HttpPost]
        public ActionResult ChangePassword(ChangePasswordModel model)
        {
            if (ModelState.IsValid)
            {
                if (MembershipService.ChangePassword(User.Identity.Name, model.OldPassword, model.NewPassword))
                {
                    return RedirectToAction("ChangePasswordSuccess");
                }
                else
                {
                    ModelState.AddModelError("", "The current password is incorrect or the new password is invalid.");
                }
            }

            // If we got this far, something failed, redisplay form
            ViewData["PasswordLength"] = MembershipService.MinPasswordLength;
            return View(model);
        }

        // **************************************
        // URL: /Account/ChangePasswordSuccess
        // **************************************

        public ActionResult ChangePasswordSuccess()
        {
            return View();
        }

    }
}
