using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Mvc50CaptchaExampleCSharp.Startup))]
namespace Mvc50CaptchaExampleCSharp
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
