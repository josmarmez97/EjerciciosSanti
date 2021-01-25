using BotDetect;
using BotDetect.Web;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CaptchaRequestDynamicSettingsExampleCSharp
{
    public partial class Default : System.Web.UI.Page
    {
        void Page_Init(object sender, EventArgs e)
        {
            Captcha.InitializedWebCaptcha += Captcha_InitializedWebCaptcha;
        }

        void Captcha_InitializedWebCaptcha(object sender, BotDetect.InitializedWebCaptchaEventArgs e)
        {
            Captcha captchaInstance = sender as Captcha;

            // Captcha.InitializedWebCaptcha event handlers are global and apply to all Captcha instances 
            // in the application; if some settings need to be apply only to a particular Captcha 
            // instance, this is how settings can be conditionally applied based on CaptchaId
            if (e.CaptchaId == DynamicCaptcha.CaptchaId)
            {
                captchaInstance.SoundEnabled = false;
            }

            // re-calculated on each image request
            ImageStyle[] imageStyles = { ImageStyle.Graffiti, ImageStyle.SunAndWarmAir, ImageStyle.Overlap };
            captchaInstance.ImageStyle = CaptchaRandomization.GetRandomImageStyle(imageStyles);

            // dynamic Captcha settings depending on failed validation attempts: increase Captcha 
            // difficulty according to number of previously failed validations
            int count = ValidationCounter.GetFailedValidationsCount();
            if (count < 3)
            {
                captchaInstance.CodeLength = CaptchaRandomization.GetRandomCodeLength(3, 4);
                captchaInstance.CodeStyle = CodeStyle.Numeric;
                captchaInstance.CodeTimeout = 600; // 10 minutes
            }
            else if (count < 10)
            {
                captchaInstance.CodeLength = CaptchaRandomization.GetRandomCodeLength(4, 6);
                captchaInstance.CodeStyle = CodeStyle.Alpha;
                captchaInstance.CodeTimeout = 180; // 3 minutes
            }
            else
            {
                captchaInstance.CodeLength = CaptchaRandomization.GetRandomCodeLength(6, 9);
                captchaInstance.CodeStyle = CodeStyle.Alphanumeric;
                captchaInstance.CodeTimeout = 60; // 1 minute
            }

            // set Captcha locale to Chinese for requests from a certain IP range
            string ipRange = "223.254.";
            bool requestFromRangeDetected = false;

            // have to use HttpContext.Current.Request and not Page.Request because Page
            // properties won't be set for Captcha image and sound requests serverd directly
            // by the BotDetect Captcha HttpHandler
            if (null != HttpContext.Current.Request &&
                    !String.IsNullOrEmpty(HttpContext.Current.Request.UserHostAddress) &&
                    HttpContext.Current.Request.UserHostAddress.StartsWith(ipRange))
            {
                requestFromRangeDetected = true;
            }

            if (requestFromRangeDetected)
            {
                captchaInstance.CodeStyle = CodeStyle.Alpha;
                captchaInstance.Locale = "cmn";
            }
        }


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
                bool isHuman = DynamicCaptcha.Validate();
                if (isHuman)
                {
                    CaptchaCorrectLabel.Visible = true;
                    CaptchaIncorrectLabel.Visible = false;
                    ValidationCounter.ResetFailedValidationsCount();
                }
                else
                {
                    CaptchaCorrectLabel.Visible = false;
                    CaptchaIncorrectLabel.Visible = true;
                    ValidationCounter.IncrementFailedValidationsCount();
                }
            }

            // update status display
            int count = ValidationCounter.GetFailedValidationsCount();
            StatusLiteral.Text = String.Format("<p>Failed Captcha validations: {0}</p>", count);
            if (count < 3)
            {
                StatusLiteral.Text += "<p>Dynamic Captcha difficulty: Easy</p>";
            }
            else if (count < 10)
            {
                StatusLiteral.Text += "<p>Dynamic Captcha difficulty: Moderate</p>";
            }
            else
            {
                StatusLiteral.Text += "<p>Dynamic Captcha difficulty: Hard</p>";
            }
        }
    }
}