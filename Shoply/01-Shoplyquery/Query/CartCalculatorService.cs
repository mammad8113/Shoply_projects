using _01_framwork.Applicatin;
using _01_framwork.Infrastructure;
using _01_Shoplyquery.Contracts.Cart;
using DiscountManagement.Infrastructure;
using ShopManagement.Application.Contracts.Order;
using ShopManagement.Domain.Order;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01_Shoplyquery.Query
{
    public class CartCalculatorService : ICartCalculatorService
    {
        private readonly IAuthHelper authHelper;
        private readonly DiscountContext discountContext;

        public CartCalculatorService(IAuthHelper authHelper, DiscountContext discountContext)
        {
            this.authHelper = authHelper;
            this.discountContext = discountContext;
        }
        public Cart ComputeCart(List<CartItem> cartItems)
        {
            var result = new Cart();

            var currentrol = authHelper.CurrentAccountRole();

            var colleagueDiscounts = discountContext.ColleagueDiscounts.Where(x => !x.IsRemoved)
                      .Select(x => new { x.ProductId, x.Discount }).ToList();

            var CustomerDiscounts = discountContext.CustomerDiscounts.Where(x => x.StartDiscount <= DateTime.Now && x.EndDiscount >= DateTime.Now)
                   .Select(x => new { x.ProductId, x.Discount }).ToList();
            foreach (var item in cartItems)
            {
                if (currentrol == Rols.Colleague)
                {
                    var colleagueDiscount = colleagueDiscounts.FirstOrDefault(x => x.ProductId == item.Id);
                    if (colleagueDiscount != null)
                    item.DiscountRate = colleagueDiscount.Discount;
                }
                else
                {
                    var CustomerDiscount = CustomerDiscounts.FirstOrDefault(x => x.ProductId == item.Id);
                    if (CustomerDiscount != null) 
                    item.DiscountRate = CustomerDiscount.Discount;
                }
                item.DiscountAmount = ((item.TotalPrice * item.DiscountRate) / 100);
                item.ItemPayAmount = item.TotalPrice - item.DiscountAmount;
                result.Add(item);
            }

            return result;

        }
    }
}
