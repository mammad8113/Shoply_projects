using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopManagement.Application.Contracts.Order
{
    public interface IOrderApplication
    {
        long PlaceOrder(Cart cart);
        string PaymentSucceeses(long orderId, long refId);
        void PaymentCancel(long orderId);
        double GetamountBy(long id);
        long NewOrders();
        List<OrderViewModel> Search(OrderSearchModel model);
      
        List<OrderItemViewModel> GetOrderItems(long id);
        Chart GetChartBar();
        Chart GetDonuthChart();
        double TotalPaymentForWekk();
        bool Show();
    }
}
