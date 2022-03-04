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

        public void OnGet(string id,int p=1)
        {
            slug = id;
            string numbers = HttpContext.Request.Query["number"];
            if (numbers==null)
            {
                numbers = "3";
            }
            float count = productCategoryQuery.Count(id);
             this.Pages = new CustomPage(p,count,int.Parse(numbers), "ProductCategory");
            category = productCategoryQuery.GetProductCategoryWithProductsForPagationBy(id,p,int.Parse(numbers));

        }
        public IActionResult OnGetPage(string id, int number,int p = 1)
        {
            slug = id;
          
           
            float count = productCategoryQuery.Count(id);
            this.Pages = new CustomPage(p, count, number, "ProductCategory");
            category = productCategoryQuery.GetProductCategoryWithProductsForPagationBy(id, p,number);
            var product = category.Products;
            return new JsonResult(category);
        }
    }
}
