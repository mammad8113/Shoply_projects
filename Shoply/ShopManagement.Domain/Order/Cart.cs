using System.Collections.Generic;

namespace ShopManagement.Domain.Order
{
    public class Cart
    {
        public double TotalPrice { get; set; }
        public double TotalDiscountPrice { get; set; }
        public double PaymentPrice { get; set; }
        public List<CartItem> CartItems { get; set; }

        public Cart()
        {
            CartItems = new List<CartItem>();
        }

        public void Add(CartItem cartItem)
        {
            CartItems.Add(cartItem);
            TotalPrice+=cartItem.TotalPrice;
            TotalDiscountPrice += cartItem.DiscountAmount;
            PaymentPrice += cartItem.ItemPayAmount;

        }
    }
}
