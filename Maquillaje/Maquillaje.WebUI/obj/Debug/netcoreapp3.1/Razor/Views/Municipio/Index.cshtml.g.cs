#pragma checksum "C:\Users\PC\Documents\GitHub\tienda-makeup\Maquillaje\Maquillaje.WebUI\Views\Municipio\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "a8358591f0aa6bb555b142fdfbef1db05d2f7ca0"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Municipio_Index), @"mvc.1.0.view", @"/Views/Municipio/Index.cshtml")]
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
#line 1 "C:\Users\PC\Documents\GitHub\tienda-makeup\Maquillaje\Maquillaje.WebUI\Views\_ViewImports.cshtml"
using Maquillaje.WebUI;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\PC\Documents\GitHub\tienda-makeup\Maquillaje\Maquillaje.WebUI\Views\_ViewImports.cshtml"
using Maquillaje.WebUI.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"a8358591f0aa6bb555b142fdfbef1db05d2f7ca0", @"/Views/Municipio/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"5aeacc3888c512d38aeb850d3125f2cbfc870771", @"/Views/_ViewImports.cshtml")]
    public class Views_Municipio_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable<Maquillaje.WebUI.Models.MunicipiosViewModel>>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("src", new global::Microsoft.AspNetCore.Html.HtmlString("~/Content/iMG/giphy.gif"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("width", new global::Microsoft.AspNetCore.Html.HtmlString("100"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("id", new global::Microsoft.AspNetCore.Html.HtmlString("EditMun"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("method", "post", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_4 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("btn btn-outline-success"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_5 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("style", new global::Microsoft.AspNetCore.Html.HtmlString("color: black"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_6 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Details", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
#nullable restore
#line 3 "C:\Users\PC\Documents\GitHub\tienda-makeup\Maquillaje\Maquillaje.WebUI\Views\Municipio\Index.cshtml"
  
    ViewData["Title"] = "Index";
    Layout = "~/Views/Shared/_Layout.cshtml";

#line default
#line hidden
#nullable disable
            WriteLiteral(@"

<br />
<br />
<div class=""col-lg-12 mb-0 order-0"">
    <div class=""card"" style=""background-color: white"">
        <div class=""d-flex align-items-end row"">
            <div class=""col-sm-12"">
                <div class=""card-header"" style=""background-color:#ffd3d8"">
                    <div class=""text-center"">
                        ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("img", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "a8358591f0aa6bb555b142fdfbef1db05d2f7ca06659", async() => {
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
                        <h3 style=""color:black;font-family:'Segoe Print'"">Listado Municipios</h3>
                    </div>
                </div>
                <div class=""card-body"">

                    <a class=""btn btn-primary"" data-toggle=""modal"" data-target=""#CreateMuni""><i class=""icon-copy fa fa-plus"" aria-hidden=""true""></i> Nuevo</a>
                    <br />
                    <br />
                    <table class=""table table-report -mt-2"" id=""DataTable"">
                        <thead>
                            <tr>
                                <th>
                                    ");
#nullable restore
#line 30 "C:\Users\PC\Documents\GitHub\tienda-makeup\Maquillaje\Maquillaje.WebUI\Views\Municipio\Index.cshtml"
                               Write(Html.DisplayNameFor(model => model.mun_ID));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                                </th>\r\n                                <th>\r\n                                    ");
#nullable restore
#line 33 "C:\Users\PC\Documents\GitHub\tienda-makeup\Maquillaje\Maquillaje.WebUI\Views\Municipio\Index.cshtml"
                               Write(Html.DisplayNameFor(model => model.mun_Descripcion));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                                </th>\r\n                                <th>\r\n                                    ");
#nullable restore
#line 36 "C:\Users\PC\Documents\GitHub\tienda-makeup\Maquillaje\Maquillaje.WebUI\Views\Municipio\Index.cshtml"
                               Write(Html.DisplayNameFor(model => model.mun_depID));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                                </th>\r\n                                <th></th>\r\n                                <th></th>\r\n                            </tr>\r\n                        </thead>\r\n                        <tbody>\r\n");
#nullable restore
#line 43 "C:\Users\PC\Documents\GitHub\tienda-makeup\Maquillaje\Maquillaje.WebUI\Views\Municipio\Index.cshtml"
                             foreach (var item in Model)
                            {

#line default
#line hidden
#nullable disable
            WriteLiteral("                                <tr>\r\n                                    <td>\r\n                                        ");
#nullable restore
#line 47 "C:\Users\PC\Documents\GitHub\tienda-makeup\Maquillaje\Maquillaje.WebUI\Views\Municipio\Index.cshtml"
                                   Write(Html.DisplayFor(modelItem => item.mun_ID));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                                    </td>\r\n                                    <td>\r\n                                        ");
#nullable restore
#line 50 "C:\Users\PC\Documents\GitHub\tienda-makeup\Maquillaje\Maquillaje.WebUI\Views\Municipio\Index.cshtml"
                                   Write(Html.DisplayFor(modelItem => item.mun_Descripcion));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                                    </td>\r\n                                    <td>\r\n                                        ");
#nullable restore
#line 53 "C:\Users\PC\Documents\GitHub\tienda-makeup\Maquillaje\Maquillaje.WebUI\Views\Municipio\Index.cshtml"
                                   Write(Html.DisplayFor(modelItem => item.mun_depID));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                                    </td>\r\n\r\n                                    <td>\r\n                                        <a class=\"btn btn-primary\" data-toggle=\"modal\" data-target=\"#EditMuni\"");
            BeginWriteAttribute("onclick", " onclick=\"", 2582, "\"", 2617, 3);
            WriteAttributeValue("", 2592, "CargaEditar(", 2592, 12, true);
#nullable restore
#line 57 "C:\Users\PC\Documents\GitHub\tienda-makeup\Maquillaje\Maquillaje.WebUI\Views\Municipio\Index.cshtml"
WriteAttributeValue("", 2604, item.mun_ID, 2604, 12, false);

#line default
#line hidden
#nullable disable
            WriteAttributeValue("", 2616, ")", 2616, 1, true);
            EndWriteAttribute();
            WriteLiteral("><i class=\"icon-copy fa fa-pencil-square-o\" aria-hidden=\"true\"></i> Editar</a>\r\n\r\n                                        ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("Form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "a8358591f0aa6bb555b142fdfbef1db05d2f7ca012268", async() => {
                WriteLiteral(@"

                                            <div class=""modal fade"" id=""EditMuni"" tabindex=""-1"" role=""dialog"" aria-labelledby=""myLargeModalLabel"" aria-hidden=""true"">
                                                <div class=""modal-dialog modal-dialog-centered"">
                                                    <div class=""modal-content"">
                                                        <div class=""card-header"" style=""background-color:#ffd3d8"">
                                                            <button type=""button"" class=""close"" data-dismiss=""modal"" aria-hidden=""true"">×</button>

                                                            <div class=""text-center"">
                                                                ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("img", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "a8358591f0aa6bb555b142fdfbef1db05d2f7ca013321", async() => {
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
                                                                <h3 style=""color:black;font-family:'Segoe Print'"">Edite un Municipio</h3>
                                                            </div>
                                                        </div>
                                                        <div class=""modal-body"">
                                                            <br />

                                                            <input type=""hidden"" id=""mun_IdEdit"" name=""mun_Id"" class=""form-control"" readonly />
                                                            <div class=""row"">
                                                                <div class=""col-sm-6"">
                                                                    <label>Departamento</label>
                                                                    <select id=""mun_DepIdEdit"" name=""mun_DepIdEdit"" class=""form-control""></select>
                                          ");
                WriteLiteral(@"                      </div>

                                                                <div class=""col-sm-6"">
                                                                    <label>Municipio</label>
                                                                    <input type=""text"" id=""mun_DescripcionEdit"" required name=""mun_Descripcion"" class=""form-control"" />
                                                                </div>
                                                            </div>
                                                            <br />
                                                        </div>
                                                        <div class=""modal-footer"">
                                                            <button type=""button"" data-dismiss=""modal"" style=""color: black"" class=""btn btn-primary""><i class=""icon-copy fa fa-remove"" aria-hidden=""true""></i> Cancelar</button>
                                                            ");
                WriteLiteral(@"<button type=""button"" onclick=""Editar()"" class=""btn btn-outline-secondary""> <i class=""icon-copy fa fa-floppy-o"" aria-hidden=""true""></i> Guardar</button>
                                                        </div>
                                                    </div>
                                                </div>
                                            </div>
                                        ");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper);
            BeginAddHtmlAttributeValues(__tagHelperExecutionContext, "action", 1, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
#nullable restore
#line 59 "C:\Users\PC\Documents\GitHub\tienda-makeup\Maquillaje\Maquillaje.WebUI\Views\Municipio\Index.cshtml"
AddHtmlAttributeValue("", 2754, Url.Action("Edit","Municipio"), 2754, 31, false);

#line default
#line hidden
#nullable disable
            EndAddHtmlAttributeValues(__tagHelperExecutionContext);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_2);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Method = (string)__tagHelperAttribute_3.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_3);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n\r\n                                    </td>\r\n                                    <td>\r\n                                        ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "a8358591f0aa6bb555b142fdfbef1db05d2f7ca018984", async() => {
                WriteLiteral("\r\n                                            <i class=\"icon-copy fa fa-file-text-o\" aria-hidden=\"true\"></i> Detalles\r\n                                        ");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_4);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_5);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_6.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_6);
            if (__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
            {
                throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-id", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
            }
            BeginWriteTagHelperAttribute();
#nullable restore
#line 100 "C:\Users\PC\Documents\GitHub\tienda-makeup\Maquillaje\Maquillaje.WebUI\Views\Municipio\Index.cshtml"
                                                                                                                       WriteLiteral(item.mun_ID);

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
            WriteLiteral("\r\n                                    </td>\r\n                                </tr>\r\n");
#nullable restore
#line 105 "C:\Users\PC\Documents\GitHub\tienda-makeup\Maquillaje\Maquillaje.WebUI\Views\Municipio\Index.cshtml"
                            }

#line default
#line hidden
#nullable disable
            WriteLiteral("                        </tbody>\r\n                    </table>\r\n                </div>\r\n            </div>\r\n\r\n        </div>\r\n    </div>\r\n\r\n\r\n    ");
#nullable restore
#line 115 "C:\Users\PC\Documents\GitHub\tienda-makeup\Maquillaje\Maquillaje.WebUI\Views\Municipio\Index.cshtml"
Write(Html.Partial("_Create"));

#line default
#line hidden
#nullable disable
            WriteLiteral(";\r\n");
            WriteLiteral(@"


    <script>

        function CargaEditar(X) {

            $('#Editar').modal('show');
            var ID = X;

            console.log(X)
            console.log(ID)


            $.ajax({
                url: ""/Municipios/CargaPaEditar/"" + ID,
                method: ""GET"",
                dataType: ""json"",
                contentType: ""application/json; charset=utf-8"",
                success: function (data) {
                    console.log(data);

                    $(""#mun_DescripcionEdit"").empty();
                    $(""#mun_DepIdEdit"").empty();

                    $.each(data, function (i, value) {

                        $(""#mun_DescripcionEdit"").val(value.mun_Descripcion);
                        $(""#mun_IdEdit"").val(value.mun_ID);

                        $.each(data, function (i, value) {
                            $(""#mun_DepIdEdit"").append(""<option value='"" + value.dep_ID + ""'>"" + value.dep_Descripcion + ""</option>"");
                        })

     ");
            WriteLiteral(@"               })

                    $.ajax({
                        url: ""/Municipios/Cargar"",
                        method: ""GET"",
                        dataType: ""json"",
                        contentType: ""application/json; charset=utf-8"",

                        success: function (data) {

                            console.log(data);

                            $.each(data, function (i, value) {
                                $(""#mun_DepIdEdit"").append(""<option value='"" + value.dep_ID + ""'>"" + value.dep_Descripcion + ""</option>"");
                            })



                        }
                    })

                }

            })


        }



    </script>

    <script>

        function Editar() {


            var mun_Descripcion = $(""#mun_DescripcionEdit"").val();
            var mun_Id = $(""#mun_IdEdit"").val();
            var mun_DepId = $(""#mun_DepIdEdit"").val();


            $.ajax({
                url: ""/Municipios/Editar");
            WriteLiteral(@"/"" + mun_Id + ""/"" + mun_Descripcion + ""/"" + mun_DepId,
                method: ""GET"",
                dataType: ""json"",
                contentType: ""application/json; charset=utf-8"",

                success: function (data) {

                    if ($(""#mun_DescripcionEdit"").val() == """") {
                        mostrarErrorToast(""Campos requeridos."");
                    }
                    if ($(""#mun_DepIdEdit"").val() == 0 || $(""#mun_DepIdEdit"").val() == undefined) {
                        mostrarErrorToast(""Campos requeridos."");
                    }
                    else {
                        $('#EditMun').submit();
                        mostrarInfoToast(""Se ha modificado el registro."")
                    }
                }

            })




        }

    </script>
");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IEnumerable<Maquillaje.WebUI.Models.MunicipiosViewModel>> Html { get; private set; }
    }
}
#pragma warning restore 1591
