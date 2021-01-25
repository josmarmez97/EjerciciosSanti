using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace t_api_captcha_webforms_api_basics_msajax
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            // initial page setup
            if (!IsPostBack)
            {
                // set control text
                ValidateCaptchaButton.Text = "Validate";
                CaptchaIncorrectLabel.Text = "Incorrect!";
            }

            // setup client-side input processing
            ExampleCaptcha.UserInputID = CaptchaCodeTextBox.ClientID;
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Panel1.Visible = false;
            Panel2.Visible = true;

            CaptchaIncorrectLabel.Visible = false;

            // ensure the BotDetect client scripts are added to the page
            IncludeBotDetectScripts();
        }

        protected void IncludeBotDetectScripts()
        {
            ScriptManager.RegisterClientScriptInclude(
                this.Page,
                GetType(),
                "BotDetect_Include",
                ExampleCaptcha.WebCaptcha.UrlGenerator.ScriptIncludeUrl(ExampleCaptcha.CaptchaId,
                    ExampleCaptcha.WebCaptcha.CurrentInstanceId));
        }


        protected void ValidateCaptchaButton_Click(object sender, EventArgs e)
        {
            // validate the Captcha to check we're not dealing with a bot
            string code = CaptchaCodeTextBox.Text.Trim();
            bool isHuman = ExampleCaptcha.Validate(code);
            CaptchaCodeTextBox.Text = null; // clear previous user input

            if (isHuman)
            {
                CaptchaIncorrectLabel.Visible = false;

                Panel1.Visible = true;
                Panel2.Visible = false;
            }
            else
            {
                CaptchaIncorrectLabel.Visible = true;
            }
        }
    }
}