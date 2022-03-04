using _01_Shoplyquery.Contracts.ProductCategory;
using Microsoft.AspNetCore.Mvc;

namespace ServiceHost.ViewComponents
{
    public class CategoryWithProductViewComponent:ViewComponent
    {
        private readonly IProductCategoryQuery productCategoryQuery;

        public CategoryWithProductViewComponent(IProductCategoryQuery productCategoryQuery)
        {
            this.productCategoryQuery = productCategoryQuery;
        }

        public IViewComponentResult Invoke()
        {
            var productCategories = productCategoryQuery.GetProductCategoryWithProducts();
            return View(productCategories);
        }
    }
}
