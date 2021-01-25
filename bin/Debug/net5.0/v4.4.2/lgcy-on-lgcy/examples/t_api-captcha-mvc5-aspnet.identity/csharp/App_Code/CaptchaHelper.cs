using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using BotDetect.Web.Mvc;

namespace Mvc50CaptchaExampleCSharp.App_Code
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
            registrationCaptcha.ImageSize = new System.Drawing.Size(255, 50);

            return registrationCaptcha;
        }

        public static MvcCaptcha GetLoginCaptcha()
        {
            // create the control instance
            MvcCaptcha registrationCaptcha = new MvcCaptcha("LoginCaptcha");

            // set up client-side processing of the Captcha code input textbox
            registrationCaptcha.UserInputID = "CaptchaCode";

            // Captcha settings
            registrationCaptcha.ImageSize = new System.Drawing.Size(255, 50);

            return registrationCaptcha;
        }

        public static MvcCaptcha GetChangePasswordCaptcha()
        {
            // create the control instance
            MvcCaptcha registrationCaptcha = new MvcCaptcha("ChangePasswordCaptcha");

            // set up client-side processing of the Captcha code input textbox
            registrationCaptcha.UserInputID = "CaptchaCode";

            // Captcha settings
            registrationCaptcha.ImageSize = new System.Drawing.Size(255, 50);

            return registrationCaptcha;
        }
    }
}