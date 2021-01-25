using BotDetect.Web;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace AngularWebAPIwithMVC6CaptchaExample.Controllers
{
    [Route("api/contact-captcha")]
    public class ContactApiController : Controller
    {
        [HttpPost]
        public IActionResult Post([FromBody] Models.ContactFormModel data)
        {
            string name = data.Name;
            string email = data.Email;
            string subject = data.Subject;
            string message = data.Message;

            string userEnteredCaptchaCode = data.UserEnteredCaptchaCode;
            string captchaId = data.CaptchaId;

            // validate the form data
            Dictionary<string, string> errors = new Dictionary<string, string>();

            if (!IsValidName(name))
            {
                errors.Add("name", "Name must be at least 3 chars long!");
            }

            if (!IsValidEmail(email))
            {
                errors.Add("email", "Email is invalid!");
            }

            if (!IsValidSubject(subject))
            {
                errors.Add("subject", "Subject must be at least 10 chars long!");
            }

            if (!IsValidMessage(message))
            {
                errors.Add("message", "Message must be at least 10 chars long!");
            }

            // validate the user entered captcha code
            if (!IsCaptchaCorrect(userEnteredCaptchaCode, captchaId))
            {
                errors.Add("userEnteredCaptchaCode", "CAPTCHA validation failed!");
                // TODO: consider logging the attempt
            }

            bool isErrorsEmpty = errors.Count > 0 ? false : true;

            if (isErrorsEmpty)
            {
                // TODO: all validations succeeded; execute the protected action
                // (send email, write to database, etc...)
            }

            // create an object that stores the validation result
            Dictionary<string, object> validationResult = new Dictionary<string, object>();
            validationResult.Add("success", isErrorsEmpty);
            validationResult.Add("errors", errors);

            // return the json string with the validation result to the frontend
            return Json(validationResult);
        }


        // the captcha validation function
        private bool IsCaptchaCorrect(string userEnteredCaptchaCode, string captchaId)
        {
            // create a captcha instance to be used for the captcha validation
            SimpleCaptcha captcha = new SimpleCaptcha();
            // execute the captcha validation
            return captcha.Validate(userEnteredCaptchaCode, captchaId);
        }

        private bool IsValidName(string name)
        {
            if (name == null)
            {
                return false;
            }

            return (name.Length >= 3);
        }

        private bool IsValidEmail(string email)
        {
            if (email == null)
            {
                return false;
            }
            Regex regex = new Regex(@"^[\w-_\.+]*[\w-_\.]\@([\w]+\.)+[\w]+[\w]$");
            Match match = regex.Match(email);

            return match.Success;
        }

        private bool IsValidSubject(string subject)
        {
            if (subject == null)
            {
                return false;
            }

            return (subject.Length > 9) && (subject.Length < 255);
        }

        private bool IsValidMessage(string message)
        {
            if (message == null)
            {
                return false;
            }

            return (message.Length > 9) && (message.Length < 255);
        }
    }
}
