using _01_framwork.Infrastructure;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using ShopManagement.Application.Contracts.Product;
using ShopManagement.Application.Contracts.ProductCategory;
using ShopManagement.Application.ProductCategorys;
using ShopManagment.Infrastructure.Config.Permissions;
using System.Collections.Generic;

namespace ServiceHost.Areas.administration.Pages.Shop.Product
{
    public class IndexModel : PageModel
    {
        private readonly IProductApplication productApplication;
        private readonly IProductCategoryApplication productCategoryApplication;
        public List<ProductViewModel> Products { get; set; }
        public CategorySearchModel SearchModel { get; set; }
        public SelectList productCategories { get; set; }
        public List<ProductCategoryViewModel> ProductCategories { get; set; }
        public IndexModel(IProductApplication productApplication, IProductCategoryApplication productCategoryApplication)
        {
            this.productApplication = productApplication;
            this.productCategoryApplication = productCategoryApplication;
        }

        [NeddsPermission((int)ShopPermission.ListProducts)]
        public void OnGet(CategorySearchModel searchModel,long ProductCategoryId)
        {
            searchModel.ProductCategoryId = ProductCategoryId;
            Products = productApplication.Search(searchModel);
            ProductCategories = productCategoryApplication.GetProductCategories();
            productCategories = new SelectList(productCategoryApplication.GetProductCategories(0), "Id", "Name");
        }
        [NeddsPermission((int)ShopPermission.CreateProduct)]
        public IActionResult OnGetCreate()
        {
            var command = new CreateProduct();
            command.ProductCategories = productCategoryApplication.GetProductCategories();

            return Partial("./Create", command);
        }

        [NeddsPermission((int)ShopPermission.CreateProduct)]
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
        [NeddsPermission((int)ShopPermission.RemoveProduct)]
        public IActionResult OnGetRemove(long id)
        {
            var result = productApplication.Remove(id);
            return RedirectToPage("./Index");
        }
        [NeddsPermission((int)ShopPermission.ActivateProduct)]
        public IActionResult OnGetActivate(long id)
        {
            var result = productApplication.Activate(id);
            return RedirectToPage("./Index");

        }
    }
}
