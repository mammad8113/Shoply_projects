using _0_Framework.Application;
using _0_Framework.Application.ZarinPal;
using _01_framwork.Applicatin;
using _01_framwork.Applicatin.ZarinPal;
using _01_Shoplyquery.Contracts.Address;
using _01_Shoplyquery.Contracts.Cart;
using _01_Shoplyquery.Contracts.Product;
using _01_Shoplyquery.Query;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Nancy.Json;
using RestSharp;
using RestSharp.Serialization.Json;
using ShopManagement.Application.Contracts.Address;
using ShopManagement.Application.Contracts.Order;
using ShopManagement.Domain.Order;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Net;
using System.Runtime.Intrinsics.Arm;
using static System.Net.WebRequestMethods;

namespace ServiceHost.Pages
{
    public class CheckOutModel : PageModel
    {
        public Cart Cart { get; set; }
        public CreateAddress Command { get; set; }
        public List<AddressqueryModel> Addresses { get; set; }
        public const string CookieName = "Cart-Item";
        private readonly ICartCalculatorService cartCalculatorService;
        private readonly IZarinPalFactory zarinPalFactory;
        private readonly IOrderApplication orderApplication;
        private readonly IProductQuery productQuery;
        private readonly ICartServices CartServices;
        private readonly IAuthHelper authHelper;
        private readonly IAddressApplication addressApplication;
        private readonly ICityServices CityServices;
        public readonly IAddressQuery addressQuery;

        public CheckOutModel(ICartCalculatorService cartCalculatorService, IOrderApplication orderApplication,
            ICartServices cartServices, IProductQuery productQuery, IZarinPalFactory zarinPalFactory, IAuthHelper authHelper,
            ICityServices cityServices, IAddressApplication addressApplication, IAddressQuery addressQuery)
        {
            this.cartCalculatorService = cartCalculatorService;
            this.orderApplication = orderApplication;
            this.zarinPalFactory = zarinPalFactory;
            this.productQuery = productQuery;
            this.authHelper = authHelper;
            this.addressQuery = addressQuery;
            this.addressApplication = addressApplication;
            CartServices = cartServices;
            CityServices = cityServices;
       
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
            CartServices.Set(Cart);

            Addresses = addressQuery.GetAcountAddress(authHelper.CurrentAccountId());
        }

        public IActionResult OnPostPay(int paymentMethod, CreateAddress command, long AddressId)
        {
            var cart = CartServices.Get();
            cart.SetpaymentMethod(paymentMethod);
            var cartItems = productQuery.CheckInstock(cart.CartItems);
            if (cartItems.Any(x => !x.InStock))
                return RedirectToPage("/Cart");
            command.AcountId = authHelper.CurrentAccountId();
            cart.SetAddress(AddressId);
            var orderId = orderApplication.PlaceOrder(cart);
            if (paymentMethod == (int)PaymentMethodId.online)
            {
                var name = authHelper.CurrentAccountName();
                var mobile = authHelper.CurrentAccountMobile();
                var paymentReponse = zarinPalFactory.CreatePaymentRequest(cart.PaymentPrice.ToString(CultureInfo.InvariantCulture), mobile, "", "خرید از فروشگاه شاپلی", orderId);
                return Redirect($"https://{zarinPalFactory.Prefix}.zarinpal.com/pg/StartPay/{paymentReponse.Authority}");
            }
            else
            {
                var result = new PayResult();
                Response.Cookies.Delete("Cart-Item");
                result = result.Successs("سفارش شما با موفقیعت ثبت شد. و پرداخت در درب منزل صورت میگیرد.", null);
                return RedirectToPage("/PaymentResult", result);

            }
        }
        //{zarinPalFactory.Prefix
        public IActionResult OnGetCallBack([FromQuery] string authority, [FromQuery] string status,
        [FromQuery] long Id)
        {

            var amount = orderApplication.GetamountBy(Id);
            var result = zarinPalFactory.CreateVerificationRequest(authority, amount.ToString(CultureInfo.InvariantCulture));
            var OpreationResponse = new _01_framwork.Applicatin.PayResult();
            if (status == "OK" && result.Status >= 100)
            {
                var issuetraking = orderApplication.PaymentSucceeses(Id, result.RefID);
                if (string.IsNullOrWhiteSpace(issuetraking))
                {
                    OpreationResponse = OpreationResponse.Faild("خطای ناشناسی رخ داده است");
                    return RedirectToPage("/PaymentResult", OpreationResponse);

                }

                Response.Cookies.Delete("Cart-Item");
                OpreationResponse = OpreationResponse.Successs("عملیات با موفقیعت انجام شد.", issuetraking);
                return RedirectToPage("/PaymentResult", OpreationResponse);
            }
            else
            {
                OpreationResponse = OpreationResponse.Faild("عملیات موفقعیت انیز نبود. در صورت کسر از حساب تا 48 ساعت اینده مبلغ به حساب شما بر میگردد.");
                return RedirectToPage("/PaymentResult", OpreationResponse);
            }
        }


        public JsonResult OnGetCity(long id)
        {
            var c = ShopManagement.Application.Contracts.Order.Cities.GetcitiesBy(id);
            return new JsonResult(c);
        }

        public IActionResult OnGetCreate()
        {
            var command = new CreateAddress();
            command.States = States.GetAll();
            return Partial("./Partial/Create", command);
        }

        public IActionResult OnPostCreate(CreateAddress command)
        {
            command.AcountId = authHelper.CurrentAccountId();
            addressApplication.Create(command);
            return RedirectToPage("./Index");
        }


        public IActionResult OnGetRemove(long id)
        {
            addressApplication.Remove(id);
            return RedirectToPage("./CheckOut");
        }

        public IActionResult OnGetEdit(long id,long stateId)
        {
            var command = addressApplication.GetDetals(id);
            command.States = States.GetAll();
            command.Cities = Cities.GetcitiesBy(stateId);
            return Partial("./Partial/Edit", command);
        }

        public IActionResult OnPostEdit(EditAddress command)
        {
            command.AcountId = authHelper.CurrentAccountId();
            command.Cities = Cities.GetAll();
            addressApplication.Edit(command);
            return RedirectToPage("./CheckOut");
        }
    }
}
