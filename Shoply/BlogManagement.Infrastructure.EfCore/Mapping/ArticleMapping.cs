using BlogManagement.Domain.Article.Agg;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogManagement.Infrastructure.EfCore.Mapping
{
    public class ArticleMapping : IEntityTypeConfiguration<Article>
    {
        public void Configure(EntityTypeBuilder<Article> builder)
        {
            builder.ToTable("Articles");
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Title).HasMaxLength(600);
            builder.Property(x => x.Picture).HasMaxLength(500);
            builder.Property(x => x.ShortDescription).HasMaxLength(1000);
            builder.Property(x => x.Description).HasMaxLength(2000);
            builder.Property(x => x.Slug).HasMaxLength(700);
            builder.Property(x => x.KeyWords).HasMaxLength(100);
            builder.Property(x => x.MetaDescription).HasMaxLength(150);
            builder.Property(x => x.CanonicalAddress).HasMaxLength(1000);

            builder.HasOne(x => x.ArticleCategory).WithMany(x => x.Articles).HasForeignKey(x => x.ArticleCategoryId);
        }
    }
}
