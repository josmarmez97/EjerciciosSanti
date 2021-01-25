using System;
using System.Collections.Generic;
using BotDetect;

namespace CaptchaFormObjectSettingsExampleCSharp
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_PreRender(object sender, EventArgs e)
        {
            // Captcha2 code-behind setup

            Captcha2.CodeLength = 4;
            Captcha2.CodeStyle = CodeStyle.Alpha;
            Captcha2.DisallowedCodeSubstringsList = new List<string> { "AAA", "BBB", "CCC" };
            Captcha2.CodeTimeout = 900; // 15 minutes

            // only re-calcualated on form load
            ImageStyle[] imageStyles =
            {
                ImageStyle.BlackOverlap,
                ImageStyle.Graffiti,
                ImageStyle.Overlap
            };
            Captcha2.ImageStyle = CaptchaRandomization.GetRandomImageStyle(imageStyles);
            Captcha2.ImageSize = new System.Drawing.Size(120, 35);
            Captcha2.ImageFormat = ImageFormat.Png;
            Captcha2.CustomDarkColor = System.Drawing.Color.DarkGreen;
            Captcha2.CustomLightColor = System.Drawing.ColorTranslator.FromHtml("#eeeeff");

            Captcha2.SoundEnabled = true;
            Captcha2.SoundStyle = SoundStyle.Dispatch;
            Captcha2.SoundFormat = SoundFormat.WavPcm8bit8kHzMono;
            Captcha2.SoundRegenerationMode = SoundRegenerationMode.None;

            Captcha2.Locale = "fr-CA";
            Captcha2.ImageTooltip = "Custom Canadian French Captcha image tooltip";
            Captcha2.SoundTooltip = "Custom Canadian French Captcha sound icon tooltip";
            Captcha2.ReloadTooltip = "Custom Canadian French Captcha reload icon tooltip";
            Captcha2.HelpLinkUrl = "custom-canadian-french-captcha-help-page.html";
            Captcha2.HelpLinkText = "Custom Canadian French Captcha help link text";

            Captcha2.ReloadEnabled = true;
            Captcha2.UseSmallIcons = true;
            Captcha2.UseHorizontalIcons = true;
            Captcha2.SoundIconUrl = "";
            Captcha2.ReloadIconUrl = "";
            Captcha2.IconsDivWidth = 50;
            Captcha2.HelpLinkEnabled = true;
            Captcha2.HelpLinkMode = HelpLinkMode.Image;
            Captcha2.TabIndex = 15;
            Captcha2.AdditionalCssClasses = "";
            Captcha2.AdditionalInlineCss = "";

            Captcha2.AddScriptInclude = true;
            Captcha2.AutoUppercaseInput = true;
            Captcha2.AutoFocusInput = true;
            Captcha2.AutoClearInput = true;
            Captcha2.AutoReloadExpiredCaptchas = true;
            Captcha2.AutoReloadTimeout = 3600; // 1 hour
            Captcha2.SoundStartDelay = 1000; // 1 second
            Captcha2.RemoteScriptEnabled = true;


            // Form validation
            if (IsPostBack)
            {
                bool isHuman1 = Captcha1.Validate();
                if (isHuman1)
                {
                    Captcha1CorrectLabel.Visible = true;
                    Captcha1IncorrectLabel.Visible = false;
                }
                else
                {
                    Captcha1CorrectLabel.Visible = false;
                    Captcha1IncorrectLabel.Visible = true;
                }

                bool isHuman2 = Captcha2.Validate();
                if (isHuman2)
                {
                    Captcha2CorrectLabel.Visible = true;
                    Captcha2IncorrectLabel.Visible = false;
                }
                else
                {
                    Captcha2CorrectLabel.Visible = false;
                    Captcha2IncorrectLabel.Visible = true;
                }
            }
        }
    }
}