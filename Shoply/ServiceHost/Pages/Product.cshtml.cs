using _01_Shoplyquery.Contracts.Product;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ShopManagement.Application.Contracts.Comment;

namespace ServiceHost.Pages
{
    public class ProductModel : PageModel
    {
        public ProductQueryModel Product { get; set; }
        private readonly IProductQuery productQuery;
        private readonly ICommentApplication commentApplication;

        public ProductModel(IProductQuery productQuery, ICommentApplication commentApplication)
        {
            this.productQuery = productQuery;
            this.commentApplication = commentApplication;
        }

        public void OnGet(string id)
        {
            Product = productQuery.GetDetals(id);
        }
        public IActionResult OnPost(AddComment command,string productSlug)
        {
           var result= commentApplication.Add(command);
            return RedirectToPage("./Product", new { id = productSlug });
        }
    }
}
