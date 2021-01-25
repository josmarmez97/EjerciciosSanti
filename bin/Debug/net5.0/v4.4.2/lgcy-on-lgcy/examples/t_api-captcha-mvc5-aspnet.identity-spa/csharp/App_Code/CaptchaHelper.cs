using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using BotDetect.Web.Mvc;
namespace AspNetMvc523SinglePageApplicationExampleCSharp.App_Code
{
    public static class CaptchaHelper
    {
        public static MvcCaptcha GetExampleCaptcha(string captchaId)
        {
            // create the control instance
            MvcCaptcha exampleCaptcha = new MvcCaptcha(captchaId);

            // set up client-side processing of the Captcha code input textbox
            exampleCaptcha.UserInputID = "CaptchaCode";

            // Captcha settings
            exampleCaptcha.ImageSize = new System.Drawing.Size(255, 50);

            return exampleCaptcha;
        }
    }
}