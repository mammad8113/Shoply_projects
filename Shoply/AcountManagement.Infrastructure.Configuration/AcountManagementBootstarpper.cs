using AcountManagement.Application.Acount;
using AcountManagement.Application.Contracts.Acount;
using AcountManagement.Application.Contracts.Rol;
using AcountManagement.Application.Rol;
using AcountManagement.Domain.Acount.Agg;
using AcountManagement.Domain.Rol.Agg;
using AcountManagement.Infrastructure.EfCore;
using AcountManagement.Infrastructure.EfCore.Repsoitory;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace AcountManagement.Infrastructure.Configuration
{
    public class AcountManagementBootstarpper
    {
        public static void Configur(IServiceCollection services, string connectionString)
        {
            services.AddTransient<IAcountApplication, AcountApplication>();
            services.AddTransient<IAcountRepository, AcountRepository>();

            services.AddTransient<IRolRepository, RolRepository>();
            services.AddTransient<IRolApplication, RolApplication>();

            services.AddDbContext<AcountContext>(x => x.UseSqlServer(connectionString));
        }
    }
}
