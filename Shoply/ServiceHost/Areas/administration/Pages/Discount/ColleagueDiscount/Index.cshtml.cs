using _01_framwork.Applicatin;
using DiscountManagement.Application.Contracts.ColleagueDiscount;
using DiscountManagement.Application.Contracts.CustomerDiscount;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using ShopManagement.Application.Contracts.Product;
using ShopManagement.Application.Contracts.ProductCategory;
using ShopManagement.Application.ProductCategorys;
using System.Collections.Generic;

namespace ServiceHost.Areas.administration.Pages.Discount.ColleagueDiscount
{
    public class IndexModel : PageModel
    {
        private readonly IProductApplication productApplication;
        private readonly IColleagueDiscountApplication colleagueDiscountApplication;
        public List<ColleagueDiscountviewModel> ColleagueDiscounts { get; set; }
        public ColleagueDiscountSearchModel SearchModel { get; set; }
        public SelectList Products { get; set; }
        public IndexModel(IProductApplication productApplication, IColleagueDiscountApplication colleagueDiscountApplication)
        {
            this.productApplication = productApplication;
            this.colleagueDiscountApplication = colleagueDiscountApplication;
        }

        public void OnGet(ColleagueDiscountSearchModel searchModel)
        {
            ColleagueDiscounts = colleagueDiscountApplication.Search(searchModel);
            Products = new SelectList(productApplication.GetProducts(), "Id", "Name");
        }
        public IActionResult OnGetCreate()
        {
            var command = new CreateColleagueDiscount();
            command.Products = productApplication.GetProducts();
            return Partial("./Create", command);
        }
        public JsonResult OnPostCreate(CreateColleagueDiscount command)
        {
            var result = colleagueDiscountApplication.Create(command);
            return new JsonResult(result);
        }
        public IActionResult OnGetEdit(long id)
        {
            var discount = colleagueDiscountApplication.GetDetals(id);
            discount.Products = productApplication.GetProducts();
            return Partial("./Edit", discount);
        }

        public JsonResult OnPostEdit(EditColleagueDiscount command)
        {
            var result = colleagueDiscountApplication.Edit(command);
            return new JsonResult(result);
        }

        public IActionResult OnGetActivate(long id)
        {
            colleagueDiscountApplication.Activate(id);
            return RedirectToPage("./Index");
        }
        public IActionResult OnGetRemove(long id)
        {
           
           colleagueDiscountApplication.Removed(id);
            return RedirectToPage("./Index");
        }

    }
}
