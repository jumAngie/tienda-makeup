#pragma checksum "C:\Users\Juan David\Desktop\m\tienda-makeup\Maquillaje\Maquillaje.WebUI\Views\Cliente\Details.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "ebf8949106ecea62e230252d34f159a69019b849"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Cliente_Details), @"mvc.1.0.view", @"/Views/Cliente/Details.cshtml")]
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
#line 1 "C:\Users\Juan David\Desktop\m\tienda-makeup\Maquillaje\Maquillaje.WebUI\Views\_ViewImports.cshtml"
using Maquillaje.WebUI;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\Juan David\Desktop\m\tienda-makeup\Maquillaje\Maquillaje.WebUI\Views\_ViewImports.cshtml"
using Maquillaje.WebUI.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"ebf8949106ecea62e230252d34f159a69019b849", @"/Views/Cliente/Details.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"5aeacc3888c512d38aeb850d3125f2cbfc870771", @"/Views/_ViewImports.cshtml")]
    public class Views_Cliente_Details : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<Maquillaje.WebUI.Models.ClientesViewModel>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("src", new global::Microsoft.AspNetCore.Html.HtmlString("~/Content/iMG/giphy.gif"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("width", new global::Microsoft.AspNetCore.Html.HtmlString("100"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("btn btn-secondary"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Index", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        #line hidden
        #pragma warning disable 0649
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperExecutionContext __tagHelperExecutionContext;
        #pragma warning restore 0649
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner __tagHelperRunner = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner();
        #pragma warning disable 0169
        private string __tagHelperStringValueBuffer;
        #pragma warning restore 0169
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager __backed__tagHelperScopeManager = null;
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager __tagHelperScopeManager
        {
            get
            {
                if (__backed__tagHelperScopeManager == null)
                {
                    __backed__tagHelperScopeManager = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager(StartTagHelperWritingScope, EndTagHelperWritingScope);
                }
                return __backed__tagHelperScopeManager;
            }
        }
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n\r\n");
            WriteLiteral("\r\n");
#nullable restore
#line 5 "C:\Users\Juan David\Desktop\m\tienda-makeup\Maquillaje\Maquillaje.WebUI\Views\Cliente\Details.cshtml"
  
    ViewData["Title"] = "Detalles";
    Layout = "~/Views/Shared/_Layout.cshtml";

#line default
#line hidden
#nullable disable
            WriteLiteral("<div class=\"text-center\">\r\n    ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("img", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "ebf8949106ecea62e230252d34f159a69019b8495079", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_1);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral(@"
    <h1 style=""color:black;font-family:'Segoe Print'"">Detalles Clientes</h1>
</div>
<div>
    <hr />



    <center>
        <dl class=""dl-horizontal"">

            <div class=""row"">
                <div class=""col-sm-2""></div>

                <div class=""col-sm-4"">
            <dt>
                Nombre Cliente
            </dt>

            <dd class=""form-control"">
                ");
#nullable restore
#line 30 "C:\Users\Juan David\Desktop\m\tienda-makeup\Maquillaje\Maquillaje.WebUI\Views\Cliente\Details.cshtml"
           Write(Html.DisplayFor(model => model.cli_Nombre));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </dd>\r\n</div>\r\n\r\n\r\n<div class=\"col-sm-4\">\r\n    <dt>\r\n        Apellido Cliente\r\n    </dt>\r\n\r\n    <dd class=\"form-control\">\r\n        ");
#nullable restore
#line 41 "C:\Users\Juan David\Desktop\m\tienda-makeup\Maquillaje\Maquillaje.WebUI\Views\Cliente\Details.cshtml"
   Write(Html.DisplayFor(model => model.cli_Apellido));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n    </dd>\r\n</div>\r\n </div>\r\n\r\n\r\n<br />\r\n\r\n\r\n<div class=\"row\">\r\n    <div class=\"col-sm-2\"></div>\r\n\r\n    <div class=\"col-sm-4\">\r\n        <dt>\r\n            DNI\r\n        </dt>\r\n\r\n        <dd class=\"form-control\">\r\n            ");
#nullable restore
#line 59 "C:\Users\Juan David\Desktop\m\tienda-makeup\Maquillaje\Maquillaje.WebUI\Views\Cliente\Details.cshtml"
       Write(Html.DisplayFor(model => model.cli_DNI));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dd>\r\n    </div>\r\n\r\n\r\n    <div class=\"col-sm-4\">\r\n        <dt>\r\n            Fecha de Nacimiento\r\n        </dt>\r\n\r\n        <dd class=\"form-control\">\r\n            ");
#nullable restore
#line 70 "C:\Users\Juan David\Desktop\m\tienda-makeup\Maquillaje\Maquillaje.WebUI\Views\Cliente\Details.cshtml"
       Write(Html.DisplayFor(model => model.cli_FechaNacimiento));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dd>\r\n    </div>\r\n</div>\r\n\r\n<br />\r\n\r\n\r\n<div class=\"row\">\r\n    <div class=\"col-sm-2\"></div>\r\n\r\n    <div class=\"col-sm-4\">\r\n        <dt>\r\n            Sexo\r\n        </dt>\r\n\r\n        <dd class=\"form-control\">\r\n            ");
#nullable restore
#line 87 "C:\Users\Juan David\Desktop\m\tienda-makeup\Maquillaje\Maquillaje.WebUI\Views\Cliente\Details.cshtml"
       Write(Html.DisplayFor(model => model.cli_Sexo));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dd>\r\n    </div>\r\n\r\n\r\n    <div class=\"col-sm-4\">\r\n        <dt>\r\n            Teléfono\r\n        </dt>\r\n\r\n        <dd class=\"form-control\">\r\n            ");
#nullable restore
#line 98 "C:\Users\Juan David\Desktop\m\tienda-makeup\Maquillaje\Maquillaje.WebUI\Views\Cliente\Details.cshtml"
       Write(Html.DisplayFor(model => model.cli_Telefono));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dd>\r\n    </div>\r\n</div>\r\n\r\n<br />\r\n\r\n\r\n<div class=\"row\">\r\n    <div class=\"col-sm-2\"></div>\r\n\r\n    <div class=\"col-sm-4\">\r\n        <dt>\r\n            Municipio de Residencia\r\n        </dt>\r\n\r\n        <dd class=\"form-control\">\r\n            ");
