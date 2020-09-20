#pragma checksum "C:\Users\User\Desktop\ISO-master\ISOCertificate\Views\Investigate\Print.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "040c523b93bd4e6c933eb609772b9d0104fd00a1"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Investigate_Print), @"mvc.1.0.view", @"/Views/Investigate/Print.cshtml")]
namespace AspNetCore
{
    #line hidden
    using System;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Rendering;
    using Microsoft.AspNetCore.Mvc.ViewFeatures;
#nullable restore
#line 1 "C:\Users\User\Desktop\ISO-master\ISOCertificate\Views\_ViewImports.cshtml"
using ISOCertificate;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\User\Desktop\ISO-master\ISOCertificate\Views\_ViewImports.cshtml"
using ISOCertificate.Models;

#line default
#line hidden
#nullable disable
#nullable restore
#line 4 "C:\Users\User\Desktop\ISO-master\ISOCertificate\Views\_ViewImports.cshtml"
using System.Collections.Generic;

#line default
#line hidden
#nullable disable
#nullable restore
#line 5 "C:\Users\User\Desktop\ISO-master\ISOCertificate\Views\_ViewImports.cshtml"
using ISOCertificate.ViewModels.RequestOutputModels;

#line default
#line hidden
#nullable disable
#nullable restore
#line 6 "C:\Users\User\Desktop\ISO-master\ISOCertificate\Views\_ViewImports.cshtml"
using ISOCertificate.ViewModels.RequestInputModels;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"040c523b93bd4e6c933eb609772b9d0104fd00a1", @"/Views/Investigate/Print.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"7cfa29af22981194f275e2bb8ba970822a0b8c85", @"/Views/_ViewImports.cshtml")]
    public class Views_Investigate_Print : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("src", new global::Microsoft.AspNetCore.Html.HtmlString("~/assets/images/new-QCS-logo.png"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("alt", new global::Microsoft.AspNetCore.Html.HtmlString("error"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("style", new global::Microsoft.AspNetCore.Html.HtmlString("width: 104px;"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.HeadTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_HeadTagHelper;
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.BodyTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_BodyTagHelper;
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 1 "C:\Users\User\Desktop\ISO-master\ISOCertificate\Views\Investigate\Print.cshtml"
  
    Layout = null;

#line default
#line hidden
#nullable disable
#nullable restore
#line 4 "C:\Users\User\Desktop\ISO-master\ISOCertificate\Views\Investigate\Print.cshtml"
  
    string Id = "";
    string No = "";
    string BriefDecription = "";
    string IdentifyDescription = "";
    string OccurenceCause = "";
    string LessonLearned = "";
    string OutcomeBuisness = "";
    string OutcomeEnviroment = "";
    string OutcomePeople = "";
    string OutcomeProperty = "";
    string PossibleBuisness = "";
    string PossibleEnviroment = "";
    string PossiblePeople = "";
    string PossibleProperty = "";
    string ReasonDescription = "";

    foreach (var dr in ViewBag.BRheader)
    {
        Id = dr.Id.ToString();
        No = dr.No.ToString();
        BriefDecription = dr.BriefDecription.ToString();
        IdentifyDescription = dr.IdentifyDescription.ToString();
        LessonLearned = dr.LessonLearned.Name.ToString();
        OutcomeBuisness = dr.OutcomeBuisness.Name.ToString();
        OutcomeEnviroment = dr.OutcomeEnviroment.Name.ToString();
        OutcomePeople = dr.OutcomePeople.Name.ToString();
        OutcomeProperty = dr.OutcomeProperty.Name.ToString();
        PossibleBuisness = dr.PossibleBuisness.Name.ToString();
        PossibleEnviroment = dr.PossibleEnviroment.Name.ToString();
        PossiblePeople = dr.PossiblePeople.Name.ToString();
        PossibleProperty = dr.PossibleProperty.Name.ToString();
        ReasonDescription = dr.ReasonDescription.ToString();
        OccurenceCause = dr.OccurenceCause.Name.ToString();
    }

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n<!DOCTYPE html>\r\n");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("head", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "040c523b93bd4e6c933eb609772b9d0104fd00a16819", async() => {
                WriteLiteral(@"
    <meta charset=""UTF-8"">
    <meta name=""viewport"" content=""width=device-width, initial-scale=1.0"">
    <meta http-equiv=""X-UA-Compatible"" content=""ie=edge"">
    <title>Investgiate</title>
    <link href=""//maxcdn.bootstrapcdn.com/bootstrap/4.1.1/css/bootstrap.min.css"" rel=""stylesheet"" id=""bootstrap-css"">
    <script src=""//maxcdn.bootstrapcdn.com/bootstrap/4.1.1/js/bootstrap.min.js""></script>
    <script src=""//cdnjs.cloudflare.com/ajax/libs/jquery/3.2.1/jquery.min.js""></script>
    <script>
        //nom
        var url = ""/Investigate/DeliverNominatedLineFill_edit"";
        $.ajax({
            type: ""POST"",
            url: url,
            data: {
                id: ");
#nullable restore
#line 57 "C:\Users\User\Desktop\ISO-master\ISOCertificate\Views\Investigate\Print.cshtml"
               Write(Id);

#line default
#line hidden
#nullable disable
                WriteLiteral(@"
            },
            success: function (result) {
                var jsondata = $.parseJSON(result);
                var row = """";
                var table = $(""#nominated > tbody"");
                table.html("""");
                var index = 0;
                    //console.log(jsondata);
                    $.each(jsondata, function (j, e) {
                       index = parseInt(index + 1);
                       row += '<tr><td>' + index + '</td><td>' + e.Name + '</td><td>' + e.Position + '</td>'
                            + '<td>' + e.Organization + '</td><td>' + e.TeamType.Name + '</td></tr>';
                    });
                table.append(row);
                window.print();
            },
            error: function (e) {
                alert(e.responseText);
            }
        })

        //event
        var e_url = ""/Investigate/DeliverEventLineFill_edit"";
        $.ajax({
            type: ""POST"",
            url: e_url,
            data: {
        ");
                WriteLiteral("        id: ");
#nullable restore
#line 85 "C:\Users\User\Desktop\ISO-master\ISOCertificate\Views\Investigate\Print.cshtml"
               Write(Id);

#line default
#line hidden
#nullable disable
                WriteLiteral(@"
            },
            success: function (result) {
                var jsondata = $.parseJSON(result);
                var row = """";
                var table = $(""#event > tbody"");
                table.html("""");
                var index = 0;
                    //console.log(jsondata);
                    $.each(jsondata, function (j, e) {
                       index = parseInt(index + 1);
                       row += '<tr><td>' + index + '</td><td>' + e.Date.substr(0, 10) + '</td><td>' + e.Time  + '</td>'
                            + '<td>' + e.Description  + '</td><td>' + e.Comment + '</td></tr>';
                    });
                table.append(row);
            },
            error: function (e) {
                alert(e.responseText);
            }
        })

        //prevent
          var p_url = ""/Investigate/DeliverPreventLineFill_edit"";
        $.ajax({
            type: ""POST"",
            url: p_url,
            data: {
                id: ");
#nullable restore
#line 112 "C:\Users\User\Desktop\ISO-master\ISOCertificate\Views\Investigate\Print.cshtml"
               Write(Id);

#line default
#line hidden
#nullable disable
                WriteLiteral(@"
            },
            success: function (result) {
                var jsondata = $.parseJSON(result);
                var row = """";
                var table = $(""#prevent > tbody"");
                table.html("""");
                var index = 0;
                    //console.log(jsondata);
                    $.each(jsondata, function (j, e) {
                       index = parseInt(index + 1);
                       row += '<tr><td>' + index + '</td><td>' + e.Action + '</td><td>' + e.Person  + '</td><td>'  + e.Date.substr(0, 10) + '</td></tr>';
                    });
                table.append(row);
            },
            error: function (e) {
                alert(e.responseText);
            }
        })

        //evalut
          var ev_url = ""/Investigate/DeliverEvalutionFill_edit"";
        $.ajax({
            type: ""POST"",
            url: ev_url,
            data: {
                id: ");
#nullable restore
#line 138 "C:\Users\User\Desktop\ISO-master\ISOCertificate\Views\Investigate\Print.cshtml"
               Write(Id);

#line default
#line hidden
#nullable disable
                WriteLiteral(@"
            },
            success: function (result) {
                var jsondata = $.parseJSON(result);
                var row = """";
                var table = $(""#evalution > tbody"");
                table.html("""");
                var index = 0;
                    //console.log(jsondata);
                    $.each(jsondata, function (j, e) {
                       index = parseInt(index + 1);
                       row += '<tr><td>' + index + '</td><td>' + e.Notes  + '</td><td>'  + e.Date.substr(0, 10) + '</td></tr>';
                    });
                table.append(row);
          
            },
            error: function (e) {
                alert(e.responseText);
            }
        })
    </script>
");
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_HeadTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.HeadTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_HeadTagHelper);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("body", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "040c523b93bd4e6c933eb609772b9d0104fd00a113217", async() => {
                WriteLiteral(@"
    <div class=""container"">
        <div class=""row"">
            <div class=""col-12"">
                <div class=""card"">
                    <div class=""card-body"">
                        <div class=""row"">
                            <div class=""col-md-6"">
                                ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("img", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagOnly, "040c523b93bd4e6c933eb609772b9d0104fd00a113787", async() => {
                }
                );
                __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_1);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_2);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                WriteLiteral("\r\n                            </div>\r\n\r\n                            <div class=\"col-md-6 text-right\">\r\n                                <p class=\"font-weight-bold mb-1\">Investigate # ");
#nullable restore
#line 172 "C:\Users\User\Desktop\ISO-master\ISOCertificate\Views\Investigate\Print.cshtml"
                                                                          Write(No);

#line default
#line hidden
#nullable disable
                WriteLiteral("</p>\r\n                                <p class=\"text-muted\">Due to: ");
#nullable restore
#line 173 "C:\Users\User\Desktop\ISO-master\ISOCertificate\Views\Investigate\Print.cshtml"
                                                         Write(DateTime.Now);

#line default
#line hidden
#nullable disable
                WriteLiteral(" </p>\r\n                            </div>\r\n                        </div>\r\n                        <hr");
                BeginWriteAttribute("class", " class=\"", 6709, "\"", 6717, 0);
                EndWriteAttribute();
                WriteLiteral(@">
                        <div class=""row pb-5 p-5"">
                            <div class=""col-md-6"">
                                <p class=""font-weight-bold mb-4"">Report Information: </p>
                                <p class=""mb-1""><span class=""text-muted"">LessonLearned: </span> ");
#nullable restore
#line 180 "C:\Users\User\Desktop\ISO-master\ISOCertificate\Views\Investigate\Print.cshtml"
                                                                                           Write(LessonLearned);

#line default
#line hidden
#nullable disable
                WriteLiteral("</p>\r\n                                <p class=\"mb-1\"><span class=\"text-muted\">OutcomeBuisness: </span> ");
#nullable restore
#line 181 "C:\Users\User\Desktop\ISO-master\ISOCertificate\Views\Investigate\Print.cshtml"
                                                                                             Write(OutcomeBuisness);

#line default
#line hidden
#nullable disable
                WriteLiteral("</p>\r\n                                <p class=\"mb-1\"><span class=\"text-muted\">OutcomeEnviroment: </span> ");
#nullable restore
#line 182 "C:\Users\User\Desktop\ISO-master\ISOCertificate\Views\Investigate\Print.cshtml"
                                                                                               Write(OutcomeEnviroment);

#line default
#line hidden
#nullable disable
                WriteLiteral("</p>\r\n                                <p class=\"mb-1\"><span class=\"text-muted\">BriefDecription: </span> ");
#nullable restore
#line 183 "C:\Users\User\Desktop\ISO-master\ISOCertificate\Views\Investigate\Print.cshtml"
                                                                                             Write(OutcomePeople);

#line default
#line hidden
#nullable disable
                WriteLiteral("</p>\r\n                                <p class=\"mb-1\"><span class=\"text-muted\">IdentifyDescription: </span> ");
#nullable restore
#line 184 "C:\Users\User\Desktop\ISO-master\ISOCertificate\Views\Investigate\Print.cshtml"
                                                                                                 Write(OutcomeProperty);

#line default
#line hidden
#nullable disable
                WriteLiteral("</p>\r\n                                <p class=\"mb-1\"><span class=\"text-muted\">PossibleBuisness: </span> ");
#nullable restore
#line 185 "C:\Users\User\Desktop\ISO-master\ISOCertificate\Views\Investigate\Print.cshtml"
                                                                                              Write(PossibleBuisness);

#line default
#line hidden
#nullable disable
                WriteLiteral(@"</p>
                            </div>
                            <div class=""col-md-6"">
                                <p class=""font-weight-bold mb-4""></p>
                                <p class=""mb-1""><span class=""text-muted"">OccurenceCause: </span> ");
#nullable restore
#line 189 "C:\Users\User\Desktop\ISO-master\ISOCertificate\Views\Investigate\Print.cshtml"
                                                                                            Write(OccurenceCause);

#line default
#line hidden
#nullable disable
                WriteLiteral("</p>\r\n                                <p class=\"mb-1\"><span class=\"text-muted\">PossibleEnviroment: </span> ");
#nullable restore
#line 190 "C:\Users\User\Desktop\ISO-master\ISOCertificate\Views\Investigate\Print.cshtml"
                                                                                                Write(PossibleEnviroment);

#line default
#line hidden
#nullable disable
                WriteLiteral("</p>\r\n                                <p class=\"mb-1\"><span class=\"text-muted\">OutcomeBuisness: </span> ");
#nullable restore
#line 191 "C:\Users\User\Desktop\ISO-master\ISOCertificate\Views\Investigate\Print.cshtml"
                                                                                             Write(PossiblePeople);

#line default
#line hidden
#nullable disable
                WriteLiteral("</p>\r\n                                <p class=\"mb-1\"><span class=\"text-muted\">OutcomeEnviroment: </span> ");
#nullable restore
#line 192 "C:\Users\User\Desktop\ISO-master\ISOCertificate\Views\Investigate\Print.cshtml"
                                                                                               Write(PossibleProperty);

#line default
#line hidden
#nullable disable
                WriteLiteral("</p>\r\n                                <p class=\"mb-1\"><span class=\"text-muted\">BriefDecription: </span> ");
#nullable restore
#line 193 "C:\Users\User\Desktop\ISO-master\ISOCertificate\Views\Investigate\Print.cshtml"
                                                                                             Write(BriefDecription);

#line default
#line hidden
#nullable disable
                WriteLiteral("</p>\r\n                                <p class=\"mb-1\"><span class=\"text-muted\">IdentifyDescription: </span> ");
#nullable restore
#line 194 "C:\Users\User\Desktop\ISO-master\ISOCertificate\Views\Investigate\Print.cshtml"
                                                                                                 Write(IdentifyDescription);

#line default
#line hidden
#nullable disable
                WriteLiteral("</p>\r\n                                <p class=\"mb-1\"><span class=\"text-muted\">ReasonDescription: </span> ");
#nullable restore
#line 195 "C:\Users\User\Desktop\ISO-master\ISOCertificate\Views\Investigate\Print.cshtml"
                                                                                               Write(ReasonDescription);

#line default
#line hidden
#nullable disable
                WriteLiteral(@"</p>
                            </div>
                        </div>
                        <hr> <!--nom-->
                        <div class=""row p-5"">
                            <div class=""col-md-12"">
                                <table class=""table-bordered table"" id=""nominated"">
                                    <thead>
                                        <tr>
                                            <th class=""border-0 text-uppercase small font-weight-bold"">№</th>
                                            <th class=""border-0 text-uppercase small font-weight-bold"">Name</th>
                                            <th class=""border-0 text-uppercase small font-weight-bold"">Position</th>
                                            <th class=""border-0 text-uppercase small font-weight-bold"">Organization</th>
                                            <th class=""border-0 text-uppercase small font-weight-bold"">Type</th>
                                        </tr>
       ");
                WriteLiteral(@"                             </thead>
                                    <tbody>
                                        <tr></tr>
                                    </tbody>
                                </table>
                            </div>
                        </div>
                        <hr> <!--event-->
                        <div class=""row p-5"">
                            <div class=""col-md-12"">
                                <table class=""table-bordered table"" id=""event"">
                                    <thead>
                                        <tr>
                                            <th class=""border-0 text-uppercase small font-weight-bold"">№</th>
                                            <th class=""border-0 text-uppercase small font-weight-bold"">Date</th>
                                            <th class=""border-0 text-uppercase small font-weight-bold"">Time of events</th>
                                            <th class=""border-0 text-");
                WriteLiteral(@"uppercase small font-weight-bold"">Description</th>
                                            <th class=""border-0 text-uppercase small font-weight-bold"">Comment</th>
                                        </tr>
                                    </thead>
                                    <tbody>
                                        <tr></tr>
                                    </tbody>
                                </table>
                            </div>
                        </div>
                        <hr> <!--prevent-->
                        <div class=""row p-5"">
                            <div class=""col-md-12"">
                                <table class=""table-bordered table"" id=""prevent"">
                                    <thead>
                                        <tr>
                                            <th class=""border-0 text-uppercase small font-weight-bold"">№</th>
                                            <th class=""border-0 text-uppercase s");
                WriteLiteral(@"mall font-weight-bold"">Action </th>
                                            <th class=""border-0 text-uppercase small font-weight-bold"">Responsible person</th>
                                            <th class=""border-0 text-uppercase small font-weight-bold"">Target date</th>
                                        </tr>
                                    </thead>
                                    <tbody>
                                        <tr></tr>
                                    </tbody>
                                </table>
                            </div>
                        </div>
                        <hr> <!--evalut-->
                        <div class=""row p-5"">
                            <div class=""col-md-12"">
                                <table class=""table-bordered table"" id=""evalution"">
                                    <thead>
                                        <tr>
                                            <th class=""border-0 text-uppe");
                WriteLiteral(@"rcase small font-weight-bold"">№</th>
                                            <th class=""border-0 text-uppercase small font-weight-bold"">Notes on actions </th>
                                            <th class=""border-0 text-uppercase small font-weight-bold"">Target date</th>
                                        </tr>
                                    </thead>
                                    <tbody>
                                        <tr></tr>
                                    </tbody>
                                </table>
                            </div>
                        </div>
                        <hr>
                    </div>
                </div>
            </div>
        </div>
    </div>
");
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_BodyTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.BodyTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_BodyTagHelper);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n</html>\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<dynamic> Html { get; private set; }
    }
}
#pragma warning restore 1591
