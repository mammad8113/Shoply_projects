using _01_framwork.Infrastructure;
using _01_Shoplyquery.Contracts.Product;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace ShopManagement.Presentation.Api
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductQuery productQuery;

        public ProductController(IProductQuery productQuery)
        {
            this.productQuery = productQuery;
        }

        [HttpGet]
        [TokenFilter]
        public List<ProductQueryModel> GetProducts()
        {
            return productQuery.GetLatest();
        }
        [HttpGet("{id}")]
        public List<ProductQueryModel> GetChildren(long id)
        {
            return productQuery.GetLatest();
        }
    }
}
