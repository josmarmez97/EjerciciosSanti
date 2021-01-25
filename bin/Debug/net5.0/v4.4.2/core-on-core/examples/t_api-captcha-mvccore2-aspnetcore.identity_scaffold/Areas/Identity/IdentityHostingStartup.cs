using System;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using traditionalapi_mvccore2_registration_captcha.Data;

[assembly: HostingStartup(typeof(traditionalapi_mvccore2_registration_captcha.Areas.Identity.IdentityHostingStartup))]
namespace traditionalapi_mvccore2_registration_captcha.Areas.Identity
{
    public class IdentityHostingStartup : IHostingStartup
    {
        public void Configure(IWebHostBuilder builder)
        {
            builder.ConfigureServices((context, services) => {
            });
        }
    }
}