#pragma checksum "D:\Shoply_Project\Code\Shoply\ServiceHost\Pages\Shared\Components\LatestProduct\Default.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "945a0e7e1e719d5f145fc4e48580187e41192b3e"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(ServiceHost.Pages.Shared.Components.LatestProduct.Pages_Shared_Components_LatestProduct_Default), @"mvc.1.0.view", @"/Pages/Shared/Components/LatestProduct/Default.cshtml")]
namespace ServiceHost.Pages.Shared.Components.LatestProduct
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
#nullable restore
#line 1 "D:\Shoply_Project\Code\Shoply\ServiceHost\Pages\Shared\Components\LatestProduct\Default.cshtml"
using _01_Shoplyquery.Contracts.Product;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"945a0e7e1e719d5f145fc4e48580187e41192b3e", @"/Pages/Shared/Components/LatestProduct/Default.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"49bdd27e8b016acb3c031a38b8da4d14315ca499", @"/Pages/_ViewImports.cshtml")]
    #nullable restore
    public class Pages_Shared_Components_LatestProduct_Default : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<List<ProductQueryModel>>
    #nullable disable
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-page", "/Product", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-page", "/ProductCategory", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral(@"<div class=""single-row-slider-area section-space"">
    <div class=""container"">
        <div class=""row"">
            <div class=""col-lg-12"">
                <!--=======  section title  =======-->
                <div class=""section-title-wrapper text-center section-space--half"">
                    <h2 class=""section-title"">اخرین محصولات</h2>
                    <p class=""section-subtitle"">
                        لورم ایپسوم متن ساختگی با تولید سادگی نامفهوم از صنعت چاپ و با استفاده از طراحان گرافیک است چاپگرها و متون بلکه روزنامه و مجله در ستون و سطرآنچنان که لازم است
                    </p>
                </div>
                <!--=======  End of section title  =======-->
            </div>
        </div>
        <div class=""row"">
            <div class=""col-lg-12"">
                <!--=======  single row slider wrapper  =======-->
                <div class=""single-row-slider-wrapper"">
                    <div class=""ht-slick-slider"" data-slick-setting='{
                        ""sli");
            WriteLiteral(@"desToShow"": 4,
                        ""slidesToScroll"": 1,
                        ""arrows"": true,
                        ""autoplay"": false,
                        ""autoplaySpeed"": 10,
                        ""speed"":500,
                        ""infinite"": true,
                        ""rtl"": true,
                        ""prevArrow"": {""buttonClass"": ""slick-prev"", ""iconClass"": ""ion-chevron-left"" },
                        ""nextArrow"": {""buttonClass"": ""slick-next"", ""iconClass"": ""ion-chevron-right"" }
                    }' data-slick-responsive='[
                        {""breakpoint"":1501, ""settings"": {""slidesToShow"": 4} },
                        {""breakpoint"":1199, ""settings"": {""slidesToShow"": 4, ""arrows"": false} },
                        {""breakpoint"":991, ""settings"": {""slidesToShow"": 3, ""arrows"": false} },
                        {""breakpoint"":767, ""settings"": {""slidesToShow"": 2, ""arrows"": false} },
                        {""breakpoint"":575, ""settings"": {""slidesToShow"": 2, ""arrows"": fal");
            WriteLiteral("se} },\r\n                        {\"breakpoint\":479, \"settings\": {\"slidesToShow\": 1, \"arrows\": false} }\r\n                    ]\'>\r\n\r\n");
#nullable restore
#line 44 "D:\Shoply_Project\Code\Shoply\ServiceHost\Pages\Shared\Components\LatestProduct\Default.cshtml"
                         foreach (var product in Model)
                        {

#line default
#line hidden
#nullable disable
            WriteLiteral(@"                            <div class=""col"">
                                <!--=======  single grid product  =======-->
                            <div class=""single-grid-product"">
                                    <div class=""single-grid-product__image"">
                                        <div class=""single-grid-product__label"">
");
#nullable restore
#line 51 "D:\Shoply_Project\Code\Shoply\ServiceHost\Pages\Shared\Components\LatestProduct\Default.cshtml"
                                             if (product.HasDiscount)
                                            {

#line default
#line hidden
#nullable disable
            WriteLiteral("                                                <span class=\"sale\">");
#nullable restore
#line 53 "D:\Shoply_Project\Code\Shoply\ServiceHost\Pages\Shared\Components\LatestProduct\Default.cshtml"
                                                              Write(product.DiscountRate);

#line default
#line hidden
#nullable disable
            WriteLiteral("%</span>\r\n");
#nullable restore
#line 54 "D:\Shoply_Project\Code\Shoply\ServiceHost\Pages\Shared\Components\LatestProduct\Default.cshtml"
                                            }

#line default
#line hidden
#nullable disable
            WriteLiteral("                                        </div>\r\n                                        ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "945a0e7e1e719d5f145fc4e48580187e41192b3e8170", async() => {
                WriteLiteral("\r\n                                            ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("img", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagOnly, "945a0e7e1e719d5f145fc4e48580187e41192b3e8469", async() => {
                }
                );
                __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
                BeginAddHtmlAttributeValues(__tagHelperExecutionContext, "src", 2, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
                AddHtmlAttributeValue("", 3152, "~/Upload/", 3152, 9, true);
#nullable restore
#line 57 "D:\Shoply_Project\Code\Shoply\ServiceHost\Pages\Shared\Components\LatestProduct\Default.cshtml"
AddHtmlAttributeValue("", 3161, product.Picture, 3161, 16, false);

#line default
#line hidden
#nullable disable
                EndAddHtmlAttributeValues(__tagHelperExecutionContext);
                BeginAddHtmlAttributeValues(__tagHelperExecutionContext, "alt", 1, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
#nullable restore
#line 57 "D:\Shoply_Project\Code\Shoply\ServiceHost\Pages\Shared\Components\LatestProduct\Default.cshtml"
AddHtmlAttributeValue("", 3184, product.PictureAlt, 3184, 19, false);

#line default
#line hidden
#nullable disable
                EndAddHtmlAttributeValues(__tagHelperExecutionContext);
                BeginAddHtmlAttributeValues(__tagHelperExecutionContext, "title", 1, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
#nullable restore
#line 57 "D:\Shoply_Project\Code\Shoply\ServiceHost\Pages\Shared\Components\LatestProduct\Default.cshtml"
AddHtmlAttributeValue("", 3212, product.PictureTitle, 3212, 21, false);

#line default
#line hidden
#nullable disable
                EndAddHtmlAttributeValues(__tagHelperExecutionContext);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                WriteLiteral("\r\n                                        ");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Page = (string)__tagHelperAttribute_0.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
            if (__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
            {
                throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-id", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
            }
            BeginWriteTagHelperAttribute();
#nullable restore
#line 56 "D:\Shoply_Project\Code\Shoply\ServiceHost\Pages\Shared\Components\LatestProduct\Default.cshtml"
                                                                 WriteLiteral(product.Slug);

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
            WriteLiteral(@"
                                    </div>
                                    <div class=""single-grid-product__content"">
                                        <div class=""single-grid-product__category-rating"">
                                            <span class=""category"">");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "945a0e7e1e719d5f145fc4e48580187e41192b3e13279", async() => {
#nullable restore
#line 62 "D:\Shoply_Project\Code\Shoply\ServiceHost\Pages\Shared\Components\LatestProduct\Default.cshtml"
                                                                                                                                  Write(product.Category);

#line default
#line hidden
#nullable disable
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Page = (string)__tagHelperAttribute_1.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
            if (__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
            {
                throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-id", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
            }
            BeginWriteTagHelperAttribute();
#nullable restore
#line 62 "D:\Shoply_Project\Code\Shoply\ServiceHost\Pages\Shared\Components\LatestProduct\Default.cshtml"
                                                                                                    WriteLiteral(product.CategorySlug);

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
            WriteLiteral(@"</span>
                                            <span class=""rating"">
                                                <i class=""ion-android-star active""></i>
                                                <i class=""ion-android-star active""></i>
                                                <i class=""ion-android-star active""></i>
                                                <i class=""ion-android-star active""></i>
                                                <i class=""ion-android-star-outline""></i>
                                            </span>
                                        </div>

                                        <h3 class=""single-grid-product__title"">
                                            ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "945a0e7e1e719d5f145fc4e48580187e41192b3e16568", async() => {
                WriteLiteral("\r\n                                                ");
#nullable restore
#line 74 "D:\Shoply_Project\Code\Shoply\ServiceHost\Pages\Shared\Components\LatestProduct\Default.cshtml"
                                           Write(product.Name);

#line default
#line hidden
#nullable disable
                WriteLiteral("\r\n                                            ");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Page = (string)__tagHelperAttribute_0.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
            if (__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
            {
                throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-id", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
            }
            BeginWriteTagHelperAttribute();
#nullable restore
#line 73 "D:\Shoply_Project\Code\Shoply\ServiceHost\Pages\Shared\Components\LatestProduct\Default.cshtml"
                                                                     WriteLiteral(product.Slug);

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
            WriteLiteral("\r\n                                        </h3>\r\n                                        <p class=\"single-grid-product__price\">\r\n");
#nullable restore
#line 78 "D:\Shoply_Project\Code\Shoply\ServiceHost\Pages\Shared\Components\LatestProduct\Default.cshtml"
                                             if (product.HasDiscount)
                                            {

#line default
#line hidden
#nullable disable
            WriteLiteral("                                                <span class=\"discounted-price\">");
#nullable restore
#line 80 "D:\Shoply_Project\Code\Shoply\ServiceHost\Pages\Shared\Components\LatestProduct\Default.cshtml"
                                                                          Write(product.PricewithDicount);

#line default
#line hidden
#nullable disable
            WriteLiteral(" تومان</span>\r\n                                                <span class=\"main-price discounted\">");
#nullable restore
#line 81 "D:\Shoply_Project\Code\Shoply\ServiceHost\Pages\Shared\Components\LatestProduct\Default.cshtml"
                                                                               Write(product.Price);

#line default
#line hidden
#nullable disable
            WriteLiteral(" تومان</span>\r\n");
#nullable restore
#line 82 "D:\Shoply_Project\Code\Shoply\ServiceHost\Pages\Shared\Components\LatestProduct\Default.cshtml"
                                            }
                                            else
                                            {

#line default
#line hidden
#nullable disable
            WriteLiteral("                                                <span class=\"main-price \">");
#nullable restore
#line 85 "D:\Shoply_Project\Code\Shoply\ServiceHost\Pages\Shared\Components\LatestProduct\Default.cshtml"
                                                                     Write(product.Price);

#line default
#line hidden
#nullable disable
            WriteLiteral(" تومان</span>\r\n");
#nullable restore
#line 86 "D:\Shoply_Project\Code\Shoply\ServiceHost\Pages\Shared\Components\LatestProduct\Default.cshtml"
                                            }

#line default
#line hidden
#nullable disable
            WriteLiteral("                                        </p>\r\n                                    </div>\r\n                                </div>\r\n                                <!--=======  End of single grid product  =======-->\r\n                        </div>\r\n");
#nullable restore
#line 92 "D:\Shoply_Project\Code\Shoply\ServiceHost\Pages\Shared\Components\LatestProduct\Default.cshtml"

                        }

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                    </div>\r\n                </div>\r\n                <!--=======  End of single row slider wrapper  =======-->\r\n            </div>\r\n        </div>\r\n    </div>\r\n</div>");
        }
        #pragma warning restore 1998
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.IModelExpressionProvider ModelExpressionProvider { get; private set; } = default!;
        #nullable disable
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IUrlHelper Url { get; private set; } = default!;
        #nullable disable
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IViewComponentHelper Component { get; private set; } = default!;
        #nullable disable
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IJsonHelper Json { get; private set; } = default!;
        #nullable disable
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<List<ProductQueryModel>> Html { get; private set; } = default!;
        #nullable disable
    }
}
#pragma warning restore 1591
