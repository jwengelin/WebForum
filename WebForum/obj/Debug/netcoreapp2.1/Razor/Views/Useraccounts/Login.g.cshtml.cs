#pragma checksum "C:\Users\Joelw\Desktop\Git\WebForum\WebForum\Views\Useraccounts\Login.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "d1ec1e08e3338e02280c11f3c93cdb398f056d8c"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Useraccounts_Login), @"mvc.1.0.view", @"/Views/Useraccounts/Login.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/Useraccounts/Login.cshtml", typeof(AspNetCore.Views_Useraccounts_Login))]
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
#line 1 "C:\Users\Joelw\Desktop\Git\WebForum\WebForum\Views\_ViewImports.cshtml"
using WebForum;

#line default
#line hidden
#line 2 "C:\Users\Joelw\Desktop\Git\WebForum\WebForum\Views\_ViewImports.cshtml"
using WebForum.Models;

#line default
#line hidden
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"d1ec1e08e3338e02280c11f3c93cdb398f056d8c", @"/Views/Useraccounts/Login.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"6b71a28f3a7af09787c62261f1cdb0b8d415dc6e", @"/Views/_ViewImports.cshtml")]
    public class Views_Useraccounts_Login : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<WebForum.Models.DB.UserAccounts>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Index", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-controller", "Home", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
            BeginContext(40, 75, true);
            WriteLiteral("\r\n\r\n<h1>\r\n    Login\r\n</h1>\r\n<div class=\"row\">\r\n    <div class=\"col-md-4\">\r\n");
            EndContext();
#line 9 "C:\Users\Joelw\Desktop\Git\WebForum\WebForum\Views\Useraccounts\Login.cshtml"
         using (Html.BeginForm("LoginForm", "UserAccounts", FormMethod.Post))
        {

#line default
#line hidden
            BeginContext(205, 81, true);
            WriteLiteral("            <div class=\"form-group\">\r\n                <div>\r\n                    ");
            EndContext();
            BeginContext(287, 33, false);
#line 13 "C:\Users\Joelw\Desktop\Git\WebForum\WebForum\Views\Useraccounts\Login.cshtml"
               Write(Html.LabelFor(m => m.AccountName));

#line default
#line hidden
            EndContext();
            BeginContext(320, 42, true);
            WriteLiteral("\r\n                </div>\r\n                ");
            EndContext();
            BeginContext(363, 35, false);
#line 15 "C:\Users\Joelw\Desktop\Git\WebForum\WebForum\Views\Useraccounts\Login.cshtml"
           Write(Html.TextBoxFor(m => m.AccountName));

#line default
#line hidden
            EndContext();
            BeginContext(398, 103, true);
            WriteLiteral("\r\n            </div>\r\n            <div class=\"form-group\">\r\n                <div>\r\n                    ");
            EndContext();
            BeginContext(502, 37, false);
#line 19 "C:\Users\Joelw\Desktop\Git\WebForum\WebForum\Views\Useraccounts\Login.cshtml"
               Write(Html.LabelFor(m => m.AccountPassword));

#line default
#line hidden
            EndContext();
            BeginContext(539, 44, true);
            WriteLiteral("\r\n                </div>\r\n\r\n                ");
            EndContext();
            BeginContext(584, 40, false);
#line 22 "C:\Users\Joelw\Desktop\Git\WebForum\WebForum\Views\Useraccounts\Login.cshtml"
           Write(Html.PasswordFor(m => m.AccountPassword));

#line default
#line hidden
            EndContext();
            BeginContext(624, 159, true);
            WriteLiteral("\r\n            </div>\r\n            <div class=\"form-group\">\r\n                <input type=\"submit\" value=\"Login\" class=\"btn btn-default\" />\r\n            </div>\r\n");
            EndContext();
#line 27 "C:\Users\Joelw\Desktop\Git\WebForum\WebForum\Views\Useraccounts\Login.cshtml"
        }

#line default
#line hidden
            BeginContext(794, 39, true);
            WriteLiteral("    </div>\r\n</div>\r\n\r\n\r\n\r\n\r\n<div>\r\n    ");
            EndContext();
            BeginContext(833, 60, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "3bcc9c8600b9473fa555492715abcdd1", async() => {
                BeginContext(877, 12, true);
                WriteLiteral("Back to Home");
                EndContext();
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_0.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Controller = (string)__tagHelperAttribute_1.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(893, 12, true);
            WriteLiteral("\r\n</div>\r\n\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<WebForum.Models.DB.UserAccounts> Html { get; private set; }
    }
}
#pragma warning restore 1591
