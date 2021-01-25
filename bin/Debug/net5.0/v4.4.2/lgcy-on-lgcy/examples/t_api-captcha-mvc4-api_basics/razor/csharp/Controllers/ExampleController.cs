using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using Mvc40BasicCaptchaExampleRazorCSharp.Models;

using BotDetect.Web.Mvc;

namespace Mvc40BasicCaptchaExampleRazorCSharp.Controllers
{
    public class ExampleController : Controller
    {
        //
        // GET: /Example/

        public ActionResult Index()
        {
            return View();
        }


        //
        // POST: /Example/

        [HttpPost]
        [CaptchaValidationActionFilter("CaptchaCode", "ExampleCaptcha", "Incorrect CAPTCHA code!")]
        public ActionResult Index(ExampleModel model)
        {
            MvcCaptcha.ResetCaptcha("ExampleCaptcha");
            return View(model);
        }

    }
}
