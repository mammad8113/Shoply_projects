using _0_Framework.Application;
using _01_Shoplyquery.Contracts.Article;
using BlogManagement.Infrastructure.EfCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01_Shoplyquery.Query
{
    public class ArticleQuery : IArticleQuery
    {
        private readonly BlogContext blogContext;

        public ArticleQuery(BlogContext blogContext)
        {
            this.blogContext = blogContext;
        }

        public ArticleQueryModel GetArticleDetals(string slug)
        {
            var article = blogContext.Articles.Include(x => x.ArticleCategory).Where(x => !x.IsRemove && x.PublishDate <= DateTime.Now).
                  Select(x => new ArticleQueryModel
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
                  }).AsNoTracking().FirstOrDefault(x => x.Slug == slug);

            article.KeyWordsList = article.KeyWords.Split(",").ToList();

            return article;
        }

        public List<ArticleQueryModel> LatestArticles()
        {
            return blogContext.Articles.Include(x => x.ArticleCategory).Where(x => !x.IsRemove && x.PublishDate <= DateTime.Now).Select(x => new ArticleQueryModel
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
            }).OrderByDescending(x => x.Id).Take(5).AsNoTracking().ToList();
        }
    }
}
