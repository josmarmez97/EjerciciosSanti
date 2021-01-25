using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using BotDetect.Web.Mvc;

namespace traditionalapi_mvccore1_registration_captcha.Models.AccountViewModels
{
    public class LoginViewModel
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Required]
        [CaptchaModelStateValidation("LoginCaptcha", ErrorMessage = "Incorrect code, please try again.")]
        public string CaptchaCode { get; set; }

        [Display(Name = "Remember me?")]
        public bool RememberMe { get; set; }
    }
}
