#pragma checksum "C:\Users\Familia\Documents\especializacion\1er-semestre\informatica-1\ProyectoWeb\ProyectoApiCore.Web\Views\Actividades\Details.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "bf3b9cd7fa77cb1a9719f3069a4d86e5ab08ff19"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Actividades_Details), @"mvc.1.0.view", @"/Views/Actividades/Details.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/Actividades/Details.cshtml", typeof(AspNetCore.Views_Actividades_Details))]
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
#line 1 "C:\Users\Familia\Documents\especializacion\1er-semestre\informatica-1\ProyectoWeb\ProyectoApiCore.Web\Views\_ViewImports.cshtml"
using ProyectoApiCore.Web;

#line default
#line hidden
#line 2 "C:\Users\Familia\Documents\especializacion\1er-semestre\informatica-1\ProyectoWeb\ProyectoApiCore.Web\Views\_ViewImports.cshtml"
using ProyectoApiCore.Web.Models;

#line default
#line hidden
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"bf3b9cd7fa77cb1a9719f3069a4d86e5ab08ff19", @"/Views/Actividades/Details.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"c6d54e694895f3f16527c3ff8c6fe6612e14395e", @"/Views/_ViewImports.cshtml")]
    public class Views_Actividades_Details : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<ProyectoApiCore.Web.Actividades>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Edit", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Index", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        #line hidden
        #pragma warning disable 0169
        private string __tagHelperStringValueBuffer;
        #pragma warning restore 0169
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperExecutionContext __tagHelperExecutionContext;
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner __tagHelperRunner = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner();
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
            BeginContext(40, 2, true);
            WriteLiteral("\r\n");
            EndContext();
#line 3 "C:\Users\Familia\Documents\especializacion\1er-semestre\informatica-1\ProyectoWeb\ProyectoApiCore.Web\Views\Actividades\Details.cshtml"
  
    ViewData["Title"] = "Details";
    Layout = "~/Views/Shared/_Layout.cshtml";

#line default
#line hidden
            BeginContext(132, 134, true);
            WriteLiteral("\r\n<h1>Details</h1>\r\n\r\n<div>\r\n    <h4>Actividades</h4>\r\n    <hr />\r\n    <dl class=\"row\">\r\n        <dt class = \"col-sm-2\">\r\n            ");
            EndContext();
            BeginContext(267, 51, false);
#line 15 "C:\Users\Familia\Documents\especializacion\1er-semestre\informatica-1\ProyectoWeb\ProyectoApiCore.Web\Views\Actividades\Details.cshtml"
       Write(Html.DisplayNameFor(model => model.nombreActividad));

#line default
#line hidden
            EndContext();
            BeginContext(318, 63, true);
            WriteLiteral("\r\n        </dt>\r\n        <dd class = \"col-sm-10\">\r\n            ");
            EndContext();
            BeginContext(382, 47, false);
#line 18 "C:\Users\Familia\Documents\especializacion\1er-semestre\informatica-1\ProyectoWeb\ProyectoApiCore.Web\Views\Actividades\Details.cshtml"
       Write(Html.DisplayFor(model => model.nombreActividad));

#line default
#line hidden
            EndContext();
            BeginContext(429, 62, true);
            WriteLiteral("\r\n        </dd>\r\n        <dt class = \"col-sm-2\">\r\n            ");
            EndContext();
            BeginContext(492, 56, false);
#line 21 "C:\Users\Familia\Documents\especializacion\1er-semestre\informatica-1\ProyectoWeb\ProyectoApiCore.Web\Views\Actividades\Details.cshtml"
       Write(Html.DisplayNameFor(model => model.descripcionActividad));

#line default
#line hidden
            EndContext();
            BeginContext(548, 63, true);
            WriteLiteral("\r\n        </dt>\r\n        <dd class = \"col-sm-10\">\r\n            ");
            EndContext();
            BeginContext(612, 52, false);
#line 24 "C:\Users\Familia\Documents\especializacion\1er-semestre\informatica-1\ProyectoWeb\ProyectoApiCore.Web\Views\Actividades\Details.cshtml"
       Write(Html.DisplayFor(model => model.descripcionActividad));

#line default
#line hidden
            EndContext();
            BeginContext(664, 62, true);
            WriteLiteral("\r\n        </dd>\r\n        <dt class = \"col-sm-2\">\r\n            ");
            EndContext();
            BeginContext(727, 47, false);
#line 27 "C:\Users\Familia\Documents\especializacion\1er-semestre\informatica-1\ProyectoWeb\ProyectoApiCore.Web\Views\Actividades\Details.cshtml"
       Write(Html.DisplayNameFor(model => model.fechaInicio));

#line default
#line hidden
            EndContext();
            BeginContext(774, 63, true);
            WriteLiteral("\r\n        </dt>\r\n        <dd class = \"col-sm-10\">\r\n            ");
            EndContext();
            BeginContext(838, 43, false);
#line 30 "C:\Users\Familia\Documents\especializacion\1er-semestre\informatica-1\ProyectoWeb\ProyectoApiCore.Web\Views\Actividades\Details.cshtml"
       Write(Html.DisplayFor(model => model.fechaInicio));

#line default
#line hidden
            EndContext();
            BeginContext(881, 62, true);
            WriteLiteral("\r\n        </dd>\r\n        <dt class = \"col-sm-2\">\r\n            ");
            EndContext();
            BeginContext(944, 44, false);
#line 33 "C:\Users\Familia\Documents\especializacion\1er-semestre\informatica-1\ProyectoWeb\ProyectoApiCore.Web\Views\Actividades\Details.cshtml"
       Write(Html.DisplayNameFor(model => model.fechaFin));

#line default
#line hidden
            EndContext();
            BeginContext(988, 63, true);
            WriteLiteral("\r\n        </dt>\r\n        <dd class = \"col-sm-10\">\r\n            ");
            EndContext();
            BeginContext(1052, 40, false);
#line 36 "C:\Users\Familia\Documents\especializacion\1er-semestre\informatica-1\ProyectoWeb\ProyectoApiCore.Web\Views\Actividades\Details.cshtml"
       Write(Html.DisplayFor(model => model.fechaFin));

#line default
#line hidden
            EndContext();
            BeginContext(1092, 47, true);
            WriteLiteral("\r\n        </dd>\r\n    </dl>\r\n</div>\r\n<div>\r\n    ");
            EndContext();
            BeginContext(1139, 63, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "bf3b9cd7fa77cb1a9719f3069a4d86e5ab08ff198388", async() => {
                BeginContext(1194, 4, true);
                WriteLiteral("Edit");
                EndContext();
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_0.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
            if (__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
            {
                throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-id", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
            }
            BeginWriteTagHelperAttribute();
#line 41 "C:\Users\Familia\Documents\especializacion\1er-semestre\informatica-1\ProyectoWeb\ProyectoApiCore.Web\Views\Actividades\Details.cshtml"
                           WriteLiteral(Model.idActividad);

#line default
#line hidden
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
            EndContext();
            BeginContext(1202, 8, true);
            WriteLiteral(" |\r\n    ");
            EndContext();
            BeginContext(1210, 38, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "bf3b9cd7fa77cb1a9719f3069a4d86e5ab08ff1910773", async() => {
                BeginContext(1232, 12, true);
                WriteLiteral("Back to List");
                EndContext();
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_1.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(1248, 10, true);
            WriteLiteral("\r\n</div>\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<ProyectoApiCore.Web.Actividades> Html { get; private set; }
    }
}
#pragma warning restore 1591
