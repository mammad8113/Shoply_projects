using Microsoft.EntityFrameworkCore;
using ShopManagement.Domain.Product.Agg;
using ShopManagement.Domain.ProductCategory;
using ShopManagement.Domain.ProductPicture.Agg;
using ShopManagement.Domain.Slide.Agg;
using ShopManagement.Infrastructure.EfCore.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopManagement.Infrastructure.EfCore
{
    public class ShopContext : DbContext
    {
        public DbSet<ProductCategory> ProductCategories { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<ProductPicture> ProductPictures { get; set; }
        public DbSet<Slide> Slides { get; set; }

        public ShopContext(DbContextOptions<ShopContext> options) : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            var assembily = typeof(ProductCategoryMapping).Assembly;
            modelBuilder.ApplyConfigurationsFromAssembly(assembily);
            base.OnModelCreating(modelBuilder);
        }
    }
}
