using AcountManagement.Application.Contracts.Acount;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using ShopManagement.Application.Contracts.Address;
using ShopManagement.Application.Contracts.Order;
using System.Collections.Generic;

namespace ServiceHost.Areas.administration.Pages.Shop.Order
{
    public class IndexModel : PageModel
    {
        public List<OrderViewModel> Orders { get; set; }
        public List<OrderItemViewModel> OrderItems { get; set; }
        public SelectList Acounts { get; set; }
        public OrderSearchModel SearchModel { get; set; }
        private readonly IOrderApplication orderApplication;
        private readonly IAcountApplication acountApplication;
        private readonly IAddressApplication addressApplication;

        public IndexModel(IOrderApplication orderApplication, IAcountApplication acountApplication, IAddressApplication addressApplication)
        {
            this.orderApplication = orderApplication;
            this.acountApplication = acountApplication;
            this.addressApplication = addressApplication;
        }

        public void OnGet(OrderSearchModel SearchModel)
        {
            orderApplication.Show();
            Orders = orderApplication.Search(SearchModel);
            Acounts = new SelectList(acountApplication.GetAll(), "Id", "Fullname");

        }
        public IActionResult OnGetConfirm(long id)
        {
            orderApplication.PaymentSucceeses(id, 1);
            return RedirectToPage("./Index");
        }
        public IActionResult OnGetCancel(long id)
        {
            orderApplication.PaymentCancel(id);
            return RedirectToPage("./Index");
        }
        public IActionResult OnGetItems(long id)
        {
            OrderItems = orderApplication.GetOrderItems(id);

            return Partial("./Items", OrderItems);

        }

        public IActionResult OnGetAddress(long id)
        {
            var address = addressApplication.GetAddress(id);
            return Partial("./Address", address);

        }
    }
}
