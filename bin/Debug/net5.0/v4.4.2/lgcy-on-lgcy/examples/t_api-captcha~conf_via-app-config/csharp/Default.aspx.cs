using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CaptchaApplicationConfigSettingsExampleCSharp
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
            }
        }
    }
}