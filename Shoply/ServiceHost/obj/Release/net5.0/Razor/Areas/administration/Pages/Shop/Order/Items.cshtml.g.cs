#pragma checksum "D:\Shoply_Project\Code\Shoply\ServiceHost\Areas\administration\Pages\Shop\Order\Items.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "218295a4ea472d2d118958e4b2e059e5e4635758"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(ServiceHost.Pages.Shop.Order.Areas_administration_Pages_Shop_Order_Items), @"mvc.1.0.view", @"/Areas/administration/Pages/Shop/Order/Items.cshtml")]
namespace ServiceHost.Pages.Shop.Order
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
#line 1 "D:\Shoply_Project\Code\Shoply\ServiceHost\Areas\administration\Pages\_ViewImports.cshtml"
using ServiceHost;

#line default
#line hidden
#nullable disable
#nullable restore
#line 1 "D:\Shoply_Project\Code\Shoply\ServiceHost\Areas\administration\Pages\Shop\Order\Items.cshtml"
using ShopManagement.Application.Contracts.Order;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "D:\Shoply_Project\Code\Shoply\ServiceHost\Areas\administration\Pages\Shop\Order\Items.cshtml"
using _0_Framework.Application;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"218295a4ea472d2d118958e4b2e059e5e4635758", @"/Areas/administration/Pages/Shop/Order/Items.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"7ce9fe251f61a7a01179928d90a3769be7040d28", @"/Areas/administration/Pages/_ViewImports.cshtml")]
    public class Areas_administration_Pages_Shop_Order_Items : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<List<OrderItemViewModel>>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral(@"<div class=""modal-header"">
    <button type=""button"" class=""close"" data-dismiss=""modal"" aria-hidden=""true"">×</button>
    <h4 class=""modal-title""> مشاهده ایتم های فاکتور  </h4>

</div>
<p id=""Alert"" class=""alert-danger""></p>

<div class=""modal-body"">
    <table class=""table table-bordered "" style=""background-color:deepskyblue;"">
        <thead>
            <tr>
                <th>#</th>
                <th>محصول</th>
                <th>تعداد</th>
                <th>قیمت واحد</th>
                <th> درصد تخفیف</th>
                <th> قیمت با تخفیف</th>
                <th>تاریخ تولید</th>
            </tr>
        </thead>
        <tbody>
");
#nullable restore
#line 27 "D:\Shoply_Project\Code\Shoply\ServiceHost\Areas\administration\Pages\Shop\Order\Items.cshtml"
             foreach (var item in Model)
            {

#line default
#line hidden
#nullable disable
            WriteLiteral("                <tr>\r\n                    <td>");
#nullable restore
#line 30 "D:\Shoply_Project\Code\Shoply\ServiceHost\Areas\administration\Pages\Shop\Order\Items.cshtml"
                   Write(item.Id);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                    <td>");
#nullable restore
#line 31 "D:\Shoply_Project\Code\Shoply\ServiceHost\Areas\administration\Pages\Shop\Order\Items.cshtml"
                   Write(item.Product);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                    <td>");
#nullable restore
#line 32 "D:\Shoply_Project\Code\Shoply\ServiceHost\Areas\administration\Pages\Shop\Order\Items.cshtml"
                   Write(item.Count);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                    <td>");
#nullable restore
#line 33 "D:\Shoply_Project\Code\Shoply\ServiceHost\Areas\administration\Pages\Shop\Order\Items.cshtml"
                   Write(item.UnitPrice.ToMoney());

#line default
#line hidden
#nullable disable
            WriteLiteral(" تومان</td>\r\n                    <td>");
#nullable restore
#line 34 "D:\Shoply_Project\Code\Shoply\ServiceHost\Areas\administration\Pages\Shop\Order\Items.cshtml"
                   Write(item.DiscountRate);

#line default
#line hidden
#nullable disable
            WriteLiteral("%</td>\r\n                    <td>");
#nullable restore
#line 35 "D:\Shoply_Project\Code\Shoply\ServiceHost\Areas\administration\Pages\Shop\Order\Items.cshtml"
                   Write(item.PriceWithdiscount.ToMoney());

#line default
#line hidden
#nullable disable
            WriteLiteral(" تومان</td>\r\n                    <td>");
#nullable restore
#line 36 "D:\Shoply_Project\Code\Shoply\ServiceHost\Areas\administration\Pages\Shop\Order\Items.cshtml"
                   Write(item.CreationDate);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                </tr>\r\n");
#nullable restore
#line 38 "D:\Shoply_Project\Code\Shoply\ServiceHost\Areas\administration\Pages\Shop\Order\Items.cshtml"
            }

#line default
#line hidden
#nullable disable
            WriteLiteral("        </tbody>\r\n    </table>\r\n</div>\r\n<div class=\"modal-footer\">\r\n    <button type=\"button\" class=\"btn btn-default waves-effect\" data-dismiss=\"modal\">بستن</button>\r\n</div>\r\n\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<List<OrderItemViewModel>> Html { get; private set; }
    }
}
#pragma warning restore 1591
