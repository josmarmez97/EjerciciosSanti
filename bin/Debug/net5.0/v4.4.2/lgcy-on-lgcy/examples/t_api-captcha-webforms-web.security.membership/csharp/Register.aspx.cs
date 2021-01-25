using BotDetect.Web.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebFormsMembershipCaptchaExampleCSharp
{
    public partial class Register : System.Web.UI.Page
    {
        protected void RegisterUser_NextButtonClick(object sender, WizardNavigationEventArgs e)
        {
            if (e.CurrentStepIndex == 0) // CreateUserStep
            {
                // get control references
                WebFormsCaptcha RegisterCaptcha = RegisterUser.CreateUserStep.ContentTemplateContainer.FindControl("RegisterCaptcha") as WebFormsCaptcha;
                TextBox CaptchaCodeTextBox = RegisterUser.CreateUserStep.ContentTemplateContainer.FindControl("CaptchaCodeTextBox") as TextBox;
                Literal CaptchaIncorrect = RegisterUser.CreateUserStep.ContentTemplateContainer.FindControl("InvalidCaptchaInput") as Literal;

                // validate the Captcha to check we're not dealing with a bot
                string code = CaptchaCodeTextBox.Text.Trim();
                bool isHuman = RegisterCaptcha.Validate(code);
                CaptchaCodeTextBox.Text = null; // clear previous user input

                if (!isHuman)
                {
                    CaptchaIncorrect.Visible = true;
                    e.Cancel = true;
                }
                else
                {
                    CaptchaIncorrect.Visible = false;
                }
            }
        }
    }
}