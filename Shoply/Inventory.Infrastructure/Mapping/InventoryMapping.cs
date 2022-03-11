using InventoryManagement.Domain.Inventory.Agg;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManagement.Infrastructure.Mapping
{
    public class InventoryMapping : IEntityTypeConfiguration<Inventory>
    {
        public void Configure(EntityTypeBuilder<Inventory> builder)
        {
            builder.ToTable("Inventories");
            builder.HasKey(x => x.Id);

            builder.OwnsMany(x => x.Operations, builder =>
            {
                builder.ToTable("InventoryOperations");
                builder.HasKey(x => x.Id);
                builder.Property(x => x.Description).HasMaxLength(1000);
                builder.WithOwner(x => x.Inventory).HasForeignKey(x => x.InventoryId);
            });
        }
    }
}
