﻿using _0_Framework.Application;
using _01_framwork.Infrastructure;
using BlogManagement.Application.Contracts.ArticleCategory;
using BlogManagement.Domain.ArticleCategory.Agg;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogManagement.Infrastructure.EfCore.Repository
{
    public class ArticleCategoryRepository : BaseRepository<long, ArticleCategory>, IArticleCategoryRepository
    {
        private readonly BlogContext blogContext;

        public ArticleCategoryRepository(BlogContext blogContext) : base(blogContext)
        {
            this.blogContext = blogContext;
        }

        public EditArticleCategory GetDetals(long id)
        {
            return blogContext.ArticleCategories.Select(x => new EditArticleCategory
            {
                Id = x.Id,
                Name = x.Name,
                PictureAlt = x.PictureAlt,
                PictureTitle = x.PictureTitle,
                Description = x.Description,
                ShortDescription = x.ShortDescription,
                ShowOrder = x.ShowOrder,
                Slug = x.Slug,
                MetaDescription = x.MetaDescription,
                CanonicalAddress = x.CanonicalAddress,
                KeyWords = x.KeyWords,

            }).FirstOrDefault(x => x.Id == id);
        }

        public List<ArticleCategoryViewModel> Search(ArticleCategorySearchModel searchModel)
        {
            var query = blogContext.ArticleCategories.Include(x => x.Articles).Select(x => new ArticleCategoryViewModel
            {
                Id = x.Id,
                Name = x.Name,
                Description = x.Description,
                ShortDescription = x.ShortDescription,
                IsRemove = x.IsRemove,
                ShowOrder = x.ShowOrder,
                Slug = x.Slug,
                Picture = x.Picture,
                CreationDate = x.CreationDate.ToFarsi(),
                ArticleCount = x.Articles.Count,
            });

            if (!string.IsNullOrWhiteSpace(searchModel.Name))
                query = query.Where(x => x.Name.Contains(searchModel.Name));

            return query.OrderByDescending(x => x.Id).ToList();
        }

        public string GetSlug(long id)
        {
            //var category = blogContext.ArticleCategories.Select(x => new { x.Id, x.Slug }).FirstOrDefault(x => x.Id == id);
            //string slug = null;
            //if (category != null)
            //{
            //    slug = category.Slug;
            //}
            //return slug;

            var category = blogContext.ArticleCategories.Select(x => new { x.Id, x.Slug }).FirstOrDefault(x => x.Id == id);
            return category?.Slug;

        }

        public List<ArticleCategoryViewModel> GetSelectList()
        {
            return blogContext.ArticleCategories.Select(x => new ArticleCategoryViewModel
            {
                Id = x.Id,
                Name = x.Name,
                Description = x.Description,
                ShortDescription = x.ShortDescription,
                IsRemove = x.IsRemove,
                ShowOrder = x.ShowOrder,
                Slug = x.Slug,
                Picture = x.Picture,
                CreationDate = x.CreationDate.ToFarsi()

            }).OrderByDescending(x => x.Id).ToList();
        }
    }
}
