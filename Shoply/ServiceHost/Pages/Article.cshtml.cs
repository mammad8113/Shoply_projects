using _01_Shoplyquery.Contracts.Article;
using _01_Shoplyquery.Contracts.ArticleCategory;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Collections.Generic;

namespace ServiceHost.Pages
{
    public class ArticleModel : PageModel
    {
        public ArticleQueryModel Article { get; set; }
        public List<ArticleQueryModel> latestArticles { get; set; }
        public List<ArticleCategoryQueryModel> ArticleCategories { get; set; }
        private readonly IArticleQuery articleQuery;
        private readonly IArticleCategoryQuery articleCategoryQuery;
        public ArticleModel(IArticleQuery articleQuery, IArticleCategoryQuery articleCategoryQuery)
        {
            this.articleQuery = articleQuery;
            this.articleCategoryQuery = articleCategoryQuery;
        }

        public void OnGet(string id)
        {
            Article = articleQuery.GetArticleDetals(id);
            latestArticles = articleQuery.LatestArticles();
            ArticleCategories = articleCategoryQuery.GetAll();
        }
    }
}
