using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using ShopManagement.Application.Contracts.Product;
using ShopManagement.Application.Contracts.ProductCategory;
using ShopManagement.Application.Contracts.ProductPicture;
using ShopManagement.Application.ProductCategorys;
using System.Collections.Generic;

namespace ServiceHost.Areas.administration.Pages.Shop.ProductPicture
{
    public class IndexModel : PageModel
    {
        private readonly IProductPictureApplication productPictureApplication;
        private readonly IProductApplication productApplication;
        public List<ProductPictureViewModel> ProductPictures { get; set; }
        public ProductPictureSearchModel SearchModel { get; set; }
        public SelectList products { get; set; }
        public IndexModel(IProductApplication productApplication, IProductPictureApplication productPictureApplication)
        {
            this.productApplication = productApplication;
            this.productPictureApplication = productPictureApplication;
        }

        public void OnGet(ProductPictureSearchModel searchModel)
        {
            ProductPictures = productPictureApplication.Search(searchModel);
            products = new SelectList(productApplication.GetProducts(), "Id", "Name");
        }
        public IActionResult OnGetCreate()
        {
            var command = new CreateProductPicture();
            command.Products = productApplication.GetProducts();
            return Partial("./Create", command);
        }
        public JsonResult OnPostCreate(CreateProductPicture command)
        {
            var result = productPictureApplication.Create(command);
            return new JsonResult(result);
        }
        public IActionResult OnGetEdit(int id)
        {
            var product = productPictureApplication.GetDetals(id);
            product.Products = productApplication.GetProducts();
            return Partial("./Edit", product);
        }

        public JsonResult OnPostEdit(EditProductPicture command)
        {
            var result = productPictureApplication.Edit(command);
            return new JsonResult(result);
        }
        public IActionResult OnGetRemove(long id)
        {
            var result = productPictureApplication.Remove(id);
            return RedirectToPage("./Index");
        }
        public IActionResult OnGetActivate(long id)
        {
            var result = productPictureApplication.Activate(id);
            return RedirectToPage("./Index");

        }
    }
}
