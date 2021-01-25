using BotDetect.Web.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

namespace WebFormsMembershipCaptchaExampleCSharp
{
    public partial class Login : System.Web.UI.Page
    {
        protected void ExampleLogin_Authenticate(object sender, System.Web.UI.WebControls.AuthenticateEventArgs e)
        {
            TextBox CaptchaCodeTextBox = ExampleLogin.FindControl("CaptchaCodeTextBox") as TextBox;
            WebFormsCaptcha LoginCaptcha = ExampleLogin.FindControl("LoginCaptcha") as WebFormsCaptcha;

            // first, validate the Captcha to check we're not dealing with a bot
            if (!IsHuman)
            {
                string code = CaptchaCodeTextBox.Text.Trim();
                IsHuman = LoginCaptcha.Validate(code);
                CaptchaCodeTextBox.Text = null; // clear previous user input

                if (!IsHuman)
                {
                    ExampleLogin.FailureText = "Retype the characters from the image carefully.";
                    e.Authenticated = false;
                    return;
                }
            }

            HideCaptcha(); // hide the CAPTCHA once it's solved

            // only when we're sure the visitor is human, we try to authenticate them
            if (!Membership.ValidateUser(ExampleLogin.UserName, ExampleLogin.Password))
            {
                ExampleLogin.FailureText = "Invalid login info.";
                e.Authenticated = false;

                FailedAuthAttempts++;
                if (ResetFailedAuthAttempts < FailedAuthAttempts)
                {
                    // show the CAPTCHA again if the user enters invalid authentication
                    // info three times in a row
                    ShowCaptcha();
                }

                return;
            }

            e.Authenticated = true;
        }

        protected void HideCaptcha()
        {
            WebFormsCaptcha LoginCaptcha = ExampleLogin.FindControl("LoginCaptcha") as WebFormsCaptcha;
            HtmlControl CaptchaRow = ExampleLogin.FindControl("CaptchaRow") as HtmlControl;

            CaptchaRow.Visible = false;
            LoginCaptcha.Visible = false;
        }

        protected void ShowCaptcha()
        {
            WebFormsCaptcha LoginCaptcha = ExampleLogin.FindControl("LoginCaptcha") as WebFormsCaptcha;
            HtmlControl CaptchaRow = ExampleLogin.FindControl("CaptchaRow") as HtmlControl;

            IsHuman = false;
            FailedAuthAttempts = 0;
            CaptchaRow.Visible = true;
            LoginCaptcha.Visible = true;
        }

        /// <summary>
        /// flag showing the user successfully passed the CAPTCHA test
        /// </summary>
        protected bool IsHuman
        {
            get
            {
                bool isHuman = false;

                try
                {
                    if (null != Session["IsHuman"])
                    {
                        isHuman = (bool)Session["IsHuman"];
                    }
                }
                catch (InvalidCastException) { /* ignore cast errors */ }

                return isHuman;
            }

            set
            {
                Session["IsHuman"] = value;
            }
        }

        protected const int ResetFailedAuthAttempts = 3;

        /// <summary>
        /// Failed authentication attempt counter
        /// </summary>
        protected int FailedAuthAttempts
        {
            get
            {
                int count = 0;

                try
                {
                    if (null != Session["FailedAuthAttempts"])
                    {
                        count = (int)Session["FailedAuthAttempts"];
                    }
                }
                catch (InvalidCastException) { /* ignore cast errors */ }

                return count;
            }

            set
            {
                Session["FailedAuthAttempts"] = value;
            }
        }
    }
}