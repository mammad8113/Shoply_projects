using _01_Shoplyquery.Contracts.ProductCategory;
using Microsoft.AspNetCore.Mvc;

namespace ServiceHost.ViewComponents
{
    public class CategoryViewComponent : ViewComponent
    {
        private readonly IProductCategoryQuery productCategoryQuery;
        public CategoryViewComponent(IProductCategoryQuery productCategoryQuery)
        {
            this.productCategoryQuery = productCategoryQuery;
        }

        public IViewComponentResult Invoke()
        {
            var Categories = productCategoryQuery.GetCategoriesOverriding();
            return View(Categories);
        }
    }
}
