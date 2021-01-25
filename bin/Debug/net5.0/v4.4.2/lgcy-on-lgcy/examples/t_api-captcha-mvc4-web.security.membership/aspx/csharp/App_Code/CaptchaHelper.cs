using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using BotDetect.Web.Mvc;

namespace Mvc40CaptchaExampleAspxCSharp.App_Code
{
    public static class CaptchaHelper
    {
        public static MvcCaptcha GetRegistrationCaptcha()
        {
            // create the control instance
            MvcCaptcha registrationCaptcha = new MvcCaptcha("RegistrationCaptcha");

            // set up client-side processing of the Captcha code input textbox
            registrationCaptcha.UserInputID = "CaptchaCode";

            // Captcha settings
            registrationCaptcha.ImageSize = new System.Drawing.Size(200, 50);
            registrationCaptcha.CodeLength = 4;

            return registrationCaptcha;
        }

        public static MvcCaptcha GetLoginCaptcha()
        {
            // create the control instance
            MvcCaptcha loginCaptcha = new MvcCaptcha("LoginCaptcha");

            // set up client-side processing of the Captcha code input textbox
            loginCaptcha.UserInputID = "CaptchaCode";

            // Captcha settings
            loginCaptcha.ImageSize = new System.Drawing.Size(200, 50);
            loginCaptcha.CodeLength = 4;

            return loginCaptcha;
        }
    }
}