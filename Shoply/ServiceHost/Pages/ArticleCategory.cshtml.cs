using _01_Shoplyquery.Contracts.Article;
using _01_Shoplyquery.Contracts.ArticleCategory;
using _01_Shoplyquery.Query;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Collections.Generic;

namespace ServiceHost.Pages
{
    public class ArticleCategoryModel : PageModel
    {
        public ArticleCategoryQueryModel ArticleCategory { get; set; }
        public List<ArticleCategoryQueryModel> ArticleCategories { get; set; }
        public List<ArticleQueryModel> LatestArticle { get; set; }


        private readonly IArticleCategoryQuery articleCategoryQuery;
        private readonly IArticleQuery articleQuery;


        public ArticleCategoryModel(IArticleCategoryQuery articleCategoryQuery, IArticleQuery articleQuery)
        {
            this.articleCategoryQuery = articleCategoryQuery;
            this.articleQuery = articleQuery;
        }

        public void OnGet(string id)
        {
            ArticleCategory = articleCategoryQuery.GetArticleCategory(id);
            ArticleCategories = articleCategoryQuery.GetAll();
            LatestArticle = articleQuery.LatestArticles();
        }
    }
}
