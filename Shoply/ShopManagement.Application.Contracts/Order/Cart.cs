using System.Collections.Generic;

namespace ShopManagement.Application.Contracts.Order
{
    public class Cart
    {
        public double TotalPrice { get; set; }
        public double TotalDiscountPrice { get; set; }
        public double PaymentPrice { get; set; }
        public int paymentMethod { get; set; }
        public long AddressId { get; set; }
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

        public void SetpaymentMethod(int paymentMethod)
        {
            this.paymentMethod = paymentMethod;
        }

        public void SetAddress(long Address)
        {
            this.AddressId = Address;
                
        }
    }
}
