using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace traditionalapi_mvccore1_registration_captcha.Services
{
    public interface ISmsSender
    {
        Task SendSmsAsync(string number, string message);
    }
}
