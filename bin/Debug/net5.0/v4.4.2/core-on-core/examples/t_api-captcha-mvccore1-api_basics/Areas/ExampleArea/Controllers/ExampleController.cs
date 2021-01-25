using Mvc6BasicCaptchaExample.Areas.ExampleArea.Models;
using BotDetect.Web.Mvc;
using Microsoft.AspNetCore.Mvc;

namespace Mvc6BasicCaptchaExample.Areas.ExampleArea.Controllers
{
    [Area("ExampleArea")]
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

    }
}
