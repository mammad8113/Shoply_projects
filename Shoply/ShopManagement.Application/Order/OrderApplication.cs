using _0_Framework.Application;
using _01_framwork.Applicatin;
using _01_framwork.Applicatin.Sms;
using Microsoft.Extensions.Configuration;
using ShopManagement.Application.Contracts.Order;
using ShopManagement.Domain.Order;
using ShopManagement.Domain.Order.Agg;
using ShopManagement.Domain.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopManagement.Application.Order
{
    public class OrderApplication : IOrderApplication
    {
        private readonly IAuthHelper authHelper;
        private readonly IOrederRepository orederRepository;
        private readonly IConfiguration configuration;
        private readonly IShopInventoryAcl shopInventoryAcl;
        private readonly ISmsService smsService;
        private readonly IShopAcountAcl acountAcl;
        public OrderApplication(IOrederRepository orederRepository, IAuthHelper authHelper, IConfiguration configuration,
            IShopInventoryAcl shopInventoryAcl, ISmsService smsService, IShopAcountAcl acountAcl)
        {
            this.orederRepository = orederRepository;
            this.authHelper = authHelper;
            this.smsService = smsService;
            this.acountAcl = acountAcl;
            this.configuration = configuration;
            this.shopInventoryAcl = shopInventoryAcl;
        }

        public double GetamountBy(long id)
        {
            return orederRepository.GetamountBy(id);
        }

        public Chart GetChartBar()
        {
            return orederRepository.GetChartBar();
        }

        public Chart GetChartLine()
        {
            return orederRepository.GetChartLine();
        }

        public List<OrderItemViewModel> GetOrderItems(long id)
        {
           return orederRepository.GetOrderItems(id);
        }

        public void PaymentCancel(long orderId)
        {
            var order = orederRepository.Get(orderId);
            order.Cancel();
            orederRepository.Save();
        }

        public string PaymentSucceeses(long orderId, long refId)
        {
            var order = orederRepository.Get(orderId);
            order.PaymentSuccedd(refId);
            var issuetraking = CodeGenerator.Generate("Sh");
            order.SetIssueTrakingNo(issuetraking);
            if (shopInventoryAcl.ReduceFromInventory(order.OrderItems))
            {
                orederRepository.Save();

                var customerAcount = acountAcl.GetAcountBy(order.AcountId);
                smsService.Send(customerAcount.mobil, $"سفارش شما با شماره پیگیری با موفقیعت پرداخت شد.  {issuetraking} {customerAcount.name}");

                return issuetraking;
            }

            return "";

        }

        public List<OrderViewModel> Search(OrderSearchModel model)
        {
            return orederRepository.Search(model);
        }

        long IOrderApplication.PlaceOrder(Cart cart)
        {
            var acountId = authHelper.CurrentAccountId();
            var result = new Domain.Order.Agg.Order(acountId, cart.paymentMethod, cart.TotalPrice, cart.TotalDiscountPrice, cart.PaymentPrice,cart.AddressId);
            foreach (var cartItem in cart.CartItems)
            {
                var orderItem = new OrderItem(cartItem.Id, cartItem.Unitprice, cartItem.ItemPayAmount, cartItem.Count, cartItem.DiscountRate);
                result.AddItem(orderItem);
            }
            orederRepository.Create(result);
            orederRepository.Save();

            return result.Id;
        }
        public long NewOrders()
        {
            return orederRepository.NewOrders();
        }

        public bool Show()
        {
            var order = orederRepository.Get(88);

            var idies = orederRepository.OrderIdies();
            foreach (var id in  idies)
            {
                orederRepository.Get(id).Show();
            }
            orederRepository.Save();
            return true;
        }

     

        public double TotalPaymentForWekk()
        {
            return orederRepository.TotalPaymentForWekk();
        }
    }
}