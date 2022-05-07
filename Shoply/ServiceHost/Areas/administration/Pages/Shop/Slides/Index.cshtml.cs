using _01_framwork.Applicatin;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using ShopManagement.Application.Contracts.Product;
using ShopManagement.Application.Contracts.ProductCategory;
using ShopManagement.Application.Contracts.ProductPicture;
using ShopManagement.Application.Contracts.Slide;
using ShopManagement.Application.ProductCategorys;
using System.Collections.Generic;

namespace ServiceHost.Areas.administration.Pages.Shop.Slides
{
    public class IndexModel : PageModel
    {
        private readonly ISlideApplication slideApplication;
        public List<SlideViewModel> Slides { get; set; }

        public IndexModel(ISlideApplication slideApplication)
        {
            this.slideApplication = slideApplication;
        }

        public void OnGet(ProductPictureSearchModel searchModel)
        {
            Slides = slideApplication.GetAll();

        }
        public IActionResult OnGetCreate()
        {
            var command = new CreateSlide();

            return Partial("./Create", command);
        }
        public JsonResult OnPostCreate(CreateSlide command)
        {
            var result = slideApplication.Create(command);
            return new JsonResult(result);
        }
        public IActionResult OnGetEdit(long id)
        {
            var product = slideApplication.GetDetals(id);

            return Partial("./Edit", product);
        }

        public JsonResult OnPostEdit(EditSlide command)
        {
            var result = slideApplication.Edit(command);
            return new JsonResult(result);
        }
        public IActionResult OnGetRemove(long id)
        {
            var result = slideApplication.Remove(id);
            return RedirectToPage("./Index");
        }
        public IActionResult OnGetActivate(long id)
        {
            var result = slideApplication.Activate(id);
            return RedirectToPage("./Index");

        }
    }
}
