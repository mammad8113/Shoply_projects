using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _0_Framework.Application;
using _01_framwork.Infrastructure;
using CommentManagement.Application.Contracts.Comment;
using CommentManagement.Domain.Comment.Agg;
using CommentManagement.Infrastructure.EfCore;
using Microsoft.EntityFrameworkCore;

namespace ShopManagement.Infrastructure.EfCore.Repository
{
    public class CommentRepository : BaseRepository<long, Comment>, ICommentRepository
    {
        private readonly CommentContext _blogContext;

        public CommentRepository(CommentContext blogContext) : base(blogContext)
        {
            _blogContext = blogContext;
        }

        public List<CommentViewModel> Search(CommentSearchModel model)
        {
            var query = _blogContext.Comments.Select(c => new CommentViewModel
            {
                Id = c.Id,
                Name = c.Name,
                Email = c.Email,
                Message = c.Message,
                Websit=c.Website,
                OwnerRecordId=c.OwnerRecordId,
                Type = c.Type,
                ParentId = c.ParentId,
                IsCanceld = c.IsCanceld,
                IsConfirm = c.IsConfirm,
               
                CreationDate = c.CreationDate.ToFarsi()
            });

            if (!string.IsNullOrWhiteSpace(model.Name))
                query = query.Where(c => c.Name.Contains(model.Name));

            if (!string.IsNullOrWhiteSpace(model.Email))
                query = query.Where(c => c.Email.Contains(model.Email));

            if (model.OwnerRecordId > 0)
                query = query.Where(c => c.OwnerRecordId == model.OwnerRecordId);

            return query.OrderByDescending(x => x.Id).ToList();
        }

       
    }
}
