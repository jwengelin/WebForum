#pragma checksum "C:\Users\Joelw\Desktop\Git\WebForum\WebForum\Views\Thread\Posts.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "3a9a1565633e269b0c6bb1c457fd5d39ff0bf82d"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Thread_Posts), @"mvc.1.0.view", @"/Views/Thread/Posts.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/Thread/Posts.cshtml", typeof(AspNetCore.Views_Thread_Posts))]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"3a9a1565633e269b0c6bb1c457fd5d39ff0bf82d", @"/Views/Thread/Posts.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"6b71a28f3a7af09787c62261f1cdb0b8d415dc6e", @"/Views/_ViewImports.cshtml")]
    public class Views_Thread_Posts : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable<WebForum.Models.PostsViewModel>>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            BeginContext(52, 66, true);
            WriteLiteral("\r\n<h1>\r\n    Posts\r\n</h1>\r\n\r\n\r\n<table class=\"table\">\r\n    <tbody>\r\n");
            EndContext();
#line 10 "C:\Users\Joelw\Desktop\Git\WebForum\WebForum\Views\Thread\Posts.cshtml"
         foreach (var item in Model)
        {

#line default
#line hidden
            BeginContext(167, 77, true);
            WriteLiteral("            <tr>\r\n                <td class=\"col-sm-3\">\r\n                    ");
            EndContext();
            BeginContext(245, 47, false);
#line 14 "C:\Users\Joelw\Desktop\Git\WebForum\WebForum\Views\Thread\Posts.cshtml"
               Write(Html.DisplayFor(m => item.Post.PostDescription));

#line default
#line hidden
            EndContext();
            BeginContext(292, 77, true);
            WriteLiteral("\r\n                </td>\r\n                <td>\r\n                    Posted by:");
            EndContext();
            BeginContext(370, 50, false);
#line 17 "C:\Users\Joelw\Desktop\Git\WebForum\WebForum\Views\Thread\Posts.cshtml"
                         Write(Html.DisplayFor(m => item.UserAccount.AccountName));

#line default
#line hidden
            EndContext();
            BeginContext(420, 67, true);
            WriteLiteral("\r\n                </td>\r\n                <td>\r\n                    ");
            EndContext();
            BeginContext(488, 42, false);
#line 20 "C:\Users\Joelw\Desktop\Git\WebForum\WebForum\Views\Thread\Posts.cshtml"
               Write(Html.DisplayFor(m => item.Post.DatePosted));

#line default
#line hidden
            EndContext();
            BeginContext(530, 67, true);
            WriteLiteral("\r\n                </td>\r\n                <td>\r\n                    ");
            EndContext();
            BeginContext(598, 118, false);
#line 23 "C:\Users\Joelw\Desktop\Git\WebForum\WebForum\Views\Thread\Posts.cshtml"
               Write(Html.ActionLink("Reply", "Reply", "Thread", new { threadId = item.Post.ThreadId }, new { @class = "btn btn-default" }));

#line default
#line hidden
            EndContext();
            BeginContext(716, 67, true);
            WriteLiteral("\r\n                </td>\r\n                <td>\r\n                    ");
            EndContext();
            BeginContext(784, 156, false);
#line 26 "C:\Users\Joelw\Desktop\Git\WebForum\WebForum\Views\Thread\Posts.cshtml"
               Write(Html.ActionLink("Delete Post", "DeletePost", "Thread", new { postId = item.Post.PostId, threadId = item.Post.ThreadId }, new { @class = "btn btn-default" }));

#line default
#line hidden
            EndContext();
            BeginContext(940, 44, true);
            WriteLiteral("\r\n                </td>\r\n            </tr>\r\n");
            EndContext();
#line 29 "C:\Users\Joelw\Desktop\Git\WebForum\WebForum\Views\Thread\Posts.cshtml"
        }

#line default
#line hidden
            BeginContext(995, 30, true);
            WriteLiteral("\r\n    </tbody>\r\n</table>\r\n\r\n\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IEnumerable<WebForum.Models.PostsViewModel>> Html { get; private set; }
    }
}
#pragma warning restore 1591
