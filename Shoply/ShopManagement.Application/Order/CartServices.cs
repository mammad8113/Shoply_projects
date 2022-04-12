using ShopManagement.Application.Contracts.Order;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopManagement.Application.Order
{
    public class CartServices : ICartServices
    {
        public Cart Cart { get; set; }
        public Cart Get()
        {
            return Cart;
        }

        public void Set(Cart cart)
        {
            Cart = cart;
        }
    }
}
