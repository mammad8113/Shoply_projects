using _01_framwork.Infrastructure;
using InventoryManagement.Application;
using InventoryManagement.Application.Contracts.Inventory;
using InventoryManagement.Domain.Inventory.Agg;
using InventoryManagement.Infrastructure.Configuration.Permissions;
using InventoryManagement.Infrastructure.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace InventoryManagement.Infrastructure.Configuration
{
    public class InventoryManagementBootstraper
    {
        public static void Configur(IServiceCollection services,string connectionstring)
        {
            services.AddTransient<IInventoryRepository, InventoryRepository>();
            services.AddTransient<IInventoryApplication, InevntoryApplication>();
            services.AddTransient<IPermissionsExposer, InventoryPermissionExposer>();

            services.AddDbContext<InventoryContext>(x => x.UseSqlServer(connectionstring));
        }
    }
}
