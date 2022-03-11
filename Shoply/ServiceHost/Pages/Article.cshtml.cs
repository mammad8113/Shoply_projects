using _01_Shoplyquery.Contracts.Article;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ServiceHost.Pages
{
    public class ArticleModel : PageModel
    {
        public ArticleQueryModel Article { get; set; }
        private readonly IArticleQuery articleQuery;

        public ArticleModel(IArticleQuery articleQuery)
        {
            this.articleQuery = articleQuery;
        }

        public void OnGet(string id)
        {
            Article = articleQuery.GetArticleDetals(id);
        }
    }
}
