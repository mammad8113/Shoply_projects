using _01_framwork.Applicatin;
using BlogManagement.Application.Contracts.Article;
using BlogManagement.Application.Contracts.ArticleCategory;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace ServiceHost.Areas.administration.Pages.Blog.Article
{
    public class CreateModel : PageModel
    {
        private readonly IArticleApplication articleApplication;
        private readonly IArticleCategoryApplication articleCategoryApplication;
        public SelectList ArticleCategories { get; set; }
        public CreateArticle command { get; set; }
        public CreateModel(IArticleApplication articleApplication, IArticleCategoryApplication articleCategoryApplication)
        {
            this.articleApplication = articleApplication;
            this.articleCategoryApplication = articleCategoryApplication;
        }

        public void OnGet()
        {
            ArticleCategories = new SelectList(articleCategoryApplication.GetAll(), "Id", "Name");
        }
        public IActionResult OnPost(CreateArticle command)
        {
            articleApplication.Create(command);
            return RedirectToPage("./Index");
        }
    }
}
