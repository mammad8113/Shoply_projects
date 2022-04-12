using _01_Shoplyquery.Contracts.Product;
using _01_Shoplyquery.Contracts.ProductCategory;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ShopManagement.Application.Contracts.Order;
using ShopManagement.Application.Contracts.ProductCategory;
using System.Collections.Generic;

namespace ShopManagement.Presentation.Api
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly IOrderApplication orderApplication;

        public OrderController(IOrderApplication orderApplication)
        {
            this.orderApplication = orderApplication;
        }

        [HttpGet]
        public void Show()
        {
            orderApplication.Show();
        }
    }
}
