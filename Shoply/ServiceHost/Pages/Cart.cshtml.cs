using _0_Framework.Application;
using _01_Shoplyquery.Contracts.Product;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Nancy.Json;
using ShopManagement.Application.Contracts.Order;
using ShopManagement.Domain.Order;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ServiceHost.Pages
{
    public class CartModel : PageModel
    {
        public List<CartItem> CartItems { get; set; }
        public const string CookieName = "Cart-Item";

        private readonly IProductQuery productQuery;

        public CartModel(IProductQuery productQuery)
        {
            this.productQuery = productQuery;
            CartItems = new List<CartItem>();
        }

        public void OnGet()
        {
            var serializer = new JavaScriptSerializer();
            var value = Request.Cookies[CookieName];
            CartItems = serializer.Deserialize<List<CartItem>>(value);
            foreach (var cartitem in CartItems)
            {
                cartitem.UserUnitprice = cartitem.Unitprice.ToMoney();
                cartitem.calculatorTotalPrice();
            }

            CartItems = productQuery.CheckInstock(CartItems);

        }

        public IActionResult OnGetRemove(long id)
        {
            var serializer = new JavaScriptSerializer();
            var value = Request.Cookies[CookieName];
            Response.Cookies.Delete(CookieName);
            var cartItems = serializer.Deserialize<List<CartItem>>(value);
            var remveItem = cartItems.FirstOrDefault(x => x.Id == id);
            cartItems.Remove(remveItem);
            var option = new CookieOptions
            {
                Path = "/",
                HttpOnly = false,
                IsEssential = true, 
                Expires = DateTime.Now.AddMonths(2),
            };
            var cookieValue = serializer.Serialize(cartItems);
            HttpContext.Response.Cookies.Append(CookieName, cookieValue, option);
            return RedirectToPage("/Cart");
        }

        public IActionResult OnGetCheckOut()
        {
            var serializer = new JavaScriptSerializer();
            var value = Request.Cookies[CookieName];
            CartItems = serializer.Deserialize<List<CartItem>>(value);
            foreach (var cartitem in CartItems)
            {
                cartitem.UserUnitprice = cartitem.Unitprice.ToMoney();
                cartitem.calculatorTotalPrice();

            }
            CartItems = productQuery.CheckInstock(CartItems);

            if (CartItems.Any(x => !x.InStock))
                return RedirectToPage("/Cart");

            return RedirectToPage("./CheckOut");
        }

    }
}
