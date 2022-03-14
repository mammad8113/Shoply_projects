using _01_Shoplyquery;
using _01_Shoplyquery.Contracts.ArticleCategory;
using _01_Shoplyquery.Contracts.ProductCategory;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace ServiceHost.ViewComponents
{
    public class MenuViewComponent : ViewComponent
    {
        private readonly IProductCategoryQuery _productCategory;
        private readonly IArticleCategoryQuery _articleCategory;

        public MenuViewComponent(IProductCategoryQuery productCategory, IArticleCategoryQuery articleCategory)
        {
            _productCategory = productCategory;
            _articleCategory = articleCategory;

        }

        public IViewComponentResult Invoke()
        {
            var result = new MenuModel
            {
                ArticleCategories = _articleCategory.GetAll(),
                ProductCategories = _productCategory.GetAll(),
            };
            return View(result);
        }
    }
}
