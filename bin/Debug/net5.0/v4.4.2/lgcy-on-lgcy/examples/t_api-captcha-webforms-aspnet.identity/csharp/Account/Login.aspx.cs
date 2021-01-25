using Microsoft.AspNet.Identity;
using System;
using System.Web;
using System.Web.UI;
using WebForms451CaptchaExampleCSharp.Models;

namespace WebForms451CaptchaExampleCSharp.Account
{
    public partial class Login : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            RegisterHyperLink.NavigateUrl = "Register";
            OpenAuthLogin.ReturnUrl = Request.QueryString["ReturnUrl"];
            var returnUrl = HttpUtility.UrlEncode(Request.QueryString["ReturnUrl"]);
            if (!String.IsNullOrEmpty(returnUrl))
            {
                RegisterHyperLink.NavigateUrl += "?ReturnUrl=" + returnUrl;
            }
            // setup client-side input processing
            LoginCaptcha.UserInputID = CaptchaCode.ClientID;
        }

        protected void LogIn(object sender, EventArgs e)
        {
            if (IsValid)
            {
                // this example is to demonstrate captcha integration, so we will ignore functionality requires database connection
                IdentityHelper.RedirectToReturnUrl(Request.QueryString["ReturnUrl"], Response);
                //Validate the user password
                /*var manager = new UserManager();
                ApplicationUser user = manager.Find(UserName.Text, Password.Text);
                if (user != null)
                {
                    IdentityHelper.SignIn(manager, user, RememberMe.Checked);
                    IdentityHelper.RedirectToReturnUrl(Request.QueryString["ReturnUrl"], Response);
                }
                else
                {
                    FailureText.Text = "Invalid username or password.";
                    ErrorMessage.Visible = true;
                }
                 */
                //Response.Redirect("~/About");
            }
        }

        protected void CaptchaValidator_ServerValidate(object source, System.Web.UI.WebControls.ServerValidateEventArgs args)
        {
            // validate the Captcha to check we're not dealing with a bot
            args.IsValid = LoginCaptcha.Validate(args.Value.Trim());

            CaptchaCode.Text = null; // clear previous user input
        }
    }
}