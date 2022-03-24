﻿using _01_framwork.Infrastructure;
using _01_Shoplyquery.Contracts.Cart;
using _01_Shoplyquery.Contracts.Product;
using _01_Shoplyquery.Contracts.ProductCategory;
using _01_Shoplyquery.Contracts.Slide;
using _01_Shoplyquery.Query;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using ShopManagement.Application.Contracts.Product;
using ShopManagement.Application.Contracts.ProductCategory;
using ShopManagement.Application.Contracts.ProductPicture;
using ShopManagement.Application.Contracts.Slide;
using ShopManagement.Application.Producta;
using ShopManagement.Application.ProductCategorys;
using ShopManagement.Application.ProductPictures;
using ShopManagement.Application.Slider;
using ShopManagement.Domain.Product.Agg;
using ShopManagement.Domain.ProductCategory.Agg;
using ShopManagement.Domain.ProductCategory.Agg.Services;
using ShopManagement.Domain.ProductPicture.Agg;
using ShopManagement.Domain.Slide.Agg;
using ShopManagement.Infrastructure.EfCore;
using ShopManagement.Infrastructure.EfCore.Repository;
using ShopManagment.Infrastructure.Config.Permissions;
using System;

namespace ShopManagment.Imfrastructure.Config
{
    public class ShopManagementConfiguration
    {
        public static void Configur(IServiceCollection services, string ConnectionString)
        {
            services.AddTransient<IProductCategoryRepository, ProductCategoryRepository>();
            services.AddTransient<IProductCategoryApplication, ProductCategoryApplication>();
            services.AddTransient<IValidationProducatCategory, ValidationProductCategory>();
            services.AddTransient<IProductCategoryQuery, ProductCategoryQuey>();

            services.AddTransient<IProductApplication, ProductApplication>();
            services.AddTransient<IProductRepository, ProductRepository>();
            services.AddTransient<IProductQuery, ProductQuery>();

            services.AddTransient<IProductPictureRepository, ProductPictureRepository>();
            services.AddTransient<IProductPictureApplication, ProductPictureApplication>();


            services.AddTransient<IPermissionsExposer, ShopPermissionExposer>();

            services.AddTransient<ISlideApplication, SlideApplication>();
            services.AddTransient<ISlideRepository, SlideRepository>();
            services.AddTransient<ISlidequery, SlideQuey>();
            services.AddTransient<ICartCalculatorService, CartCalculatorService>();



            services.AddDbContext<ShopContext>(x => x.UseSqlServer(ConnectionString));
        }
    }
}
