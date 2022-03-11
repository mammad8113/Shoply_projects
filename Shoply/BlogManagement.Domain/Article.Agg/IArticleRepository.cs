using _01_framwork.Domain;
using BlogManagement.Application.Contracts.Article;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogManagement.Domain.Article.Agg
{
    public interface IArticleRepository : IRepository<long, Article>
    {
        EditArticle GetDetals(long id);
        List<ArticleViewModel> Search(ArticleSearchModel model);
    }
}
