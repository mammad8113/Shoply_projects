using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ShopManagement.Domain.Address.Agg;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopManagement.Infrastructure.EfCore.Mapping
{
    public class AddressMapping : IEntityTypeConfiguration<Address>
    {
        public void Configure(EntityTypeBuilder<Address> builder)
        {
            builder.ToTable("Addresses");
            builder.HasKey(x => x.Id);

            builder.Property(x => x.State).HasMaxLength(200).IsRequired();
            builder.Property(x => x.City).HasMaxLength(200).IsRequired();
            builder.Property(x => x.Street).HasMaxLength(1000).IsRequired();

            builder.HasMany(x => x.Orders).WithOne(x => x.Address).HasForeignKey(x => x.AddressId);
        }
    }
}
