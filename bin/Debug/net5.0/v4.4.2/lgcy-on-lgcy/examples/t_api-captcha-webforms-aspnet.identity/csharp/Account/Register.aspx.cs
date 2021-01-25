using Microsoft.AspNet.Identity;
using System;
using System.Linq;
using System.Web.UI;
using WebForms451CaptchaExampleCSharp.Models;

namespace WebForms451CaptchaExampleCSharp.Account
{
    public partial class Register : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            // setup client-side input processing
            RegisterCaptcha.UserInputID = CaptchaCode.ClientID;
        }

        protected void CreateUser_Click(object sender, EventArgs e)
        {
            if (this.IsValid)
            {
                var manager = new UserManager();
                var user = new ApplicationUser() { UserName = UserName.Text };
                IdentityResult result = manager.Create(user, Password.Text);
                if (result.Succeeded)
                {
                    IdentityHelper.SignIn(manager, user, isPersistent: false);
                    IdentityHelper.RedirectToReturnUrl(Request.QueryString["ReturnUrl"], Response);
                }
                else
                {
                    ErrorMessage.Text = result.Errors.FirstOrDefault();
                }

                //Response.Redirect("~/About");
            }

        }

        protected void CaptchaValidator_ServerValidate(object source, System.Web.UI.WebControls.ServerValidateEventArgs args)
        {
            // validate the Captcha to check we're not dealing with a bot
            args.IsValid = RegisterCaptcha.Validate(args.Value.Trim());

            CaptchaCode.Text = null; // clear previous user input
        }
    }
}