using _01_Shoplyquery.Contracts.Article;
using _01_Shoplyquery.Contracts.ArticleCategory;
using CommentManagement.Application.Contracts.Comment;
using CommentManagement.Infrastructure.EfCore;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Xml.Linq;

namespace ServiceHost.Pages
{
    public class ArticleModel : PageModel
    {
        public ArticleQueryModel Article { get; set; }
        public List<ArticleQueryModel> latestArticles { get; set; }
        public List<ArticleCategoryQueryModel> ArticleCategories { get; set; }
        private readonly IArticleQuery articleQuery;
        private readonly IArticleCategoryQuery articleCategoryQuery;
        private readonly ICommentApplication commentApplication;

        public ArticleModel(IArticleQuery articleQuery, IArticleCategoryQuery articleCategoryQuery, ICommentApplication commentApplication)
        {
            this.articleQuery = articleQuery;
            this.articleCategoryQuery = articleCategoryQuery;
            this.commentApplication = commentApplication;
        }

        public async void OnGet(string id)
        {
            Article = articleQuery.GetArticleDetals(id);
            latestArticles = articleQuery.LatestArticles();
            ArticleCategories = articleCategoryQuery.GetAll();
        }

        public IActionResult OnPost(AddComment command, string ArticleSlug)
        {
            command.type = CommentType.Article;
            var result = commentApplication.Add(command);

            return RedirectToPage("./Article", new { id = ArticleSlug });
        }
    }
}
