using DiscountManagement.Application.Contracts.CustomerDiscount;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using ShopManagement.Application.Contracts.Product;
using ShopManagement.Application.Contracts.ProductCategory;
using ShopManagement.Application.ProductCategorys;
using System.Collections.Generic;

namespace ServiceHost.Areas.administration.Pages.Discount.CustomerDiscount
{
    public class IndexModel : PageModel
    {
        private readonly IProductApplication productApplication;
        private readonly ICustomerDiscountApplication customerDiscountApplication;
        public List<CustomerDiscountViewModel> CustomerDiscounts { get; set; }
        public CustomerDiscountSearchModel SearchModel { get; set; }
        public SelectList Products { get; set; }
        public IndexModel(IProductApplication productApplication, ICustomerDiscountApplication customerDiscountApplication)
        {
            this.productApplication = productApplication;
            this.customerDiscountApplication = customerDiscountApplication;
        }

        public void OnGet(CustomerDiscountSearchModel searchModel)
        {
            CustomerDiscounts = customerDiscountApplication.Search(searchModel);
            Products = new SelectList(productApplication.GetProducts(), "Id", "Name");
        }
        public IActionResult OnGetCreate()
        {
            var command = new CreateCustomerDiscount();
            command.Products = productApplication.GetProducts();
            return Partial("./Create", command);
        }
        public JsonResult OnPostCreate(CreateCustomerDiscount command)
        {
            var result = customerDiscountApplication.Create(command);
            return new JsonResult(result);
        }
        public IActionResult OnGetEdit(long id)
        {
            var discount = customerDiscountApplication.GetDetals(id);
            discount.Products = productApplication.GetProducts();
            return Partial("./Edit", discount);
        }

        public JsonResult OnPostEdit(EditCustomerDiscount command)
        {
            var result = customerDiscountApplication.Edit(command);
            return new JsonResult(result);
        }
       
    }
}
