﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ShopManagement.Domain.Product.Agg;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopManagement.Infrastructure.EfCore.Mapping
{
    public class ProductMapping : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.ToTable("Products");
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Name).HasMaxLength(255).IsRequired();
            builder.Property(x => x.Code).HasMaxLength(50).IsRequired();
            builder.Property(x => x.Picture).HasMaxLength(1000);
            builder.Property(x => x.PictureAlt).HasMaxLength(255);
            builder.Property(x => x.PictureTitle).HasMaxLength(500);
            builder.Property(x => x.ShortDescription).HasMaxLength(800).IsRequired();

            builder.Property(x=>x.MetaDescription).HasMaxLength(150).IsRequired();
            builder.Property(x=>x.KeyWords).HasMaxLength(100).IsRequired();
            builder.Property(x=>x.Slug).HasMaxLength(500).IsRequired();

            builder.HasOne(x=>x.ProductCategory).WithMany(x=>x.Products).HasForeignKey(x=>x.ProductCategoryId);
            builder.HasMany(x => x.ProductPictures).WithOne(x => x.Product).HasForeignKey(x => x.ProductId);
        }
    }
}
