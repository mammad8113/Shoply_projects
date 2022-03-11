using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01_Shoplyquery.Contracts.Article
{
    public interface IArticleQuery
    {
        ArticleQueryModel GetArticleDetals(string slug);
        List<ArticleQueryModel> LatestArticles();
    }
}
