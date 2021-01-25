using System.Web;
using System.Web.Mvc;

namespace Mvc40BasicCaptchaExampleAspxCSharp
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}