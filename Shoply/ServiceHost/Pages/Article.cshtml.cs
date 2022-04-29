using _01_framwork.Applicatin;
using _01_Shoplyquery.Contracts.Article;
using _01_Shoplyquery.Contracts.ArticleCategory;
using AcountManagement.Application.Contracts.Acount;
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
        private readonly IAcountApplication acountApplication;
        private readonly IAuthHelper authHelper;
        public ArticleModel(IArticleQuery articleQuery, IArticleCategoryQuery articleCategoryQuery, ICommentApplication commentApplication,
           IAcountApplication acountApplication, IAuthHelper authHelper)
        {
            this.articleQuery = articleQuery;
            this.articleCategoryQuery = articleCategoryQuery;
            this.commentApplication = commentApplication;
            this.acountApplication = acountApplication;
            this.authHelper = authHelper;
        }

        public void OnGet(string id)
        {
            Article = articleQuery.GetArticleDetals(id);
            latestArticles = articleQuery.LatestArticles();
            ArticleCategories = articleCategoryQuery.GetAll();
        }

        public IActionResult OnPost(AddComment command, string ArticleSlug)
        {
            command.type = CommentType.Article;
            command.AcountId = authHelper.CurrentAccountId();
            var result = commentApplication.Add(command);

            return RedirectToPage("./Article", new { id = ArticleSlug });
        }
    }
}
