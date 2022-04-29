using _01_framwork.Domain;
using ShopManagement.Application.Contracts.Order;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopManagement.Domain.Order.Agg
{
    public interface IOrederRepository : IRepository<long, Order>
    {
        double GetamountBy(long id);
        List<OrderViewModel> Search(OrderSearchModel model);
        List<OrderViewModel> List();
        List<OrderItemViewModel> GetOrderItems(long id);
        double TotalPaymentForWekk();
        long NewOrders();
        Chart GetChartBar();
        Chart GetDonuthChart();
        List<long> OrderIdies();

    }
}
