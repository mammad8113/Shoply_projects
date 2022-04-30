using DiscountManagement.Application.ColleagueDiscount;
using DiscountManagement.Application.Contracts.ColleagueDiscount;
using DiscountManagement.Application.Contracts.CustomerDiscount;
using DiscountManagement.Application.CustomerDiscount;
using DiscountManagement.Domain.ColleagueDiscount.Agg;
using DiscountManagement.Domain.CustomerDiscount.Agg;
using DiscountManagement.Infrastructure.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace DiscountManagement.Infrastructure.Config
{
    public static class DiscountManagementBootstraper
    {
        public static void AddDisCountSection(this IServiceCollection services,string ConnectionString)
        {
            services.AddTransient<ICustomerDiscountApplication, CustomerDiscountApplication>();
            services.AddTransient<ICustomerDiscountRepository, CustomerDiscountRepository>();

            services.AddTransient<IColleagueDiscountRepository, ColleagueDiscountRepository>();
            services.AddTransient<IColleagueDiscountApplication, ColleagueDiscountApplication>();
            services.AddDbContext<DiscountContext>(x => x.UseSqlServer(ConnectionString));
        }

    }
}


