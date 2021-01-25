using System;
using System.Web.UI;

namespace WebForms451CaptchaExampleCSharp
{
    public partial class _Default : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            // Since we want to show the Captcha as soon as the example loads,
            // we redirect all non-authenticated visits to the Register form.
            Response.Redirect("~/Account/Register");
        }
    }
}