using _0_Framework.Application;
using _01_framwork.Applicatin;
using BlogManagement.Application.Contracts.Article;
using BlogManagement.Domain.Article.Agg;
using BlogManagement.Domain.ArticleCategory.Agg;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogManagement.Application.Article.App
{
    public class ArticleApplication : IArticleApplication
    {
        private readonly IArticleRepository articleRepository;
        private readonly IArticleCategoryRepository articleCategoryRepository;
        private readonly IFileUploader fileUploader;
        public ArticleApplication(IArticleRepository articleRepository, IFileUploader fileUploader, IArticleCategoryRepository articleCategoryRepository)
        {
            this.articleRepository = articleRepository;
            this.articleCategoryRepository = articleCategoryRepository;
            this.fileUploader = fileUploader;
        }

        public OperationResult Activate(long id)
        {
            var result = new OperationResult();
            var article = articleRepository.Get(id);
            if (article == null)
                return result.Faild(ApplicationMessage.NullFildMessage);

            article.Activate();
            try
            {
                articleRepository.Save();
            }
            catch
            {
                return result.Faild(ApplicationMessage.UnspecifiedError);
            }
            return result.Success();
        }

        public OperationResult Create(CreateArticle command)
        {
            var result = new OperationResult();
            if (articleRepository.Exist(x => x.Title == command.Title))
                return result.Faild(ApplicationMessage.DoblicatedMessage);

            var slug = command.Slug.Slugify();
            var category = articleCategoryRepository.GetSlug(command.ArticleCategoryId);
            var path = $"ArticleCategory/{category}/{slug}";
            var picture = fileUploader.Upload(command.Picture, path);

            var article = new Domain.Article.Agg.Article(command.Title, picture, command.ShortDescription, command.Description,
             command.PublishDate.ToGeorgianDateTime(), slug, command.KeyWords, command.MetaDescription,
             command.CanonicalAddress, command.ArticleCategoryId);

            articleRepository.Create(article);
            try
            {
                articleRepository.Save();
            }
            catch
            {
                return result.Faild(ApplicationMessage.NullFildMessage);
            }
            return result.Success();
        }

        public OperationResult Edit(EditArticle command)
        {
            var result = new OperationResult();

            var article = articleRepository.Get(command.Id);
            if (article == null)
                return result.Faild(ApplicationMessage.NullMessage);

            if (articleRepository.Exist(x => x.Title == command.Title && x.Id != command.Id))
                return result.Faild(ApplicationMessage.DoblicatedMessage);

            var slug = command.Slug.Slugify();
            var category = articleCategoryRepository.GetSlug(command.ArticleCategoryId);
            var path = $"{category}/{slug}";
            var picture = fileUploader.Upload(command.Picture, path);

            article.Edit(command.Title, picture, command.ShortDescription, command.Description, command.PublishDate.ToGeorgianDateTime(),
               slug, command.KeyWords, command.MetaDescription, command.CanonicalAddress, command.ArticleCategoryId);
            try
            {
                articleRepository.Save();
            }
            catch
            {
                return result.Faild(ApplicationMessage.NullFildMessage);
            }
            return result.Success();
        }

        public EditArticle GetDetals(long id)
        {
            return articleRepository.GetDetals(id);
        }

        public OperationResult Remove(long id)
        {
            var result = new OperationResult();
            var article = articleRepository.Get(id);
            if (article == null)
                return result.Faild(ApplicationMessage.NullFildMessage);

            article.Remove();
            try
            {
                articleRepository.Save();
            }
            catch
            {
                return result.Faild(ApplicationMessage.UnspecifiedError);
            }
            return result.Success();
        }

        public List<ArticleViewModel> Search(ArticleSearchModel model)
        {
            return articleRepository.Search(model);
        }
    }
}
