using AcountManagement.Domain.Rol.Agg;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcountManagement.Infrastructure.EfCore.Mapping
{
    public class RolMapping : IEntityTypeConfiguration<Rol>
    {
        public void Configure(EntityTypeBuilder<Rol> builder)
        {
            builder.ToTable("Rols");
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Name).HasMaxLength(100).IsRequired();

            builder.HasMany(x => x.Acounts).WithOne(x => x.Rol).HasForeignKey(x => x.RolId);
            builder.OwnsMany(x => x.Permissions, navigationName =>
            {
                navigationName.ToTable("Permissions");
                navigationName.HasKey(x => x.Id);
                navigationName.Ignore(x=>x.Name);
                navigationName.WithOwner(x => x.Rol).HasForeignKey(x=>x.RolId);
            });
        }
    }
}
