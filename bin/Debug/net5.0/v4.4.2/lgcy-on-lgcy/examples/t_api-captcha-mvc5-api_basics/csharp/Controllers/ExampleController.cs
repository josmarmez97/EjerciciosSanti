using System.Web.Mvc;

using BotDetect.Web.Mvc;

using Mvc50BasicCaptchaExampleCSharp.Models;


namespace Mvc50BasicCaptchaExampleCSharp.Controllers
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
        [CaptchaValidationActionFilter("CaptchaCode", "ExampleCaptcha", "Incorrect!")]
        public ActionResult Index(ExampleModel model)
        {
            MvcCaptcha.ResetCaptcha("ExampleCaptcha");
            return View(model);
        }

    }
}