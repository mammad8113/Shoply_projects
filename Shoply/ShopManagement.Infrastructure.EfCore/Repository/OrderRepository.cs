using _0_Framework.Application;
using _01_framwork;
using _01_framwork.Infrastructure;
using AcountManagement.Infrastructure.EfCore;
using Microsoft.EntityFrameworkCore;
using ShopManagement.Application.Contracts.Order;
using ShopManagement.Domain.Order.Agg;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopManagement.Infrastructure.EfCore.Repository
{
    public class OrderRepository : BaseRepository<long, Order>, IOrederRepository
    {
        private readonly ShopContext _shopContext;
        private readonly AcountContext AcountContext;


        public OrderRepository(ShopContext shopContext, AcountContext acountContext) : base(shopContext)
        {
            _shopContext = shopContext;
            AcountContext = acountContext;
        }

        public double GetamountBy(long id)
        {
            var order = _shopContext.Orders.Select(x => new { x.Id, x.PayAmount }).FirstOrDefault(x => x.Id == id);
            if (order != null)
                return order.PayAmount;

            return 0;
        }

        public Chart GetChartBar()
        {
            double totalOrdersForMotnh = 0;
            var data = new List<int>();
            for (int i = 1; i <= 12; i++)
            {
                var startDate = new DateTime(DateTime.Now.Year, i, 01);
                var endDate = new DateTime(DateTime.Now.Year, i, DateTime.DaysInMonth(DateTime.Now.Year, i));

                totalOrdersForMotnh = _shopContext.Orders.Where(x => x.CreationDate >= startDate && x.CreationDate <= endDate).Select(x => new { x.PayAmount }).Sum(x => x.PayAmount);
                data.Add(Convert.ToInt32(totalOrdersForMotnh));
            }
            var chart = new Chart("گزارش فروش ماه به ماه", "#a4133c", data);
            chart.BackgroundColor = new List<string> { "#f32" };
            return chart;
        }
        public Chart GetChartLine()
        {
            var chart = new Chart("گزارش فروش محصولات فروخته شده در هفته", "#000");
            var TotalorderItems = new List<OrderItemViewModel>();
            var random = new Random();

            var week = DateTime.Now.Day - 7;
            var startDate = new DateTime(DateTime.Now.Year, DateTime.Now.Month, week);
            var endDate = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day);

            var orders = _shopContext.Orders
                .Select(x => new { x.OrderItems, x.Id, x.PayAmount }).AsNoTracking().ToList();

            var totalPricePayment = orders.Sum(x => x.PayAmount);

            foreach (var order in orders)
            {
                var orderItems = order.OrderItems.Select(x => new OrderItemViewModel
                {
                    Id = x.Id,
                    UnitPrice = x.UnitPrice,
                    Count = x.Count,
                    DiscountRate = x.DiscountRate,
                    PriceWithdiscount = x.PriceWithdiscount,
                    ProductId = x.ProductId,
                    CreationDate = x.CreationDate.ToFarsi(),
                    OrderId = x.OrderId,
                }).ToList();
                TotalorderItems.AddRange(orderItems);
            }
            var productsid = DeletDoblicated(TotalorderItems.Select(x => x.ProductId).ToList());
            double payment = 0;
            foreach (var id in productsid)
            {
                payment = TotalorderItems.Where(x => x.ProductId == id).Sum(x => x.PriceWithdiscount);

                var Percent = ((payment * 100) / totalPricePayment);

                var name = _shopContext.Products.FirstOrDefault(x => x.Id == id)?.Name;
                chart.Data.Add(Convert.ToInt32(Percent));
                chart.Labels.Add(name);
                var r = random.Next(0, 255);
                var g = random.Next(0, 255);
                var b = random.Next(0, 255);
                chart.BackgroundColor.Add($"rgb({r},{g},{b})");
            }

            return chart;
        }

        private List<long> DeletDoblicated(List<long> idies)
        {
            var newidies = new List<long>();
            foreach (var id in idies)
            {
                if (!newidies.Contains(id))
                    newidies.Add(id);
            }

            return newidies;
        }
        public List<OrderItemViewModel> GetOrderItems(long id)
        {
            var products = _shopContext.Products.Select(x => new { x.Id, x.Name }).ToList();

            var order = _shopContext.Orders.Select(x => new { x.Id, x.OrderItems }).AsNoTracking().FirstOrDefault(x => x.Id == id);
            var orderItems = order.OrderItems.Select(x => new OrderItemViewModel
            {
                Id = x.Id,
                UnitPrice = x.UnitPrice,
                Count = x.Count,
                DiscountRate = x.DiscountRate,
                PriceWithdiscount = x.PriceWithdiscount,
                ProductId = x.ProductId,
                CreationDate = x.CreationDate.ToFarsi(),
                OrderId = x.OrderId,
            }).ToList();

            foreach (var item in orderItems)
            {
                item.Product = products.FirstOrDefault(x => x.Id == item.ProductId).Name;
            }
            return orderItems.OrderByDescending(x => x.Id).ToList();
        }

        public List<OrderViewModel> Search(OrderSearchModel model)
        {
            var acounts = AcountContext.Acounts.Select(x => new { x.Id, x.Fullname }).ToList();
            var query = _shopContext.Orders.Select(x => new OrderViewModel
            {
                Id = x.Id,
                IssueTrakingNo = x.IssueTrakingNo,
                AcountId = x.AcountId,
                DiscountAmount = x.DiscountAmount,
                PayAmount = x.PayAmount,
                PaymentMethodId = x.PaymentMethod,
                IsCanceled = x.IsCanceled,
                IsPiad = x.IsPiad,
                RefId = x.RefId,
                TotalAmount = x.TotalAmount,
                CreationDate = x.CreationDate.ToFarsi(),

            });

            query = query.Where(x => x.IsCanceled == model.IsCancel);

            if (model.AcountId > 0)
                query = query.Where(x => x.AcountId == model.AcountId);


            var orders = query.ToList();

            foreach (var order in orders)
            {
                order.Acount = acounts.FirstOrDefault(x => x.Id == order.AcountId).Fullname;
                order.PaymentMethod = PaymentMethod.GetBy(order.PaymentMethodId).Name;
            }


            return orders;
        }

        public long NewOrders()
        {
   
            return _shopContext.Orders.Where(x => !x.IsShow).Count();
        }

        public List<OrderViewModel> List()
        {
            return _shopContext.Orders.Select(x => new OrderViewModel
            {
                Id = x.Id

            }).ToList();
        }

       public List<long> OrderIdies()
        {

             return _shopContext.Orders.OrderByDescending(x=>x.Id).Select(x => x.Id).ToList();

        }

        public double TotalPaymentForWekk()
        {
            var week = DateTime.Now.Day - 7;
            var startDate = new DateTime(DateTime.Now.Year, DateTime.Now.Month, week);
            var endDate = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day+1);
            var total = _shopContext.Orders.Where(x => x.CreationDate >= startDate && x.CreationDate <= endDate).Select(x => new { x.Id, x.PayAmount }).ToList();
            return total.Sum(x => x.PayAmount);
        }
    }
}
