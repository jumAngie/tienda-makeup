#pragma checksum "C:\Users\LAB02\Desktop\Maqui\tienda-makeup\Maquillaje\Maquillaje.WebUI\Views\Departamentos\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "964f797deecc784dc3bb1f06c04cb003bdebc06d"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Departamentos_Index), @"mvc.1.0.view", @"/Views/Departamentos/Index.cshtml")]
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
#line 1 "C:\Users\LAB02\Desktop\Maqui\tienda-makeup\Maquillaje\Maquillaje.WebUI\Views\_ViewImports.cshtml"
using Maquillaje.WebUI;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\LAB02\Desktop\Maqui\tienda-makeup\Maquillaje\Maquillaje.WebUI\Views\_ViewImports.cshtml"
using Maquillaje.WebUI.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"964f797deecc784dc3bb1f06c04cb003bdebc06d", @"/Views/Departamentos/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"5aeacc3888c512d38aeb850d3125f2cbfc870771", @"/Views/_ViewImports.cshtml")]
    public class Views_Departamentos_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable<Maquillaje.WebUI.Models.DepartamentosViewModel>>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("btn  btn-outline-success"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Details", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
#nullable restore
#line 3 "C:\Users\LAB02\Desktop\Maqui\tienda-makeup\Maquillaje\Maquillaje.WebUI\Views\Departamentos\Index.cshtml"
  
    ViewData["Title"] = "Index";
    Layout = "~/Views/Shared/_Layout.cshtml";

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
<div class=""col-lg-12 mb-0 order-0"">
    <div class=""card"" style=""background-color: white"">
        <div class=""d-flex align-items-end row"">
            <div class=""col-sm-12"">
                <div class=""card-header"">
                    <a class=""btn btn-primary"" data-toggle=""modal"" data-target=""#CreateDep"">Nuevo</a>

                </div>
                <div class=""card-body"">


                    <table class=""table table-responsive-sm table-light"" id=""DataTable"">
                        <thead>
                            <tr>
                                <th>
                                    ");
#nullable restore
#line 23 "C:\Users\LAB02\Desktop\Maqui\tienda-makeup\Maquillaje\Maquillaje.WebUI\Views\Departamentos\Index.cshtml"
                               Write(Html.DisplayNameFor(model => model.dep_ID));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                                </th>\r\n                                <th>\r\n                                    ");
#nullable restore
#line 26 "C:\Users\LAB02\Desktop\Maqui\tienda-makeup\Maquillaje\Maquillaje.WebUI\Views\Departamentos\Index.cshtml"
                               Write(Html.DisplayNameFor(model => model.dep_Descripcion));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                                </th>\r\n\r\n                                <th></th>\r\n                            </tr>\r\n                        </thead>\r\n                        <tbody>\r\n");
#nullable restore
#line 33 "C:\Users\LAB02\Desktop\Maqui\tienda-makeup\Maquillaje\Maquillaje.WebUI\Views\Departamentos\Index.cshtml"
                             foreach (var item in Model)
                            {

#line default
#line hidden
#nullable disable
            WriteLiteral("                                <tr>\r\n                                    <td>\r\n                                        ");
#nullable restore
#line 37 "C:\Users\LAB02\Desktop\Maqui\tienda-makeup\Maquillaje\Maquillaje.WebUI\Views\Departamentos\Index.cshtml"
                                   Write(Html.DisplayFor(modelItem => item.dep_ID));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                                    </td>\r\n\r\n                                    <td>\r\n                                        ");
#nullable restore
#line 41 "C:\Users\LAB02\Desktop\Maqui\tienda-makeup\Maquillaje\Maquillaje.WebUI\Views\Departamentos\Index.cshtml"
                                   Write(Html.DisplayFor(modelItem => item.dep_Descripcion));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                                    </td>\r\n\r\n                                    <td>\r\n                                        <button type=\"button\" id=\"btnEditar\" class=\"btn btn-outline-info\"");
            BeginWriteAttribute("onclick", " onclick=\"", 1812, "\"", 1866, 5);
            WriteAttributeValue("", 1822, "Editar(\'", 1822, 8, true);
#nullable restore
#line 45 "C:\Users\LAB02\Desktop\Maqui\tienda-makeup\Maquillaje\Maquillaje.WebUI\Views\Departamentos\Index.cshtml"
WriteAttributeValue("", 1830, item.dep_ID, 1830, 12, false);

#line default
#line hidden
#nullable disable
            WriteAttributeValue("", 1842, ",", 1842, 1, true);
#nullable restore
#line 45 "C:\Users\LAB02\Desktop\Maqui\tienda-makeup\Maquillaje\Maquillaje.WebUI\Views\Departamentos\Index.cshtml"
WriteAttributeValue("", 1843, item.dep_Descripcion, 1843, 21, false);

#line default
#line hidden
#nullable disable
            WriteAttributeValue("", 1864, "\')", 1864, 2, true);
            EndWriteAttribute();
            WriteLiteral(">Editar</button> |\r\n                                        ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "964f797deecc784dc3bb1f06c04cb003bdebc06d8073", async() => {
                WriteLiteral("Detalles");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_1.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
            if (__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
            {
                throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-id", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
            }
            BeginWriteTagHelperAttribute();
#nullable restore
#line 46 "C:\Users\LAB02\Desktop\Maqui\tienda-makeup\Maquillaje\Maquillaje.WebUI\Views\Departamentos\Index.cshtml"
                                                                                                   WriteLiteral(item.dep_ID);

#line default
#line hidden
#nullable disable
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"] = __tagHelperStringValueBuffer;
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-route-id", __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"], global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral(" |\r\n                                    </td>\r\n                                </tr>\r\n");
#nullable restore
#line 49 "C:\Users\LAB02\Desktop\Maqui\tienda-makeup\Maquillaje\Maquillaje.WebUI\Views\Departamentos\Index.cshtml"
                            }

#line default
#line hidden
#nullable disable
            WriteLiteral("                        </tbody>\r\n                    </table>\r\n                </div>\r\n            </div>\r\n\r\n        </div>\r\n    </div>\r\n</div>\r\n\r\n");
#nullable restore
#line 59 "C:\Users\LAB02\Desktop\Maqui\tienda-makeup\Maquillaje\Maquillaje.WebUI\Views\Departamentos\Index.cshtml"
Write(Html.Partial("_Create"));

#line default
#line hidden
#nullable disable
            WriteLiteral(";\r\n");
#nullable restore
#line 60 "C:\Users\LAB02\Desktop\Maqui\tienda-makeup\Maquillaje\Maquillaje.WebUI\Views\Departamentos\Index.cshtml"
Write(Html.Partial("_Edit"));

#line default
#line hidden
#nullable disable
            WriteLiteral(";\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IEnumerable<Maquillaje.WebUI.Models.DepartamentosViewModel>> Html { get; private set; }
    }
}
#pragma warning restore 1591
