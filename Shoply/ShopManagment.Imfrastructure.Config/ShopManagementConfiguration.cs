using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using ShopManagement.Application.Contracts.ProductCategory;
using ShopManagement.Application.ProductCategorys;
using ShopManagement.Domain.ProductCategory.Agg;
using ShopManagement.Domain.ProductCategory.Agg.Services;
using ShopManagement.Infrastructure.EfCore;
using ShopManagement.Infrastructure.EfCore.Repository;
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
            services.AddDbContext<ShopContext>(x => x.UseSqlServer(ConnectionString));
        }
    }
}
