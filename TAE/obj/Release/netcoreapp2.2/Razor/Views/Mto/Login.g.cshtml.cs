#pragma checksum "C:\Desarrollo\TAE - copia\TAE\Views\Mto\Login.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "850908a9f430b9012ba0ac1866b9237d01f7f9a6"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Mto_Login), @"mvc.1.0.view", @"/Views/Mto/Login.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/Mto/Login.cshtml", typeof(AspNetCore.Views_Mto_Login))]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"850908a9f430b9012ba0ac1866b9237d01f7f9a6", @"/Views/Mto/Login.cshtml")]
    public class Views_Mto_Login : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#line 1 "C:\Desarrollo\TAE - copia\TAE\Views\Mto\Login.cshtml"
  
   ViewBag.Title = "Login";
   Layout = "~/Pages/Shared/_Layout.cshtml";

#line default
#line hidden
            BeginContext(82, 298, true);
            WriteLiteral(@"
    <form method=""post"" style=""margin-top:30px"" id=""login-form"" class=""form"" action="""">
        <h2 class=""text-center text-info"">Acceder al mantenimiento</h2>
            <p>
                <label class=""icon-user icon-large"" for=""email"" style=""width:100px"">Email: </label>
                ");
            EndContext();
            BeginContext(381, 27, false);
#line 10 "C:\Desarrollo\TAE - copia\TAE\Views\Mto\Login.cshtml"
           Write(Html.TextBox("email", null));

#line default
#line hidden
            EndContext();
            BeginContext(408, 135, true);
            WriteLiteral("\r\n            </p>\r\n\r\n            <p>\r\n                <label for=\"password\" style=\"width:100px\">Contraseña: </label>\r\n                ");
            EndContext();
            BeginContext(544, 31, false);
#line 15 "C:\Desarrollo\TAE - copia\TAE\Views\Mto\Login.cshtml"
           Write(Html.Password("password", null));

#line default
#line hidden
            EndContext();
            BeginContext(575, 193, true);
            WriteLiteral("\r\n            </p>\r\n            <p class=\"btn\">\r\n                <input type=\"submit\" class=\"btn btn-info btn-md\" value=\"Acceso\" style=\"margin-top:30px\" />\r\n            </p>\r\n   </form>\r\n\r\n\r\n\r\n");
            EndContext();
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
