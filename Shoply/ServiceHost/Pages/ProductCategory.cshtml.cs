using _01_Shoplyquery;
using _01_Shoplyquery.Contracts.ProductCategory;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ServiceHost.Pages
{
    public class ProductCategoryModel : PageModel
    {
        public ProductCategoryQueryModel category { get; set; }
        public string slug { get; set; }
        public CustomPage Pages { get; set; }
        private readonly IProductCategoryQuery productCategoryQuery;

        public ProductCategoryModel(IProductCategoryQuery productCategoryQuery)
        {
            this.productCategoryQuery = productCategoryQuery;
        }

        public void OnGet(string id)
        {
            category = productCategoryQuery.GetProductCategoryWithProductsForPagationBy(id);
        }
    
    }
}
