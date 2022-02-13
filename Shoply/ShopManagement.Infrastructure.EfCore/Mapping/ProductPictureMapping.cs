using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ShopManagement.Domain.ProductPicture.Agg;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopManagement.Infrastructure.EfCore.Mapping
{
    public class ProductPictureMapping : IEntityTypeConfiguration<ProductPicture>
    {
        public void Configure(EntityTypeBuilder<ProductPicture> builder)
        {
            builder.ToTable("ProductPictures");
            builder.HasKey(x => x.Id);

            builder.Property(x=>x.Picture).HasMaxLength(2000);
            builder.Property(x => x.PictureAlt).HasMaxLength(300);
            builder.Property(x => x.PictureTitle).HasMaxLength(600);

            builder.HasOne(x => x.Product).WithMany(x => x.ProductPictures).HasForeignKey(x => x.ProductId);
        }
    }
}
