using _01_framwork.Infrastructure;
using _01_Shoplyquery.Contracts.Address;
using _01_Shoplyquery.Contracts.Cart;
using _01_Shoplyquery.Contracts.Product;
using _01_Shoplyquery.Contracts.ProductCategory;
using _01_Shoplyquery.Contracts.Slide;
using _01_Shoplyquery.Query;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using ShopManagement.Application.Address;
using ShopManagement.Application.Contracts.Address;
using ShopManagement.Application.Contracts.Order;
using ShopManagement.Application.Contracts.Product;
using ShopManagement.Application.Contracts.ProductCategory;
using ShopManagement.Application.Contracts.ProductPicture;
using ShopManagement.Application.Contracts.Slide;
using ShopManagement.Application.Order;
using ShopManagement.Application.Producta;
using ShopManagement.Application.ProductCategorys;
using ShopManagement.Application.ProductPictures;
using ShopManagement.Application.Slider;
using ShopManagement.Domain.Address.Agg;
using ShopManagement.Domain.Order.Agg;
using ShopManagement.Domain.Product.Agg;
using ShopManagement.Domain.ProductCategory.Agg;
using ShopManagement.Domain.ProductCategory.Agg.Services;
using ShopManagement.Domain.ProductPicture.Agg;
using ShopManagement.Domain.Services;
using ShopManagement.Domain.Slide.Agg;
using ShopManagement.Infrastructure.EfCore;
using ShopManagement.Infrastructure.EfCore.Repository;
using ShopManagement.Infrastructure.Services.Acl;
using ShopManagement.Infrastructure.Services.AcountAcl;
using ShopManagment.Infrastructure.Config.Permissions;
using System;

namespace ShopManagment.Imfrastructure.Config
{
    public static class ShopManagementConfiguration
    {
        public static void AddShopSection(this IServiceCollection services, string ConnectionString)
        {
            services.AddTransient<IProductCategoryRepository, ProductCategoryRepository>();
            services.AddTransient<IProductCategoryApplication, ProductCategoryApplication>();
            services.AddTransient<IValidationProducatCategory, ValidationProductCategory>();
            services.AddTransient<IProductCategoryQuery, ProductCategoryQuey>();

            services.AddTransient<ShopManagement.Application.Contracts.Product.IProductApplication, ProductApplication>();
            services.AddTransient<IProductRepository, ProductRepository>();
            services.AddTransient<IProductQuery, ProductQuery>();

            services.AddTransient<IProductPictureRepository, ProductPictureRepository>();
            services.AddTransient<IProductPictureApplication, ProductPictureApplication>();


            services.AddTransient<IPermissionsExposer, ShopPermissionExposer>();

            services.AddTransient<ISlideApplication, SlideApplication>();
            services.AddTransient<ISlideRepository, SlideRepository>();

            services.AddTransient<IOrederRepository, OrderRepository>();
            services.AddTransient<ShopManagement.Application.Contracts.Order.IOrderApplication, OrderApplication>();

            services.AddTransient<IAddressQuery , AddressQuery>();

            services.AddSingleton<ICartServices, CartServices>();
            services.AddSingleton<ICityServices, CityServices>();

            services.AddTransient<ISlidequery, SlideQuey>();
            services.AddTransient<ICartCalculatorService, CartCalculatorService>();
            services.AddTransient<IShopInventoryAcl, ShopInventoryAcl>();

            services.AddTransient<IAddressApplication, AddressApplication>();
            services.AddTransient<IAddressRepository, AddressRepository>();

            services.AddTransient<IShopAcountAcl, ShopAcountAcl>();

            services.AddDbContext<ShopContext>(x => x.UseSqlServer(ConnectionString));
        }
    }
}
