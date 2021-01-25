using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BotDetect.Web.Mvc;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Mvc6BasicCaptchaExample.Utils
{
    public static class CaptchaHelper
    {
        public static MvcCaptcha GetExampleCaptcha(HttpContext httpContext)
        {
            // create the control instance
            MvcCaptcha exampleCaptcha = new MvcCaptcha("RegistrationCaptcha");

            // set up client-side processing of the Captcha code input textbox
            exampleCaptcha.UserInputID = "CaptchaCode";

            // Captcha settings
            exampleCaptcha.ImageSize = new System.Drawing.Size(255, 50);

            return exampleCaptcha;
        }

    }
}
