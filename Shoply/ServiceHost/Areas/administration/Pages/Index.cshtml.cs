using AcountManagement.Application.Contracts.Acount;
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
        public int NewAcount { get; set; }
        public double TotalPaymentForWekk { get; set; }
        private readonly IOrderApplication orderApplication;
        private readonly IAcountApplication acountApplication;
        private readonly IInventoryApplication inventoryApplication;
        public IndexModel(IOrderApplication orderApplication, IInventoryApplication inventoryApplication, IAcountApplication acountApplication)
        {
            this.orderApplication = orderApplication;
           this.inventoryApplication = inventoryApplication;
            this.acountApplication = acountApplication;
        }

        public void OnGet()
        {
            LineChart = orderApplication.GetChartBar();
            Chart=orderApplication.GetDonuthChart();
            NewOrder = orderApplication.NewOrders();
            TotalPaymentForWekk=orderApplication.TotalPaymentForWekk();
            NewAcount=acountApplication.NewAcount();
        }
    }
}
