#pragma checksum "D:\Trabajo\Capacitacion\C#\EJERCICIOS\Views\SessionesyCookies\Login.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "24826c2af6f540233e8b34a9ea54b7b69f31cc4b"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_SessionesyCookies_Login), @"mvc.1.0.view", @"/Views/SessionesyCookies/Login.cshtml")]
namespace AspNetCore
{
    #line hidden
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Rendering;
    using Microsoft.AspNetCore.Mvc.ViewFeatures;
#nullable restore
#line 1 "D:\Trabajo\Capacitacion\C#\EJERCICIOS\Views\_ViewImports.cshtml"
using EJERCICIOS;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "D:\Trabajo\Capacitacion\C#\EJERCICIOS\Views\_ViewImports.cshtml"
using EJERCICIOS.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"24826c2af6f540233e8b34a9ea54b7b69f31cc4b", @"/Views/SessionesyCookies/Login.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"e03404e79ed1db81b77078870c18c9b3d042f6a0", @"/Views/_ViewImports.cshtml")]
    public class Views_SessionesyCookies_Login : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<EJERCICIOS.Models.SesionesyCookiesM>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 2 "D:\Trabajo\Capacitacion\C#\EJERCICIOS\Views\SessionesyCookies\Login.cshtml"
  
    
    ViewBag.Title = "Login";
    

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n<h2>Ingrese sus Datos</h2>\r\n\r\n");
#nullable restore
#line 10 "D:\Trabajo\Capacitacion\C#\EJERCICIOS\Views\SessionesyCookies\Login.cshtml"
 using (Html.BeginForm("Ingresar", "SessionesyCookies",FormMethod.Post))
{
    

#line default
#line hidden
#nullable disable
#nullable restore
#line 12 "D:\Trabajo\Capacitacion\C#\EJERCICIOS\Views\SessionesyCookies\Login.cshtml"
Write(Html.AntiForgeryToken());

#line default
#line hidden
#nullable disable
            WriteLiteral("    <div class=\"form-horizontal\">\r\n        <hr />\r\n        ");
#nullable restore
#line 16 "D:\Trabajo\Capacitacion\C#\EJERCICIOS\Views\SessionesyCookies\Login.cshtml"
   Write(Html.ValidationSummary(true, "", new { @class = "text-danger" }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        <div class=\"form-group\">\r\n            ");
#nullable restore
#line 18 "D:\Trabajo\Capacitacion\C#\EJERCICIOS\Views\SessionesyCookies\Login.cshtml"
       Write(Html.LabelFor(model => model.username, htmlAttributes: new { @class = "control-label col-md-2" }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            <div class=\"col-md-10\">\r\n                ");
#nullable restore
#line 20 "D:\Trabajo\Capacitacion\C#\EJERCICIOS\Views\SessionesyCookies\Login.cshtml"
           Write(Html.EditorFor(model => model.username, new { htmlAttributes = new { @class = "form-control" } }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                ");
#nullable restore
#line 21 "D:\Trabajo\Capacitacion\C#\EJERCICIOS\Views\SessionesyCookies\Login.cshtml"
           Write(Html.ValidationMessageFor(model => model.username, "", new { @class = "text-danger" }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </div>\r\n        </div>\r\n\r\n        <div class=\"form-group\">\r\n            ");
#nullable restore
#line 26 "D:\Trabajo\Capacitacion\C#\EJERCICIOS\Views\SessionesyCookies\Login.cshtml"
       Write(Html.LabelFor(model => model.password, htmlAttributes: new { @class = "control-label col-md-2" }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            <div class=\"col-md-10\">\r\n                ");
#nullable restore
#line 28 "D:\Trabajo\Capacitacion\C#\EJERCICIOS\Views\SessionesyCookies\Login.cshtml"
           Write(Html.EditorFor(model => model.password, new { htmlAttributes = new { @class = "form-control" } }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                ");
#nullable restore
#line 29 "D:\Trabajo\Capacitacion\C#\EJERCICIOS\Views\SessionesyCookies\Login.cshtml"
           Write(Html.ValidationMessageFor(model => model.password, "", new { @class = "text-danger" }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </div>\r\n        </div>\r\n\r\n        <div class=\"form-group\">\r\n            <div class=\"col-md-offset-2 col-md-10\">\r\n                <input type=\"submit\" value=\"Ingresar\" class=\"btn btn-dark\" />\r\n            </div>\r\n        </div>\r\n    </div>\r\n");
#nullable restore
#line 39 "D:\Trabajo\Capacitacion\C#\EJERCICIOS\Views\SessionesyCookies\Login.cshtml"
}

#line default
#line hidden
#nullable disable
            DefineSection("Scripts", async() => {
                WriteLiteral("\r\n    <script type=\"text/javascript\"\r\n            src=\"https://cdnjs.cloudflare.com/ajax/libs/mdb-ui-kit/3.0.0/mdb.min.js\">\r\n    </script>\r\n");
            }
            );
        }
        #pragma warning restore 1998
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.IModelExpressionProvider ModelExpressionProvider { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IUrlHelper Url { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IViewComponentHelper Component { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IJsonHelper Json { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<EJERCICIOS.Models.SesionesyCookiesM> Html { get; private set; }
    }
}
#pragma warning restore 1591
