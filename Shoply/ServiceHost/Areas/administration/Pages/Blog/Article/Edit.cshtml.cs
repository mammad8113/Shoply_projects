using BlogManagement.Application.Contracts.Article;
using BlogManagement.Application.Contracts.ArticleCategory;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace ServiceHost.Areas.administration.Pages.Blog.Article
{
    public class EditModel : PageModel
    {
        private readonly IArticleApplication articleApplication;
        private readonly IArticleCategoryApplication articleCategoryApplication;
        public SelectList ArticleCategories { get; set; }
        
        public EditArticle command { get; set; }
        public EditModel(IArticleApplication articleApplication, IArticleCategoryApplication articleCategoryApplication)
        {
            this.articleApplication = articleApplication;
            this.articleCategoryApplication = articleCategoryApplication;
        }
        public void OnGet(long id)
        {
            command = articleApplication.GetDetals(id);
            ArticleCategories = new SelectList(articleCategoryApplication.GetAll(), "Id", "Name");
        }
        public IActionResult OnPost(EditArticle command)
        {
            articleApplication.Edit(command);
            return RedirectToPage("./Index");
        }
    }
}
