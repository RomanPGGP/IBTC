#pragma checksum "C:\Users\USER 15\source\repos\WRKT\WRKT\Views\Employee\PostHour.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "ea21e4a507aa038687e204dd30c858eb90352ef6"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Employee_PostHour), @"mvc.1.0.view", @"/Views/Employee/PostHour.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/Employee/PostHour.cshtml", typeof(AspNetCore.Views_Employee_PostHour))]
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
#line 1 "C:\Users\USER 15\source\repos\WRKT\WRKT\Views\_ViewImports.cshtml"
using WRKT;

#line default
#line hidden
#line 2 "C:\Users\USER 15\source\repos\WRKT\WRKT\Views\_ViewImports.cshtml"
using WRKT.Models;

#line default
#line hidden
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"ea21e4a507aa038687e204dd30c858eb90352ef6", @"/Views/Employee/PostHour.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"2e8e231f93b72930a0339be9cf220cca2c2eb6ad", @"/Views/_ViewImports.cshtml")]
    public class Views_Employee_PostHour : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<DateTime>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#line 2 "C:\Users\USER 15\source\repos\WRKT\WRKT\Views\Employee\PostHour.cshtml"
  
    ViewData["Title"] = "PostHour";

#line default
#line hidden
            BeginContext(61, 33, true);
            WriteLiteral("\r\n<h2>Post Hours Worked!</h2>\r\n\r\n");
            EndContext();
#line 8 "C:\Users\USER 15\source\repos\WRKT\WRKT\Views\Employee\PostHour.cshtml"
 using (Html.BeginForm("postWorkedHours", "Employee"))
{

#line default
#line hidden
            BeginContext(153, 10, true);
            WriteLiteral("    <div> ");
            EndContext();
            BeginContext(164, 10, false);
#line 10 "C:\Users\USER 15\source\repos\WRKT\WRKT\Views\Employee\PostHour.cshtml"
     Write(Model.Date);

#line default
#line hidden
            EndContext();
            BeginContext(174, 50, true);
            WriteLiteral("</div>\r\n    <div>\r\n        <label name=\"dateToday\"");
            EndContext();
            BeginWriteAttribute("value", " value=", 224, "", 242, 1);
#line 12 "C:\Users\USER 15\source\repos\WRKT\WRKT\Views\Employee\PostHour.cshtml"
WriteAttributeValue("", 231, Model.Date, 231, 11, false);

#line default
#line hidden
            EndWriteAttribute();
            BeginContext(242, 379, true);
            WriteLiteral(@"></label>
    </div>
    <div>
        <label>Start Hour:</label>
        <input type=""time"" id=""appt"" name=""startHour"" required>
    </div>
    <div>
        <label>End Hour:</label>
        <input type=""time"" id=""appt"" name=""endHour"" required>
    </div>
    <div>
        <label>Venue ID:</label>
        <input type=""text"" name=""venue"" value=""12"" />
    </div>
");
            EndContext();
            BeginContext(623, 58, true);
            WriteLiteral("    <input type=\"submit\" name=\"upload\" value=\"Submit\" />\r\n");
            EndContext();
#line 28 "C:\Users\USER 15\source\repos\WRKT\WRKT\Views\Employee\PostHour.cshtml"
}

#line default
#line hidden
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<DateTime> Html { get; private set; }
    }
}
#pragma warning restore 1591