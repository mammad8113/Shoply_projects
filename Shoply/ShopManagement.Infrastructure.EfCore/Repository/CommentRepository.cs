using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _0_Framework.Application;
using _01_framwork.Infrastructure;
using Microsoft.EntityFrameworkCore;
using ShopManagement.Application.Contracts.Comment;
using ShopManagement.Domain.Comment.Agg;

namespace ShopManagement.Infrastructure.EfCore.Repository
{
    public class CommentRepository : BaseRepository<long, Comment>, ICommentRepository
    {
        private readonly ShopContext _shopContext;

        public CommentRepository(ShopContext shopContext) : base(shopContext)
        {
            _shopContext = shopContext;
        }

        public List<CommentViewModel> Search(CommentSearchModel model)
        {
            var query = _shopContext.Commens.Include(c=>c.Product).Select(c => new CommentViewModel
            {
                Id = c.Id,
                Name = c.Name,
                Email = c.Email,
                Message = c.Message,
                IsCanceld = c.IsCanceld,
                IsConfirm = c.IsConfirm,
                ProductId = c.ProductId,
                Product=c.Product.Name,
                CreationDate = c.CreationDate.ToFarsi()
            });

            if (!string.IsNullOrWhiteSpace(model.Name))
                query = query.Where(c => c.Name.Contains(model.Name));

            if (!string.IsNullOrWhiteSpace(model.Email))
                query = query.Where(c => c.Email.Contains(model.Email));

            if (model.ProductId > 0)
                query = query.Where(c => c.ProductId == model.ProductId);

            return query.OrderByDescending(x => x.Id).ToList();
        }
    }
}
