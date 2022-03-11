
using _01_Shoplyquery.Contracts.Article;
using Microsoft.AspNetCore.Mvc;

namespace ServiceHost.ViewComponents
{
    public class LatestArticleViewComponent : ViewComponent
    {
        private readonly IArticleQuery articleQuery;

        public LatestArticleViewComponent(IArticleQuery articleQuery)
        {
            this.articleQuery = articleQuery;
        }
        public IViewComponentResult Invoke()
        {
            var article = articleQuery.LatestArticles();
            return View(article);
        }
    }
}
