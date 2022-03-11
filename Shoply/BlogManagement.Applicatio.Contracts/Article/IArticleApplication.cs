using _01_framwork.Applicatin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogManagement.Application.Contracts.Article
{
    public interface IArticleApplication
    {
        OperationResult Create(CreateArticle command);
        OperationResult Edit(EditArticle command);
        OperationResult Remove(long id);
        OperationResult Activate(long id);
        EditArticle GetDetals(long id);
        List<ArticleViewModel> Search(ArticleSearchModel model);
    }
}
