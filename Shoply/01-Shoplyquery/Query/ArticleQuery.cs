using _0_Framework.Application;
using _01_Shoplyquery.Contracts.Article;
using _01_Shoplyquery.Contracts.Product;
using BlogManagement.Infrastructure.EfCore;
using CommentManagement.Domain.Comment.Agg;
using CommentManagement.Infrastructure.EfCore;
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
        private readonly CommentContext commentContext;

        public ArticleQuery(BlogContext blogContext, CommentContext commentContext)
        {
            this.blogContext = blogContext;
            this.commentContext = commentContext;
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

            if (article.KeyWords != null)
                article.KeyWordsList = article.KeyWords.Split(",").ToList();

            var comments = commentContext.Comments.Where(x => x.IsConfirm)
                .Where(x => !x.IsCanceld)
                .Where(x => x.Type == CommentType.Article)
                .Where(x => x.OwnerRecordId == article.Id)
                .Select(x => new CommentQueryModel
                {
                    Id = x.Id,
                    Name = x.Name,
                    Mobile=x.Mobile,
                    Message = x.Message,
                    ParentId = x.ParentId,
                    Children=MappChild(x.Children),
                    CreationDate = x.CreationDate.ToFarsi()
                }).OrderByDescending(x => x.Id).ToList();

            if (comments != null)
                article.Comments = comments;


            foreach (var comment in comments)
            {
                if (comment.ParentId > 0 || comment.ParentId != null)
                    comment.Parent = comments.FirstOrDefault(x => x.Id == comment.ParentId)?.Name;
            }

            return article;
        }

        private static List<CommentQueryModel> MappChild(List<Comment> children)
        {
            return children.Select(x=> new CommentQueryModel
            {
                Id=x.Id,
                Name=x.Name,
                Message=x.Message,
                Mobile=x.Mobile,
            }).OrderByDescending(x=>x.Id).ToList();
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
