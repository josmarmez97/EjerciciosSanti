#pragma checksum "D:\Trabajo\Capacitacion\C#\EJERCICIOS\Views\Visitas\Eliminar.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "0b0531487b6a5f58b0f6f7d9170d582a6e9be6e0"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Visitas_Eliminar), @"mvc.1.0.view", @"/Views/Visitas/Eliminar.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"0b0531487b6a5f58b0f6f7d9170d582a6e9be6e0", @"/Views/Visitas/Eliminar.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"e03404e79ed1db81b77078870c18c9b3d042f6a0", @"/Views/_ViewImports.cshtml")]
    public class Views_Visitas_Eliminar : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 1 "D:\Trabajo\Capacitacion\C#\EJERCICIOS\Views\Visitas\Eliminar.cshtml"
  
    ViewData["Title"] = "Eliminar un registro";
    var nuevoID = ViewData["nuevoID"];

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n\r\n\r\n<h2>");
#nullable restore
#line 8 "D:\Trabajo\Capacitacion\C#\EJERCICIOS\Views\Visitas\Eliminar.cshtml"
Write(ViewData["Title"]);

#line default
#line hidden
#nullable disable
            WriteLiteral("</h2>\r\n<br>\r\n<div>\r\n    <h1>Hecho</h1>\r\n</div>\r\n\r\n<a class=\"brn brn-success\" href=\"/Visitas\">Regresar</a>\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<dynamic> Html { get; private set; }
    }
}
#pragma warning restore 1591
