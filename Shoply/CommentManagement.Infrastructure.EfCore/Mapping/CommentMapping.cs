using CommentManagement.Domain.Comment.Agg;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommentManagement.Infrastructure.EfCore.Mapping
{
    public class CommentMapping : IEntityTypeConfiguration<Comment>
    {
        public void Configure(EntityTypeBuilder<Comment> builder)
        {

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Name).HasMaxLength(500).IsRequired();
            builder.Property(x => x.Mobile).HasMaxLength(16).IsRequired();
            builder.Property(x => x.Message).HasMaxLength(1500).IsRequired();

        }
    }
}
