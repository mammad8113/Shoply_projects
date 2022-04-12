using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ShopManagement.Domain.Order.Agg;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopManagement.Infrastructure.EfCore.Mapping
{
    public class OrderMapping : IEntityTypeConfiguration<Order>
    {
        public void Configure(EntityTypeBuilder<Order> builder)
        {
            builder.ToTable("Orders");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.IssueTrakingNo).HasMaxLength(8);

            builder.HasOne(x=>x.Address).WithMany(x=>x.Orders).HasForeignKey(x=>x.AddressId);

            builder.OwnsMany(x => x.OrderItems, navigationBuilder =>
            {
                navigationBuilder.ToTable("OrderItems");
                navigationBuilder.HasKey(x => x.Id);
                navigationBuilder.WithOwner(x => x.Order).HasForeignKey(x => x.OrderId);
            });


        }
    }
}
