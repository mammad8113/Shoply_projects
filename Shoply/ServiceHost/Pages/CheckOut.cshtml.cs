using _0_Framework.Application;
using _01_Shoplyquery.Contracts.Cart;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Nancy.Json;
using ShopManagement.Domain.Order;
using System.Collections.Generic;

namespace ServiceHost.Pages
{
    public class CheckOutModel : PageModel
    {
        public Cart Cart { get; set; }
        public const string CookieName = "Cart-Item";
        private readonly ICartCalculatorService cartCalculatorService;

        public CheckOutModel(ICartCalculatorService cartCalculatorService)
        {
            this.cartCalculatorService = cartCalculatorService;
        }

        public void OnGet()
        {
            var serializer = new JavaScriptSerializer();
            var value = Request.Cookies[CookieName];
            var CartItems = serializer.Deserialize<List<CartItem>>(value);
            foreach (var cartitem in CartItems)
            {
                cartitem.UserUnitprice = cartitem.Unitprice.ToMoney();
                cartitem.calculatorTotalPrice();
            }
            Cart = cartCalculatorService.ComputeCart(CartItems);
        }
    }
}
