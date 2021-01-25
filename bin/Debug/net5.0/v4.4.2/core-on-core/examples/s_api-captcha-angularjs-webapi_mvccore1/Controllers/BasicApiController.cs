using BotDetect.Web;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace AngularJSWebAPIwithMVC6CaptchaExample.Controllers
{
    [Produces("application/json")]
    [Route("api/basic-captcha")]
    public class BasicApiController : Controller
    {
        [HttpPost]
        public IActionResult Post([FromBody] Models.BasicFormModel data)
        {
            // create a captcha instance to be used for the captcha validation
            SimpleCaptcha captcha = new SimpleCaptcha();
            // execute the captcha validation
            bool isHuman = captcha.Validate(data.UserEnteredCaptchaCode, data.CaptchaId);

            // create an object that stores the validation result
            Dictionary<string, bool> validationResult = new Dictionary<string, bool>();

            if (isHuman == false)
            {
                // captcha validation failed
                validationResult.Add("success", false);
                // TODO: consider logging the attempt
            }
            else
            {
                // captcha validation succeeded
                validationResult.Add("success", true);
            }

            // return the json string with the validation result to the frontend
            return Json(validationResult);
        }
    }
}
