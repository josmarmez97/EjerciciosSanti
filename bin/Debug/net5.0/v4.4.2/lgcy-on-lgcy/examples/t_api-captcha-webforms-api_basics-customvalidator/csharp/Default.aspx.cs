using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebFormsValidatorCaptchaExampleCSharp
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_PreRender(object sender, EventArgs e)
        {
            // setup client-side input processing
            ExampleCaptcha.UserInputID = CaptchaCodeTextBox.ClientID;

            if (IsPostBack)
            {
                // clear previous user input
                CaptchaCodeTextBox.Text = null;

                if (Page.IsValid)
                {
                    ValidationPassedLabel.Visible = true;
                }
                else
                {
                    ValidationPassedLabel.Visible = false;
                }
            }
        }
    }
}