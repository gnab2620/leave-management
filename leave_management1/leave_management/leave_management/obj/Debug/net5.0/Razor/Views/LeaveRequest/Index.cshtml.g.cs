#pragma checksum "C:\Users\PTG\Desktop\Fresher.Net\EntityFramework\leave_management\leave_management\leave_management\Views\LeaveRequest\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "e3494ce95456ed3653e8fe3f5d30bfd7ce0e9674"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_LeaveRequest_Index), @"mvc.1.0.view", @"/Views/LeaveRequest/Index.cshtml")]
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
#line 1 "C:\Users\PTG\Desktop\Fresher.Net\EntityFramework\leave_management\leave_management\leave_management\Views\_ViewImports.cshtml"
using leave_management;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\PTG\Desktop\Fresher.Net\EntityFramework\leave_management\leave_management\leave_management\Views\_ViewImports.cshtml"
using leave_management.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"e3494ce95456ed3653e8fe3f5d30bfd7ce0e9674", @"/Views/LeaveRequest/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"00e77ddfc85c045f6de54f7f6f5b70fff5cde1b1", @"/Views/_ViewImports.cshtml")]
    public class Views_LeaveRequest_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<leave_management.Models.AdminViewLeaveRequestVM>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("btn btn-outline-primary"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
#line 3 "C:\Users\PTG\Desktop\Fresher.Net\EntityFramework\leave_management\leave_management\leave_management\Views\LeaveRequest\Index.cshtml"
  
    ViewData["Title"] = "Index";
    

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n<h1>Index</h1>\r\n\r\n\r\n<div class=\"row\">\r\n    <div class=\"col-md-3\">\r\n        <div class=\"card\" style=\"width: 18rem;\">\r\n            <div class=\"card-body text-center\">\r\n                <h5 class=\"card-title\">");
#nullable restore
#line 15 "C:\Users\PTG\Desktop\Fresher.Net\EntityFramework\leave_management\leave_management\leave_management\Views\LeaveRequest\Index.cshtml"
                                  Write(Model.TotalRequests);

#line default
#line hidden
#nullable disable
            WriteLiteral("</h5>\r\n                <p class=\"card-text\">");
#nullable restore
#line 16 "C:\Users\PTG\Desktop\Fresher.Net\EntityFramework\leave_management\leave_management\leave_management\Views\LeaveRequest\Index.cshtml"
                                Write(Html.DisplayNameFor(model => model.TotalRequests));

#line default
#line hidden
#nullable disable
            WriteLiteral("</p>\r\n            </div>\r\n        </div>\r\n    </div>\r\n    <div class=\"col-md-3\">\r\n        <div class=\"card\" style=\"width: 18rem;\">\r\n            <div class=\"card-body text-center\">\r\n                <h5 class=\"card-title text-success\">");
#nullable restore
#line 23 "C:\Users\PTG\Desktop\Fresher.Net\EntityFramework\leave_management\leave_management\leave_management\Views\LeaveRequest\Index.cshtml"
                                               Write(Model.ApproveRequests);

#line default
#line hidden
#nullable disable
            WriteLiteral("</h5>\r\n                <p class=\"card-text\">");
#nullable restore
#line 24 "C:\Users\PTG\Desktop\Fresher.Net\EntityFramework\leave_management\leave_management\leave_management\Views\LeaveRequest\Index.cshtml"
                                Write(Html.DisplayNameFor(model => model.ApproveRequests));

#line default
#line hidden
#nullable disable
            WriteLiteral("</p>\r\n            </div>\r\n        </div>\r\n    </div>\r\n    <div class=\"col-md-3\">\r\n        <div class=\"card\" style=\"width: 18rem;\">\r\n            <div class=\"card-body text-center\">\r\n                <h5 class=\"card-title text-warning\">");
#nullable restore
#line 31 "C:\Users\PTG\Desktop\Fresher.Net\EntityFramework\leave_management\leave_management\leave_management\Views\LeaveRequest\Index.cshtml"
                                               Write(Model.PendingRequests);

#line default
#line hidden
#nullable disable
            WriteLiteral("</h5>\r\n                <p class=\"card-text\">");
#nullable restore
#line 32 "C:\Users\PTG\Desktop\Fresher.Net\EntityFramework\leave_management\leave_management\leave_management\Views\LeaveRequest\Index.cshtml"
                                Write(Html.DisplayNameFor(model => model.PendingRequests));

#line default
#line hidden
#nullable disable
            WriteLiteral("</p>\r\n            </div>\r\n        </div>\r\n    </div>\r\n    <div class=\"col-md-3\">\r\n        <div class=\"card\" style=\"width: 18rem;\">\r\n            <div class=\"card-body text-center\">\r\n                <h5 class=\"card-title text-danger\">");
#nullable restore
#line 39 "C:\Users\PTG\Desktop\Fresher.Net\EntityFramework\leave_management\leave_management\leave_management\Views\LeaveRequest\Index.cshtml"
                                              Write(Model.RejectRequests);

#line default
#line hidden
#nullable disable
            WriteLiteral("</h5>\r\n                <p class=\"card-text\">");
#nullable restore
#line 40 "C:\Users\PTG\Desktop\Fresher.Net\EntityFramework\leave_management\leave_management\leave_management\Views\LeaveRequest\Index.cshtml"
                                Write(Html.DisplayNameFor(model => model.RejectRequests));

