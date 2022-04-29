using _01_Shoplyquery.Contracts.Product;
using _01_Shoplyquery.Contracts.ProductCategory;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ShopManagement.Application.Contracts.ProductCategory;
using System.Collections.Generic;

namespace ShopManagement.Presentation.Api
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductCategoryController : ControllerBase
    {
        private readonly IProductCategoryQuery productCategoryQuery;
        private readonly IProductCategoryApplication productCategoryApplication;

        public ProductCategoryController(IProductCategoryQuery productCategoryQuery, IProductCategoryApplication productCategoryApplication)
        {
            this.productCategoryQuery = productCategoryQuery;
            this.productCategoryApplication = productCategoryApplication;
        }

        [HttpGet()]
        public List<ProductCategoryViewModel> GetCategoryLevelOne()
        {
            return productCategoryApplication.GetProductCategories();
        }


        [Route("GetCategoryName/{id}")]
        [HttpGet()]
        public ProductCategoryQueryModel GetCategoryName(long id)
        {
            return productCategoryQuery.GetCategoryName(id);
        }

        [Route("GetParent/{id}")]
        [HttpGet()]
        public List<Breadcrumb> GetParent(long id)
        {
            return productCategoryQuery.GetParent(id);
        }


        [HttpGet("{id}")]
        public List<ProductCategoryQueryModel> GetChildren(long id)
        {
            return productCategoryQuery.GetChildren(id);
        }
        [HttpPost("{id}")]
        public ProductCategoryQueryModel GetCategory(long id)
        {
           var category= productCategoryQuery.GetCategory(id);
            return category;
        }
    }
}
