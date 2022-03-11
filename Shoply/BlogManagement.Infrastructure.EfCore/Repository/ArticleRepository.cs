using _0_Framework.Application;
using _01_framwork.Infrastructure;
using BlogManagement.Application.Contracts.Article;
using BlogManagement.Domain.Article.Agg;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogManagement.Infrastructure.EfCore.Repository
{
    public class ArticleRepository : BaseRepository<long, Article>, IArticleRepository
    {
        private readonly BlogContext blogContext;

        public ArticleRepository(BlogContext blogContext) : base(blogContext)
        {
            this.blogContext = blogContext;
        }

        public EditArticle GetDetals(long id)
        {
            return blogContext.Articles.Select(x => new EditArticle
            {
                Id = x.Id,
                Title = x.Title,
                ShortDescription = x.ShortDescription,
                Description = x.Description,
                MetaDescription = x.MetaDescription,
                PublishDate = x.PublishDate.ToFarsi(),
                KeyWords = x.KeyWords,
                Slug = x.Slug,
                CanonicalAddress = x.CanonicalAddress,
                ArticleCategoryId = x.ArticleCategoryId,
            }).FirstOrDefault(x => x.Id == id);
        }

        public List<ArticleViewModel> Search(ArticleSearchModel model)
        {
            var query = blogContext.Articles.Include(x => x.ArticleCategory).Select(x => new ArticleViewModel
            {
                Id = x.Id,
                Title = x.Title,
                ArticleCategoryId = x.ArticleCategoryId,
                CreationDate = x.CreationDate.ToFarsi(),
                ArticleCategory = x.ArticleCategory.Name,
                PublishDate = x.PublishDate.ToFarsi(),
                IsRemove = x.IsRemove,
                Picture = x.Picture
            });

            if (!string.IsNullOrWhiteSpace(model.Title))
                query = query.Where(x => x.Title.Contains(model.Title));

            if (model.ArticleCategoryId > 0)
                query = query.Where(x => x.ArticleCategoryId == model.ArticleCategoryId);

            return query.OrderByDescending(x => x.Id).ToList();
        }
    }
}
