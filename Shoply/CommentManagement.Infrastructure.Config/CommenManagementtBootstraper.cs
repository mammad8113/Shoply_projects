using CommentManagement.Application.Contracts.Comment;
using CommentManagement.Domain.Comment.Agg;
using CommentManagement.Infrastructure.EfCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using ShopManagement.Application.Comment;
using ShopManagement.Infrastructure.EfCore.Repository;
using System;

namespace CommentManagement.Infrastructure.Config
{
    public class CommenManagementtBootstraper
    {
        public static void Configur(IServiceCollection services, string ConnectionString)
        {
            services.AddTransient<ICommentRepository, CommentRepository>();
            services.AddTransient<ICommentApplication, CommentApplication>();

            services.AddDbContext<CommentContext>(x => x.UseSqlServer(ConnectionString));

        }
    }
}
