using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Web.Http;
using AngularJSWebAPICaptchaExampleCSharp.Backend.Models;
using BotDetect.Web;

namespace AngularJSWebAPICaptchaExampleCSharp.Backend.Controllers
{
    public class WebApiController : ApiController
    {

        // POST api/webapi/basic
        public IHttpActionResult Basic([FromBody]CaptchaBasicModel data)
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
            return Ok(validationResult);
        }

        // POST api/webapi/contact
        public IHttpActionResult Contact([FromBody]CaptchaContactModel data)
        {
            string name = data.Name;
            string email = data.Email;
            string subject = data.Subject;
            string message = data.Message;

            string userEnteredCaptchaCode = data.UserEnteredCaptchaCode;
            string captchaId = data.CaptchaId;

            // validate captcha
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

            bool isErrorsEmpty = errors.Count <= 0;

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
            return Ok(validationResult);
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
            Regex regex = new Regex("^[\\w-_\\.+]*[\\w-_\\.]\\@([\\w]+\\.)+[\\w]+[\\w]$");
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
