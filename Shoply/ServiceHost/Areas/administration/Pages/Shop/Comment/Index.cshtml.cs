using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using ShopManagement.Application.Contracts.Comment;
using ShopManagement.Application.Contracts.Product;
using ShopManagement.Application.Contracts.ProductCategory;
using ShopManagement.Application.Contracts.ProductPicture;
using ShopManagement.Application.Contracts.Slide;
using ShopManagement.Application.ProductCategorys;
using System.Collections.Generic;

namespace ServiceHost.Areas.administration.Pages.Shop.Comment
{
    public class IndexModel : PageModel
    {
        public List<CommentViewModel> Comments { get; set; }
        public CommentSearchModel SearchModel { get; set; }
        public SelectList products { get; set; }
        private readonly ICommentApplication commentApplication;
        private readonly IProductApplication productApplication;
        public IndexModel(ICommentApplication commentApplication, IProductApplication productApplication)
        {
            this.commentApplication = commentApplication;
            this.productApplication = productApplication;
        }

        public void OnGet(CommentSearchModel searchModel)
        {
            products = new SelectList(productApplication.GetProducts(), "Id", "Name");
            Comments = commentApplication.Search(searchModel);
        }
        public IActionResult OnGetCanceld(long id)
        {
            var result = commentApplication.Canceld(id);

            return RedirectToPage("./Index");
        }
        public IActionResult OnGetConfirm(long id)
        {
            var result = commentApplication.Confirm(id);
            return RedirectToPage("./Index");
        }
    }
}
