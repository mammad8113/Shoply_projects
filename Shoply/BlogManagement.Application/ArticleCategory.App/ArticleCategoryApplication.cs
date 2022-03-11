using _0_Framework.Application;
using _01_framwork.Applicatin;
using BlogManagement.Application.Contracts.ArticleCategory;
using BlogManagement.Domain.ArticleCategory.Agg;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogManagement.Application.ArticleCategory.App
{
    public class ArticleCategoryApplication : IArticleCategoryApplication
    {
        private readonly IFileUploader fileUploader;
        private readonly IArticleCategoryRepository articleCategoryRepository;

        public ArticleCategoryApplication(IArticleCategoryRepository articleCategoryRepository, IFileUploader fileUploader)
        {
            this.articleCategoryRepository = articleCategoryRepository;
            this.fileUploader = fileUploader;
        }

        public OperationResult Activate(long id)
        {
            var result = new OperationResult();
            var category = articleCategoryRepository.Get(id);
            if (category == null)
                return result.Faild(ApplicationMessage.NullFildMessage);

            category.Activate();
            articleCategoryRepository.Save();
            return result.Success();
        }

        public OperationResult Create(CreateArticleCategory command)
        {
            var result = new OperationResult();
            if (articleCategoryRepository.Exist(x => x.Name == command.Name))
                return result.Faild(ApplicationMessage.DoblicatedMessage);

            var slug = command.Slug.Slugify();
            var paht = $"ArticleCategory/{slug}";

            var picturePath = fileUploader.Upload(command.Picture, paht);
            var articleCategory = new BlogManagement.Domain.ArticleCategory.Agg.ArticleCategory(command.Name, command.ShortDescription,
                picturePath,command.PictureAlt,command.PictureTitle, command.Description, command.ShowOrder, slug, command.KeyWords, command.MetaDescription,
                command.CanonicalAddress);

            articleCategoryRepository.Create(articleCategory);
            articleCategoryRepository.Save();
            return result.Success();

        }

        public OperationResult Edit(EditArticleCategory command)
        {
            var result = new OperationResult();

            var category = articleCategoryRepository.Get(command.Id);
            if (category == null)
                return result.Faild(ApplicationMessage.NullMessage);

            if (articleCategoryRepository.Exist(x => x.Name == command.Name && x.Id != command.Id))
                return result.Faild(ApplicationMessage.DoblicatedMessage);

            var slug = command.Slug.Slugify();
            var paht = $"Blog/{slug}";
            var picturePath = fileUploader.Upload(command.Picture, paht);

            category.Edit(command.Name, command.ShortDescription,
                  picturePath,command.PictureAlt,command.PictureTitle, command.Description, command.ShowOrder, slug, command.KeyWords, command.MetaDescription,
                  command.CanonicalAddress);

            articleCategoryRepository.Save();
            return result.Success();
        }

        public List<ArticleCategoryViewModel> GetAll()
        {
           return articleCategoryRepository.GetSelectList();
        }

        public EditArticleCategory GetDetals(long id)
        {
            return articleCategoryRepository.GetDetals(id);
        }

        public OperationResult Remove(long id)
        {
            var result = new OperationResult();
            var category = articleCategoryRepository.Get(id);
            if (category == null)
                return result.Faild(ApplicationMessage.NullFildMessage);

            category.Remove();
            articleCategoryRepository.Save();
            return result.Success();
        }

        public List<ArticleCategoryViewModel> Search(ArticleCategorySearchModel searchModel)
        {
            return articleCategoryRepository.Search(searchModel);
        }
    }
}
