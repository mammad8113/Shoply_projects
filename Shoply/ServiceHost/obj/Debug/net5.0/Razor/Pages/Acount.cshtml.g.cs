#pragma checksum "D:\Shoply_Project\Code\Shoply\ServiceHost\Pages\Acount.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "c3ba2111780e12b6363f79b39c5442ed3a480440"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(ServiceHost.Pages.Pages_Acount), @"mvc.1.0.razor-page", @"/Pages/Acount.cshtml")]
namespace ServiceHost.Pages
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
#line 1 "D:\Shoply_Project\Code\Shoply\ServiceHost\Pages\_ViewImports.cshtml"
using ServiceHost;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"c3ba2111780e12b6363f79b39c5442ed3a480440", @"/Pages/Acount.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"49bdd27e8b016acb3c031a38b8da4d14315ca499", @"/Pages/_ViewImports.cshtml")]
    public class Pages_Acount : global::Microsoft.AspNetCore.Mvc.RazorPages.Page
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("method", "post", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-page-handler", "Login", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-page-handler", "Register", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 3 "D:\Shoply_Project\Code\Shoply\ServiceHost\Pages\Acount.cshtml"
  
    ViewData["Title"] = "ورود _ ثبت نام";


#line default
#line hidden
#nullable disable
            WriteLiteral(@"<div class=""breadcrumb-area section-space--half"">
    <div class=""container wide"">
        <div class=""row"">
            <div class=""col-lg-12"">
                <div class=""breadcrumb-wrapper breadcrumb-bg"">
                    <div class=""breadcrumb-content"">
                        <h2 class=""breadcrumb-content__title"">ورود_ثبت نام</h2>
                        <ul class=""breadcrumb-content__page-map"">
                            <li><a href=""index.html"">صفحه اصلی</a></li>
                            <li class=""active"">ورود_ثبت نام</li>
                        </ul>
                    </div>
                </div>
            </div>
        </div>
    </div>
</div>

<div class=""page-content-area"">
    <div class=""container"">
        <div class=""row"">
            <div class=""col-lg-12"">
                <div class=""page-wrapper"">
                    <div class=""page-content-wrapper"">
                        <div class=""row"">
                            <div class=""col-sm-12 col-md-12 ");
            WriteLiteral("col-xs-12 col-lg-6\">\r\n");
#nullable restore
#line 33 "D:\Shoply_Project\Code\Shoply\ServiceHost\Pages\Acount.cshtml"
                                 if (Model.LoginMessage != null)
                                {

#line default
#line hidden
#nullable disable
            WriteLiteral("                                    <div class=\"alert alert-danger\">");
#nullable restore
#line 35 "D:\Shoply_Project\Code\Shoply\ServiceHost\Pages\Acount.cshtml"
                                                               Write(Model.LoginMessage);

#line default
#line hidden
#nullable disable
            WriteLiteral("</div>\r\n");
#nullable restore
#line 36 "D:\Shoply_Project\Code\Shoply\ServiceHost\Pages\Acount.cshtml"
                                }

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                                ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "c3ba2111780e12b6363f79b39c5442ed3a4804406071", async() => {
                WriteLiteral(@"
                                    <div class=""login-form"">
                                        <h4 class=""login-title"">ورود</h4>
                                        <div class=""row"">
                                            <div class=""col-md-12 col-12"">
                                                <label id=""UserName"">نام کاربری</label>
                                                <input type=""text"" name=""UserName"" id=""UserName"" placeholder=""نام کاربری"">
                                            </div>
                                            <div class=""col-12"">
                                                <label id=""Password"">رمز عبور</label>
                                                <input type=""password"" name=""Password"" id=""Password"" placeholder=""رمز عبور"">
                                            </div>
                                            <div class=""col-sm-6 text-left text-sm-right"">
                                                <a href=""#"" cl");
                WriteLiteral(@"ass=""forget-pass-link""> رمز عبور خود را فراموش کرده اید؟</a>
                                            </div>
                                            <div class=""col-md-12"">
                                                <button type=""submit"" class=""register-button"">ورود</button>
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
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Method = (string)__tagHelperAttribute_0.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.PageHandler = (string)__tagHelperAttribute_1.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n                            </div>\r\n                            <div class=\"col-sm-12 col-md-12 col-lg-6 col-xs-12\">\r\n                                 \r\n");
#nullable restore
#line 64 "D:\Shoply_Project\Code\Shoply\ServiceHost\Pages\Acount.cshtml"
                                  if (!string.IsNullOrWhiteSpace( Model.registerMessage ))
                                {

#line default
#line hidden
#nullable disable
            WriteLiteral("                                    <p class=\"alert alert-danger\">");
#nullable restore
#line 66 "D:\Shoply_Project\Code\Shoply\ServiceHost\Pages\Acount.cshtml"
                                                             Write(Model.registerMessage);

#line default
#line hidden
#nullable disable
            WriteLiteral("</p>\r\n");
#nullable restore
#line 67 "D:\Shoply_Project\Code\Shoply\ServiceHost\Pages\Acount.cshtml"
                                }

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                                ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "c3ba2111780e12b6363f79b39c5442ed3a48044010327", async() => {
                WriteLiteral(@"

                                    <div class=""login-form"">
                                        <h4 class=""login-title"">ثبت نام</h4>

                                        <div class=""row"">
                                            <div class=""col-md-6 col-12 mb-20"">
                                                <label id=""Fullname"">نام کامل</label>
                                                <input type=""text"" name=""Fullname"" id=""Fullname"" placeholder=""نام کامل"">
                                            </div>
                                            <div class=""col-md-6 col-12 mb-20"">
                                                <label id=""Username"">نام کاربری</label>
                                                <input type=""text"" id=""Username"" name=""Username"" placeholder=""نام کاربری"">
                                            </div>
                                            <div class=""col-md-12 mb-20"">
                                                <label i");
                WriteLiteral(@"d=""Mobile"">موبایل</label>
                                                <input type=""text"" id=""Mobile"" name=""Mobile"" placeholder=""موبایل"">
                                            </div>
                                            <div class=""col-md-6 mb-20"">
                                                <label id="" Password"">رمز عبور</label>
                                                <input type=""password"" id=""Password"" name=""Password"" placeholder=""رمز عبور"">
                                            </div>
                                            <div class=""col-md-6 mb-20"">
                                                <label id=""RePassword"">تکرار رمز عبور</label>
                                                <input type=""password"" id=""RePassword"" name=""RePassword"" placeholder=""تکرار رمز عبور"">
                                            </div>
                                            <div class=""col-12"">
                                                <button type=""subm");
                WriteLiteral("it\" class=\"register-button mt-0\">ثبت نام</button>\r\n                                            </div>\r\n                                        </div>\r\n                                    </div>\r\n\r\n                                ");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Method = (string)__tagHelperAttribute_0.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.PageHandler = (string)__tagHelperAttribute_2.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_2);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n                            </div>\r\n                        </div>\r\n                    </div>\r\n                </div>\r\n            </div>\r\n        </div>\r\n    </div>\r\n</div>");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<ServiceHost.Pages.AcountModel> Html { get; private set; }
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.ViewDataDictionary<ServiceHost.Pages.AcountModel> ViewData => (global::Microsoft.AspNetCore.Mvc.ViewFeatures.ViewDataDictionary<ServiceHost.Pages.AcountModel>)PageContext?.ViewData;
        public ServiceHost.Pages.AcountModel Model => ViewData.Model;
    }
}
#pragma warning restore 1591