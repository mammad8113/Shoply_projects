using _01_Shoplyquery.Contracts.ProductCategory;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace ServiceHost.ViewComponents
{
    public class MenuViewComponent:ViewComponent
    {
        private readonly IProductCategoryQuery _productCategory;

        public MenuViewComponent(IProductCategoryQuery productCategory)
        {
            _productCategory = productCategory;
          
        }

        public IViewComponentResult Invoke()
        {
           new KeyValuePair<bool, string>(true, "dd");
            var productCategories = _productCategory.GetAll();
            return View(productCategories);
        
        }
    }
}