#line default
#line hidden
#nullable disable
            WriteLiteral(@"</p>
            </div>
        </div>
    </div>
</div>
<br/>
<br/>
<hr/>
<h1>Leave Request Log</h1>
<hr/>
<table id=""tblData"" class=""table"">
    <thead>
        <tr>
            <th>
                Employee Name
            </th>
            <th>
                Start Date
            </th>
            <th>
                End Date
            </th>
            <th>
                Leave Type
            </th>
            <th>
                Date Requested
            </th>
            <th>
                Approval Status
            </th>

            <th></th>
        </tr>
    </thead>
    <tbody>
");
#nullable restore
#line 76 "C:\Users\PTG\Desktop\Fresher.Net\EntityFramework\leave_management\leave_management\leave_management\Views\LeaveRequest\Index.cshtml"
         foreach (var item in Model.LeaveRequests)
        {

#line default
#line hidden
#nullable disable
            WriteLiteral("            <tr>\r\n                <td>\r\n                    ");
#nullable restore
#line 80 "C:\Users\PTG\Desktop\Fresher.Net\EntityFramework\leave_management\leave_management\leave_management\Views\LeaveRequest\Index.cshtml"
               Write(Html.DisplayFor(modelItem => item.RequestingEmployee.FirstName));

#line default
#line hidden
#nullable disable
            WriteLiteral(" ");
#nullable restore
#line 80 "C:\Users\PTG\Desktop\Fresher.Net\EntityFramework\leave_management\leave_management\leave_management\Views\LeaveRequest\Index.cshtml"
                                                                                Write(Html.DisplayFor(modelItem => item.RequestingEmployee.LastName));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                </td>\r\n                <td>\r\n                    ");
#nullable restore
#line 83 "C:\Users\PTG\Desktop\Fresher.Net\EntityFramework\leave_management\leave_management\leave_management\Views\LeaveRequest\Index.cshtml"
               Write(Html.DisplayFor(modelItem => item.StartDate));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                </td>\r\n                <td>\r\n                    ");
#nullable restore
#line 86 "C:\Users\PTG\Desktop\Fresher.Net\EntityFramework\leave_management\leave_management\leave_management\Views\LeaveRequest\Index.cshtml"
               Write(Html.DisplayFor(modelItem => item.EndDate));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                </td>\r\n                <td>\r\n                    ");
#nullable restore
#line 89 "C:\Users\PTG\Desktop\Fresher.Net\EntityFramework\leave_management\leave_management\leave_management\Views\LeaveRequest\Index.cshtml"
               Write(Html.DisplayFor(modelItem => item.LeaveType.Name));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                </td>\r\n                <td>\r\n                    ");
#nullable restore
#line 92 "C:\Users\PTG\Desktop\Fresher.Net\EntityFramework\leave_management\leave_management\leave_management\Views\LeaveRequest\Index.cshtml"
               Write(Html.DisplayFor(modelItem => item.DateRequest));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                </td>\r\n\r\n                <td>\r\n");
#nullable restore
#line 96 "C:\Users\PTG\Desktop\Fresher.Net\EntityFramework\leave_management\leave_management\leave_management\Views\LeaveRequest\Index.cshtml"
                     if (item.Approved == true)
                    {

#line default
#line hidden
#nullable disable
            WriteLiteral("                        <span class=\"badge badge-success\">Approved</span>\r\n");
#nullable restore
#line 99 "C:\Users\PTG\Desktop\Fresher.Net\EntityFramework\leave_management\leave_management\leave_management\Views\LeaveRequest\Index.cshtml"
                    }
                    else if (item.Approved == false)
                    {

#line default
#line hidden
#nullable disable
            WriteLiteral("                        <span class=\"badge badge-danger\">Rejected</span>\r\n");
#nullable restore
#line 103 "C:\Users\PTG\Desktop\Fresher.Net\EntityFramework\leave_management\leave_management\leave_management\Views\LeaveRequest\Index.cshtml"
                    }
                    else
                    {

#line default
#line hidden
#nullable disable
            WriteLiteral("                        <span class=\"badge badge-warning\">Pending</span>\r\n");
#nullable restore
#line 107 "C:\Users\PTG\Desktop\Fresher.Net\EntityFramework\leave_management\leave_management\leave_management\Views\LeaveRequest\Index.cshtml"
                    }

#line default
#line hidden
#nullable disable
            WriteLiteral("                </td>\r\n\r\n                <td>\r\n                    ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "e3494ce95456ed3653e8fe3f5d30bfd7ce0e967412968", async() => {
                WriteLiteral("\r\n                        <i class=\"fa fa-file\"></i>\r\n                        Reviews\r\n                    ");
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
#line 111 "C:\Users\PTG\Desktop\Fresher.Net\EntityFramework\leave_management\leave_management\leave_management\Views\LeaveRequest\Index.cshtml"
                                                                              WriteLiteral(item.Id);

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
            WriteLiteral("\r\n            </tr>\r\n");
#nullable restore
#line 116 "C:\Users\PTG\Desktop\Fresher.Net\EntityFramework\leave_management\leave_management\leave_management\Views\LeaveRequest\Index.cshtml"
        }

#line default
#line hidden
#nullable disable
            WriteLiteral("    </tbody>\r\n</table>");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<leave_management.Models.AdminViewLeaveRequestVM> Html { get; private set; }
    }
}
#pragma warning restore 1591
