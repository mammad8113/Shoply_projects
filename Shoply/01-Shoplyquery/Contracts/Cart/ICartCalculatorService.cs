using ShopManagement.Application.Contracts.Order;
using ShopManagement.Domain.Order;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01_Shoplyquery.Contracts.Cart
{
    public interface ICartCalculatorService
    {
        ShopManagement.Application.Contracts.Order.Cart ComputeCart(List<CartItem> cartItems);
    }
}
