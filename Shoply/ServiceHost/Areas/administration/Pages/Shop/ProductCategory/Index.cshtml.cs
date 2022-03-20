using _01_framwork.Infrastructure;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ShopManagement.Application.Contracts.ProductCategory;
using System.Collections.Generic;

namespace ServiceHost.Areas.administration.Pages.Shop.ProductCategory  
{
    [Authorize(Roles = Rols.Administrator + "," + Rols.ContentUploader)]
    public class IndexModel : PageModel
    {
        private readonly IProductCategoryApplication productCategoryApplication;
        public List<ProductCategoryViewModel> ProductCategories { get; set; }
        public ProductCategorySearchModel SearchModel { get; set; }

        public IndexModel(IProductCategoryApplication productCategoryApplication)
        {
            this.productCategoryApplication = productCategoryApplication;
        }

        public void OnGet(ProductCategorySearchModel searchModel,long id=0)
        {
            searchModel.Parent = id;
            ProductCategories = productCategoryApplication.Search(searchModel);
        }
        public IActionResult OnGetCreate(long id=0)
        {
            var category = new CreateProductCategory();
            category.GetAll = productCategoryApplication.GetProductCategories(id);
            return Partial("./Create",category );
        }
        public JsonResult OnPostCreate(CreateProductCategory command)
        {
            var result=productCategoryApplication.Create(command);
            return new JsonResult(result);
        }
        public IActionResult OnGetEdit(int id)
        {
            var productcategory = productCategoryApplication.GetDetals(id);
            return Partial("./Edit", productcategory);
        }

        public JsonResult OnPostEdit(EditProductCategory command)
        {
            if (ModelState.IsValid)
            {

            }
            var result=productCategoryApplication.Edit(command);
            return new JsonResult(result);
        }
        public IActionResult OnGetRemove(long id)
        {
            productCategoryApplication.Removed(id);
            return RedirectToPage("./Index");
        }
        public IActionResult OnGetActivate(long id)
        {
            productCategoryApplication.Activate(id);
            return RedirectToPage("./Index");
        }
    }
}
