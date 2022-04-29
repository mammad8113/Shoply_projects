using _01_framwork.Applicatin;
using _01_Shoplyquery.Contracts.Product;
using CommentManagement.Application.Contracts.Comment;
using CommentManagement.Infrastructure.EfCore;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ServiceHost.Pages
{
    public class ProductModel : PageModel
    {
        public ProductQueryModel Product { get; set; }
        private readonly IProductQuery productQuery;
        private readonly ICommentApplication commentApplication;
        private readonly IAuthHelper authHelper;

        public ProductModel(IProductQuery productQuery, ICommentApplication commentApplication, IAuthHelper authHelper)
        {
            this.productQuery = productQuery;
            this.commentApplication = commentApplication;
            this.authHelper = authHelper;
        }
        public void OnGet(string id)
        {
            Product = productQuery.GetDetals(id);
        }
        public IActionResult OnPost(AddComment command,string productSlug)
        {
            command.type = CommentType.Product;
            command.Mobile = authHelper.CurrentAccountMobile();
           var result= commentApplication.Add(command);
            return RedirectToPage("./Product", new { id = productSlug });
        }
    }
}
