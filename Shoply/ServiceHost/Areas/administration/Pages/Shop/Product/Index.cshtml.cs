using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using ShopManagement.Application.Contracts.Product;
using ShopManagement.Application.Contracts.ProductCategory;
using ShopManagement.Application.ProductCategorys;
using System.Collections.Generic;

namespace ServiceHost.Areas.administration.Pages.Shop.Product
{
    public class IndexModel : PageModel
    {
        private readonly IProductApplication productApplication;
        private readonly IProductCategoryApplication productCategoryApplication;
        public List<ProductViewModel> Products { get; set; }
        public ProductSearchModel SearchModel { get; set; }
        public SelectList productCategories { get; set; }
        public IndexModel(IProductApplication productApplication, IProductCategoryApplication productCategoryApplication)
        {
            this.productApplication = productApplication;
            this.productCategoryApplication = productCategoryApplication;
        }

        public void OnGet(ProductSearchModel searchModel)
        {
            Products = productApplication.Search(searchModel);
            productCategories = new SelectList(productCategoryApplication.GetProductCategories(0), "Id", "Name");
        }
        public IActionResult OnGetCreate()
        {
            var command = new CreateProduct();
            command.ProductCategories=productCategoryApplication.GetProductCategories(0);
            return Partial("./Create", command);
        }
        public JsonResult OnPostCreate(CreateProduct command)
        {
            var result = productApplication.Create(command);
            return new JsonResult(result);
        }
        public IActionResult OnGetEdit(int id)
        {
            var product = productApplication.GetDetals(id);
            product.ProductCategories = productCategoryApplication.GetProductCategories(0);
            return Partial("./Edit", product);
        }

        public JsonResult OnPostEdit(EditProduct command)
        {
            var result = productApplication.Edit(command);
            return new JsonResult(result);
        }
        public IActionResult OnGetNotInStock(long id)
        {
          var result= productApplication.NotInStock(id);
            return RedirectToPage("./Index");
        }
        public IActionResult OnGetIsInStock(long id)
        {
            var result = productApplication.InStock(id);
            return RedirectToPage("./Index");

        }
    }
}
