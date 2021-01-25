using Mvc6BasicCaptchaExample.Models;
using BotDetect.Web.Mvc;
using Microsoft.AspNetCore.Mvc;

namespace Mvc6BasicCaptchaExample.Controllers
{

    public class ExampleController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }


        [HttpPost]
        [CaptchaValidationActionFilter("CaptchaCode", "ExampleCaptcha", "Incorrect!")]
        public IActionResult Index(ExampleModel model)
        {
            MvcCaptcha.ResetCaptcha("ExampleCaptcha");
            return View(model);
        }

        public IActionResult Error()
        {
            return View();
        }
    }
}
