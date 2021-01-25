using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(WebForms451CaptchaExampleCSharp.Startup))]
namespace WebForms451CaptchaExampleCSharp
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
