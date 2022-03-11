using BlogManagement.Application.Contracts.Article;
using BlogManagement.Application.Contracts.ArticleCategory;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using ShopManagement.Application.Contracts.Product;
using ShopManagement.Application.Contracts.ProductCategory;
using ShopManagement.Application.ProductCategorys;
using System.Collections.Generic;

namespace ServiceHost.Areas.administration.Pages.Blog.Article
{
    public class IndexModel : PageModel
    {
        private readonly IArticleCategoryApplication articleCategoryApplication;
        private readonly IArticleApplication articleApplication;

        public IndexModel(IArticleCategoryApplication articleCategoryApplication, IArticleApplication articleApplication)
        {
            this.articleCategoryApplication = articleCategoryApplication;
            this.articleApplication = articleApplication;
        }
        public List<ArticleViewModel> Articles { get; set; }
        public ArticleSearchModel SearchModel { get; set; }
        public SelectList ArticleCategories { get; set; }


        public void OnGet(ArticleSearchModel searchModel)
        {
            Articles = articleApplication.Search(searchModel);
            ArticleCategories = new SelectList(articleCategoryApplication.GetAll(), "Id", "Name");
            var ip = HttpContext.Connection.RemoteIpAddress;

        }
        public IActionResult OnGetRemove(long id)
        {
            var result = articleApplication.Remove(id);
            return RedirectToPage("./Index");
        }
        public IActionResult OnGetActivate(long id)
        {
            var result = articleApplication.Activate(id);
            return RedirectToPage("./Index");

        }
    }
}