#nullable restore
#line 115 "C:\Users\Juan David\Desktop\m\tienda-makeup\Maquillaje\Maquillaje.WebUI\Views\Cliente\Details.cshtml"
       Write(Html.DisplayFor(model => model.cli_Municipio));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dd>\r\n    </div>\r\n\r\n\r\n    <div class=\"col-sm-4\">\r\n        <dt>\r\n            Estado Civil\r\n        </dt>\r\n\r\n        <dd class=\"form-control\">\r\n            ");
#nullable restore
#line 126 "C:\Users\Juan David\Desktop\m\tienda-makeup\Maquillaje\Maquillaje.WebUI\Views\Cliente\Details.cshtml"
       Write(Html.DisplayFor(model => model.cli_EstadoCivil));

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
        </dd>
    </div>
</div>


                        </dl>
                        </center>
<br />
<div class=""card"">
    <div class=""text-center"">
        <div class=""card-header"" style=""background-color: #ffd3d8"">
            <h4 style=""color:black;font-family:'Segoe Print'"">Auditoria</h4>
        </div>


        <table class=""table"">
            <thead>
                <tr>
                    <th><strong>Acción</strong></th>
                    <th><strong>Usuario</strong></th>
                    <th><strong>Fecha</strong></th>
                </tr>
            </thead>
            <tbody>
                <tr>
                    <td>Creado</td>
                    <td>");
#nullable restore
#line 153 "C:\Users\Juan David\Desktop\m\tienda-makeup\Maquillaje\Maquillaje.WebUI\Views\Cliente\Details.cshtml"
                   Write(ViewBag.UsuCrea);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                    <td>");
#nullable restore
#line 154 "C:\Users\Juan David\Desktop\m\tienda-makeup\Maquillaje\Maquillaje.WebUI\Views\Cliente\Details.cshtml"
                   Write(Html.DisplayFor(model => model.cli_FechaCrea));

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                </tr>\r\n                <tr>\r\n                    <td>Modificado</td>\r\n                    <td>");
#nullable restore
#line 158 "C:\Users\Juan David\Desktop\m\tienda-makeup\Maquillaje\Maquillaje.WebUI\Views\Cliente\Details.cshtml"
                   Write(ViewBag.UsuModi);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                    <td>");
#nullable restore
#line 159 "C:\Users\Juan David\Desktop\m\tienda-makeup\Maquillaje\Maquillaje.WebUI\Views\Cliente\Details.cshtml"
                   Write(Html.DisplayFor(model => model.cli_FechaModi));

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                </tr>\r\n\r\n            </tbody>\r\n        </table>\r\n\r\n    </div>\r\n    <div class=\"card-footer\" style=\"background-color: #ffd3d8\">\r\n        <div class=\"text-center\">\r\n            ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "ebf8949106ecea62e230252d34f159a69019b84912619", async() => {
                WriteLiteral("Volver");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_2);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_3.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_3);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n        </div>\r\n    </div>\r\n</div>\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<Maquillaje.WebUI.Models.ClientesViewModel> Html { get; private set; }
    }
}
#pragma warning restore 1591
