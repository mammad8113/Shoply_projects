using InventoryManagement.Application.Contracts.Inventory;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ShopManagement.Application.Contracts.Order;

namespace ServiceHost.Areas.administration
{
    public class IndexModel : PageModel
    {
        public Chart LineChart { get; set; }
        public Chart Chart { get; set; }
        public Chart ChartLine { get; set; }
        public long NewOrder { get; set; }
        public double TotalPaymentForWekk { get; set; }
        private readonly IOrderApplication orderApplication;
        private readonly IInventoryApplication inventoryApplication;
        public IndexModel(IOrderApplication orderApplication, IInventoryApplication inventoryApplication)
        {
            this.orderApplication = orderApplication;
           this.inventoryApplication = inventoryApplication;
        }

        public void OnGet()
        {
            LineChart = orderApplication.GetChartBar();
            Chart=orderApplication.GetChartLine();
            NewOrder = orderApplication.NewOrders();
            TotalPaymentForWekk=orderApplication.TotalPaymentForWekk();
        }
    }
}
