using _0_Framework.Application;
using _01_Shoplyquery.Contracts.Article;
using _01_Shoplyquery.Contracts.ArticleCategory;
using BlogManagement.Domain.Article.Agg;
using BlogManagement.Infrastructure.EfCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01_Shoplyquery.Query
{
    public class ArticleCategoryQuery : IArticleCategoryQuery
    {
        private readonly BlogContext blogContext;

        public ArticleCategoryQuery(BlogContext blogContext)
        {
            this.blogContext = blogContext;
        }

        public List<ArticleCategoryQueryModel> GetAll()
        {
            return blogContext.ArticleCategories.Include(x => x.Articles).Where(x => !x.IsRemove).Select(x => new ArticleCategoryQueryModel
            {
                Id = x.Id,
                Name = x.Name,
                Picture = x.Picture,
                PictureAlt = x.PictureAlt,
                PictureTitle = x.PictureTitle,
                Slug = x.Slug,
                KeyWords = x.KeyWords,
                MetaDescription = x.MetaDescription,
                Description = x.Description,
                IsRemove = x.IsRemove,
                ShowOrder = x.ShowOrder,
                CanonicalAddress = x.CanonicalAddress,
                ArticleCount = x.Articles.Count,
            }).OrderByDescending(x => x.Id).ToList();
        }

        public ArticleCategoryQueryModel GetArticleCategory(string slug)
        {
            var category= blogContext.ArticleCategories.Where(x => !x.IsRemove).Include(x => x.Articles).ThenInclude(x=>x.ArticleCategory).Select(x => new ArticleCategoryQueryModel
            {
                Id = x.Id,
                Name = x.Name,
                CanonicalAddress = x.CanonicalAddress,
                IsRemove = x.IsRemove,
                KeyWords = x.KeyWords,
                MetaDescription = x.MetaDescription,
                ShowOrder = x.ShowOrder,
                Slug = x.Slug,
                Picture = x.Picture,
                PictureAlt = x.PictureAlt,
                PictureTitle = x.PictureTitle,
                ArticleCount = x.Articles.Count,
                Articles = MappArticle(x.Articles)
            }).FirstOrDefault(x => x.Slug == slug);

            category.KeyWordsList = category.KeyWords.Split(",").ToList();

            return category;
        }

        private static List<ArticleQueryModel> MappArticle(List<Article> articles)
        {
            return articles.Where(x=>!x.IsRemove).Select(x => new ArticleQueryModel
            {
                Id = x.Id,
                Title = x.Title,
                Picture = x.Picture,
                PictureAlt = x.PictureAlt,
                PictureTitle = x.PictureTitle,
                ShortDescription = x.ShortDescription,
                Description = x.Description,
                Slug = x.Slug,
                KeyWords = x.KeyWords,
                MetaDescription = x.MetaDescription,
                CanonicalAddress = x.CanonicalAddress,
                CategoryId = x.ArticleCategoryId,
                CategoryName = x.ArticleCategory.Name,
                CategorySlug = x.ArticleCategory.Slug,
                PublishDate = x.PublishDate.ToFarsi(),

            }).OrderByDescending(x => x.Id).ToList();
        }
    }
}
