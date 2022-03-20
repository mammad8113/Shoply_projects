using AcountManagement.Domain.Acount.Agg;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcountManagement.Infrastructure.EfCore.Mapping
{
    public class AcountMapping : IEntityTypeConfiguration<Acount>
    {
        public void Configure(EntityTypeBuilder<Acount> builder)
        {
            builder.ToTable("Acounts");
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Fullname).HasMaxLength(600);
            builder.Property(x => x.Username).HasMaxLength(600);
            builder.Property(x => x.Password).HasMaxLength(1000);
            builder.Property(x => x.Mobile).HasMaxLength(12);
            builder.Property(x => x.UserPhoto).HasMaxLength(600);

            builder.HasOne(x=>x.Rol).WithMany(x=>x.Acounts).HasForeignKey(x=>x.RolId);
        }
    }
}
