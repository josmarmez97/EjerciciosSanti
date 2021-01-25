using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CaptchaTroubleshootingExampleCSharp
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_PreRender(object sender, EventArgs e)
        {
            // initial page setup
            if (!IsPostBack)
            {
                // set control text
                ValidateCaptchaButton.Text = "Validate";
                CaptchaCorrectLabel.Text = "Correct!";
                CaptchaIncorrectLabel.Text = "Incorrect!";

                // these messages are shown only after validation
                CaptchaCorrectLabel.Visible = false;
                CaptchaIncorrectLabel.Visible = false;

                CauseErrorButton.Text = "Simulate error";
                ErrorLabel.Text = "An error has been generated. Please check the 'error.txt' file.";

                DebugLabel.Text = "A validation attempt has been logged. Please check the 'debug.txt' file.";
                DebugLabel.Visible = false;
            }

            if (null != Session["error"])
            {
                ErrorLabel.Visible = true;
                CaptchaCorrectLabel.Visible = false;
                CaptchaIncorrectLabel.Visible = false;
                Session["error"] = null;
                DebugLabel.Visible = false;
            }
            else
            {
                ErrorLabel.Visible = false;
            }

            if (IsPostBack)
            {
                // validate the Captcha to check we're not dealing with a bot
                bool isHuman = ExampleCaptcha.Validate();
                if (isHuman)
                {
                    CaptchaCorrectLabel.Visible = true;
                    CaptchaIncorrectLabel.Visible = false;
                }
                else
                {
                    CaptchaCorrectLabel.Visible = false;
                    CaptchaIncorrectLabel.Visible = true;
                }

                DebugLabel.Visible = true;
            }
        }

        protected void CauseErrorButton_Click(object sender, EventArgs e)
        {
            Session["error"] = true;
            throw new BotDetect.WebCaptchaException("Simulated exception");
        }
    }
}