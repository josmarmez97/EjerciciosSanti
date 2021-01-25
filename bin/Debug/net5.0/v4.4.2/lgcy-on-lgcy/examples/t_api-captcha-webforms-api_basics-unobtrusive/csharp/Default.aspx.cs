using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace t_api_captcha_webforms_api_basics_unobtrusive
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
                CaptchaCorrectLabel.Text = "Successful form submission (server)";
                CaptchaIncorrectLabel.Text = "Failed form submission (server)";

                // these messages are shown only after validation
                CaptchaCorrectLabel.Visible = false;
                CaptchaIncorrectLabel.Visible = false;
            }

            // setup client-side input processing
            ExampleCaptcha.UserInputID = CaptchaCodeTextBox.ClientID;

            if (IsPostBack)
            {
                // validate the Captcha to check we're not dealing with a bot
                string code = CaptchaCodeTextBox.Text.Trim();
                bool isHuman = ExampleCaptcha.Validate(code);
                CaptchaCodeTextBox.Text = null; // clear previous user input

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
            }
        }
    }
}