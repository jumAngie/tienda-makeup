#pragma checksum "C:\Users\Usuario\Documents\GitHub\tienda-makeup\Maquillaje\Maquillaje.WebUI\Views\Inventario\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "5ecc1f53e6e23a903b2512f0fc173d9951a98adf"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Inventario_Index), @"mvc.1.0.view", @"/Views/Inventario/Index.cshtml")]
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
#line 1 "C:\Users\Usuario\Documents\GitHub\tienda-makeup\Maquillaje\Maquillaje.WebUI\Views\_ViewImports.cshtml"
using Maquillaje.WebUI;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\Usuario\Documents\GitHub\tienda-makeup\Maquillaje\Maquillaje.WebUI\Views\_ViewImports.cshtml"
using Maquillaje.WebUI.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"5ecc1f53e6e23a903b2512f0fc173d9951a98adf", @"/Views/Inventario/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"5aeacc3888c512d38aeb850d3125f2cbfc870771", @"/Views/_ViewImports.cshtml")]
    public class Views_Inventario_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable<Maquillaje.WebUI.Models.InventarioViewModel>>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
#nullable restore
#line 3 "C:\Users\Usuario\Documents\GitHub\tienda-makeup\Maquillaje\Maquillaje.WebUI\Views\Inventario\Index.cshtml"
  
    ViewData["Title"] = "Index";
    Layout = "~/Views/Shared/_Layout.cshtml";

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
<h1>Inventario</h1>

<div class=""col-lg-12 mb-0 order-0"">
    <div class=""card"" style=""background-color: white"">
        <div class=""d-flex align-items-end row"">
            <div class=""col-sm-12"">
                <div class=""card-header"">
                </div>
                <div class=""card-body"">
                    <table class=""table table-responsive-sm table-light"" id=""DataTable"">
                        <thead>
                            <tr>
                                <th>
                                    ");
#nullable restore
#line 21 "C:\Users\Usuario\Documents\GitHub\tienda-makeup\Maquillaje\Maquillaje.WebUI\Views\Inventario\Index.cshtml"
                               Write(Html.DisplayNameFor(model => model.inv_Id));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                                </th>\r\n                                <th>\r\n                                    ");
#nullable restore
#line 24 "C:\Users\Usuario\Documents\GitHub\tienda-makeup\Maquillaje\Maquillaje.WebUI\Views\Inventario\Index.cshtml"
                               Write(Html.DisplayNameFor(model => model.pro_Nombre));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                                </th>\r\n                                <th>\r\n                                    ");
#nullable restore
#line 27 "C:\Users\Usuario\Documents\GitHub\tienda-makeup\Maquillaje\Maquillaje.WebUI\Views\Inventario\Index.cshtml"
                               Write(Html.DisplayNameFor(model => model.pro_StockInicial));

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
                                </th>
                                <th>
                                    Existencias
                                </th>
                            </tr>
                        </thead>
                        <tbody>
");
#nullable restore
#line 35 "C:\Users\Usuario\Documents\GitHub\tienda-makeup\Maquillaje\Maquillaje.WebUI\Views\Inventario\Index.cshtml"
                             foreach (var item in Model)
                            {

#line default
#line hidden
#nullable disable
            WriteLiteral("                            <tr>\r\n                                <td>\r\n                                    ");
#nullable restore
#line 39 "C:\Users\Usuario\Documents\GitHub\tienda-makeup\Maquillaje\Maquillaje.WebUI\Views\Inventario\Index.cshtml"
                               Write(Html.DisplayFor(modelItem => item.inv_Id));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                                </td>\r\n                                <td>\r\n                                    ");
#nullable restore
#line 42 "C:\Users\Usuario\Documents\GitHub\tienda-makeup\Maquillaje\Maquillaje.WebUI\Views\Inventario\Index.cshtml"
                               Write(Html.DisplayFor(modelItem => item.pro_Nombre));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                                </td>\r\n                                <td>\r\n                                    ");
#nullable restore
#line 45 "C:\Users\Usuario\Documents\GitHub\tienda-makeup\Maquillaje\Maquillaje.WebUI\Views\Inventario\Index.cshtml"
                               Write(Html.DisplayFor(modelItem => item.pro_StockInicial));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                                </td>\r\n                                <td>\r\n                                    ");
#nullable restore
#line 48 "C:\Users\Usuario\Documents\GitHub\tienda-makeup\Maquillaje\Maquillaje.WebUI\Views\Inventario\Index.cshtml"
                               Write(Html.DisplayFor(modelItem => item.inv_Cantidad));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                                </td>\r\n                            </tr>\r\n");
#nullable restore
#line 51 "C:\Users\Usuario\Documents\GitHub\tienda-makeup\Maquillaje\Maquillaje.WebUI\Views\Inventario\Index.cshtml"
                            }

#line default
#line hidden
#nullable disable
            WriteLiteral("                        </tbody>\r\n                    </table>\r\n                </div>\r\n            </div>\r\n\r\n        </div>\r\n    </div>\r\n</div>\r\n\r\n");
#nullable restore
#line 61 "C:\Users\Usuario\Documents\GitHub\tienda-makeup\Maquillaje\Maquillaje.WebUI\Views\Inventario\Index.cshtml"
Write(Html.Partial("_Create"));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IEnumerable<Maquillaje.WebUI.Models.InventarioViewModel>> Html { get; private set; }
    }
}
#pragma warning restore 1591
