using _01_framwork.Applicatin;
using System.Collections.Generic;

namespace BlogManagement.Application.Contracts.ArticleCategory
{
    public interface IArticleCategoryApplication
    {
        OperationResult Create(CreateArticleCategory command);
        OperationResult Edit(EditArticleCategory command);
        OperationResult Remove(long id);
        OperationResult Activate(long id);
        EditArticleCategory GetDetals(long id);
        List<ArticleCategoryViewModel> Search(ArticleCategorySearchModel searchModel);
        List<ArticleCategoryViewModel> GetAll();
    }
}
