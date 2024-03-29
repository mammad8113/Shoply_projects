﻿using BlogManagement.Application.Contracts.Article;
using BlogManagement.Application.Contracts.ArticleCategory;
using BlogManagement.Application.Article.App;
using BlogManagement.Application.ArticleCategory.App;
using BlogManagement.Domain.Article.Agg;
using BlogManagement.Domain.ArticleCategory.Agg;
using BlogManagement.Infrastructure.EfCore;
using BlogManagement.Infrastructure.EfCore.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using _01_Shoplyquery.Contracts.Article;
using _01_Shoplyquery.Query;
using _01_Shoplyquery.Contracts.ArticleCategory;

namespace BlogManagement.Infrastructure.Config
{
    public static class BlogBootstrapper
    {
        public static void AddBlogSection(this IServiceCollection services, string connectionString)
        {
            services.AddTransient<IArticleCategoryApplication, ArticleCategoryApplication>();
            services.AddTransient<IArticleCategoryRepository, ArticleCategoryRepository>();

            services.AddTransient<IArticleRepository, ArticleRepository>();
            services.AddTransient<IArticleApplication, ArticleApplication>();

            services.AddTransient<IArticleQuery, ArticleQuery>();
            services.AddTransient<IArticleCategoryQuery, ArticleCategoryQuery>();

            services.AddDbContext<BlogContext>(x => x.UseSqlServer(connectionString));
        }
    }
}
