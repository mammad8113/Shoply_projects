using AcountManagement.Domain.Acount.Agg;
using AcountManagement.Domain.Rol.Agg;
using AcountManagement.Infrastructure.EfCore.Mapping;
using Microsoft.EntityFrameworkCore;
using System;

namespace AcountManagement.Infrastructure.EfCore
{
    public class AcountContext : DbContext
    {
        public DbSet<Acount> Acounts { get; set; }
        public DbSet<Role> Rols { get; set; }

        public AcountContext(DbContextOptions<AcountContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            var assembily = typeof(AcountMapping).Assembly;
            modelBuilder.ApplyConfigurationsFromAssembly(assembily);
            base.OnModelCreating(modelBuilder);
        }
    }
}
