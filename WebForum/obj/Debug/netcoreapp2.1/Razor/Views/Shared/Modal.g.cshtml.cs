#pragma checksum "C:\Users\Joelw\Desktop\Git\WebForum\WebForum\Views\Shared\Modal.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "1ee981968681681f1dcd7e887f98a51cbb1c04f1"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Shared_Modal), @"mvc.1.0.view", @"/Views/Shared/Modal.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/Shared/Modal.cshtml", typeof(AspNetCore.Views_Shared_Modal))]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"1ee981968681681f1dcd7e887f98a51cbb1c04f1", @"/Views/Shared/Modal.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"6b71a28f3a7af09787c62261f1cdb0b8d415dc6e", @"/Views/_ViewImports.cshtml")]
    public class Views_Shared_Modal : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<WebForum.Models.DB.UserAccounts>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            BeginContext(40, 860, true);
            WriteLiteral(@"


<script src=""https://cdnjs.cloudflare.com/ajax/libs/jquery/2.1.4/jquery.min.js""></script>
<script src=""https://cdnjs.cloudflare.com/ajax/libs/twitter-bootstrap/3.0.1/js/bootstrap.min.js""></script>
<link href=""https://cdnjs.cloudflare.com/ajax/libs/twitter-bootstrap/3.0.1/css/bootstrap.min.css"" rel=""stylesheet"" />


<div class=""modal"" tabindex=""-1"" role=""dialog"" id=""myModal"">
    <div class=""modal-dialog"" role=""document"">
        <div class=""modal-content"">
            <div class=""modal-header"">
                <h5 class=""modal-title"">Login Successfull!</h5>
                <button type=""button"" class=""close"" data-dismiss=""modal"" aria-label=""Close"">
                    <span aria-hidden=""true"">&times;</span>
                </button>
            </div>
            <div class=""modal-body"">
                <p>You are logged in as ");
            EndContext();
            BeginContext(901, 12, false);
#line 20 "C:\Users\Joelw\Desktop\Git\WebForum\WebForum\Views\Shared\Modal.cshtml"
                                   Write(ViewBag.Name);

#line default
#line hidden
            EndContext();
            BeginContext(913, 329, true);
            WriteLiteral(@"</p>
            </div>
            <div class=""modal-footer"">
                <button type=""button"" class=""btn btn-secondary"" data-dismiss=""modal"">Close</button>
            </div>
        </div>
    </div>
</div>

<script>
    $(window).load(function () {
        $('#myModal').modal('show');
    });
</script>

");
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
