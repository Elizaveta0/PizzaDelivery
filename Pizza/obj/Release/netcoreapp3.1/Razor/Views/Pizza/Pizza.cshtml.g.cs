#pragma checksum "C:\user\study\liza\PizzaDelivery\Pizza\Views\Pizza\Pizza.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "952ec269205da751d168b2401108e2203638c48c"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Pizza_Pizza), @"mvc.1.0.view", @"/Views/Pizza/Pizza.cshtml")]
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
#line 1 "C:\user\study\liza\PizzaDelivery\Pizza\Views\_ViewImports.cshtml"
using Pizza;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\user\study\liza\PizzaDelivery\Pizza\Views\_ViewImports.cshtml"
using Pizza.Models;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "C:\user\study\liza\PizzaDelivery\Pizza\Views\_ViewImports.cshtml"
using Pizza.Models.ViewModels;

#line default
#line hidden
#nullable disable
#nullable restore
#line 4 "C:\user\study\liza\PizzaDelivery\Pizza\Views\_ViewImports.cshtml"
using Pizza.Models.Enums;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"952ec269205da751d168b2401108e2203638c48c", @"/Views/Pizza/Pizza.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"1aff9aa9e4641f21205e726326b681402d8a56f2", @"/Views/_ViewImports.cshtml")]
    public class Views_Pizza_Pizza : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<Pizza>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "AddToCart", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-controller", "Pizza", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("id", new global::Microsoft.AspNetCore.Html.HtmlString("form"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("method", "post", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.OptionTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n<h1>");
#nullable restore
#line 3 "C:\user\study\liza\PizzaDelivery\Pizza\Views\Pizza\Pizza.cshtml"
Write(Model.Name);

#line default
#line hidden
#nullable disable
            WriteLiteral("</h1>\r\n<h2>");
#nullable restore
#line 4 "C:\user\study\liza\PizzaDelivery\Pizza\Views\Pizza\Pizza.cshtml"
Write(Model.Description);

#line default
#line hidden
#nullable disable
            WriteLiteral("</h2>\r\n\r\n");
#nullable restore
#line 6 "C:\user\study\liza\PizzaDelivery\Pizza\Views\Pizza\Pizza.cshtml"
 foreach (var p in Model.Prices)
{
    if (p.SizePrice != 0)
    {

#line default
#line hidden
#nullable disable
            WriteLiteral("        <div style=\"display:none;\"");
            BeginWriteAttribute("name", " name=\"", 174, "\"", 186, 1);
#nullable restore
#line 10 "C:\user\study\liza\PizzaDelivery\Pizza\Views\Pizza\Pizza.cshtml"
WriteAttributeValue("", 181, p.Id, 181, 5, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(">\r\n            <p>$ ");
#nullable restore
#line 11 "C:\user\study\liza\PizzaDelivery\Pizza\Views\Pizza\Pizza.cshtml"
            Write(p.SizePrice.ToString("N2"));

#line default
#line hidden
#nullable disable
            WriteLiteral("</p>\r\n        </div>\r\n");
#nullable restore
#line 13 "C:\user\study\liza\PizzaDelivery\Pizza\Views\Pizza\Pizza.cshtml"
    }
}

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "952ec269205da751d168b2401108e2203638c48c6390", async() => {
                WriteLiteral("\r\n    <select id=\"select\">\r\n");
#nullable restore
#line 18 "C:\user\study\liza\PizzaDelivery\Pizza\Views\Pizza\Pizza.cshtml"
         foreach (var p in Model.Prices)
        {
            

#line default
#line hidden
#nullable disable
#nullable restore
#line 20 "C:\user\study\liza\PizzaDelivery\Pizza\Views\Pizza\Pizza.cshtml"
             if (p.SizePrice != 0)
            {

#line default
#line hidden
#nullable disable
                WriteLiteral("                ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("option", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "952ec269205da751d168b2401108e2203638c48c7137", async() => {
#nullable restore
#line 22 "C:\user\study\liza\PizzaDelivery\Pizza\Views\Pizza\Pizza.cshtml"
                                 Write(p.Size);

#line default
#line hidden
#nullable disable
                }
                );
                __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.OptionTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper);
                BeginWriteTagHelperAttribute();
#nullable restore
#line 22 "C:\user\study\liza\PizzaDelivery\Pizza\Views\Pizza\Pizza.cshtml"
                   WriteLiteral(p.Id);

#line default
#line hidden
#nullable disable
                __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
                __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper.Value = __tagHelperStringValueBuffer;
                __tagHelperExecutionContext.AddTagHelperAttribute("value", __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper.Value, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                WriteLiteral("\r\n");
#nullable restore
#line 23 "C:\user\study\liza\PizzaDelivery\Pizza\Views\Pizza\Pizza.cshtml"
            }

#line default
#line hidden
#nullable disable
#nullable restore
#line 23 "C:\user\study\liza\PizzaDelivery\Pizza\Views\Pizza\Pizza.cshtml"
             
        }

#line default
#line hidden
#nullable disable
                WriteLiteral("    </select>\r\n    <input type=\"number\" placeholder=\"Qty\" id=\"qty\">\r\n    <button id=\"submit\" type=\"submit\">Add To Cart</button>\r\n");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Action = (string)__tagHelperAttribute_0.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Controller = (string)__tagHelperAttribute_1.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
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
            WriteLiteral(@"



<script>
    const select = document.getElementById('select');
    let result = document.getElementsByName(select.value)[0];
    result.style = 'display:normal;'
    let prev_result = result;
    select.addEventListener('change', (e) => {
        const value = select.value;
        const result = document.getElementsByName(value)[0];
        prev_result.style = 'display: none;';
        result.style = 'display: normal';
        prev_result = result;
    })
    const form = document.getElementById('form')
    const button = document.getElementById('submit');
    button.addEventListener('click', (e) => {
        form.setAttribute('action', '/Pizza/AddToCart?id=' + select.value + '&qty=' + document.getElementById('qty').value)
    })
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<Pizza> Html { get; private set; }
    }
}
#pragma warning restore 1591