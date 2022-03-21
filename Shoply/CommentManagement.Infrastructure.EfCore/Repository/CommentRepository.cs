using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _0_Framework.Application;
using _01_framwork.Infrastructure;
using BlogManagement.Domain.Article.Agg;
using CommentManagement.Application.Contracts.Comment;
using CommentManagement.Domain.Comment.Agg;
using CommentManagement.Infrastructure.EfCore;
using Microsoft.EntityFrameworkCore;
using ShopManagement.Domain.Product.Agg;

namespace ShopManagement.Infrastructure.EfCore.Repository
{
    public class CommentRepository : BaseRepository<long, Comment>, ICommentRepository
    {
        private readonly CommentContext _blogContext;
        private readonly IArticleRepository articleRepository;
        private readonly IProductRepository productRepository;
        public CommentRepository(CommentContext blogContext, IProductRepository productRepository, IArticleRepository articleRepository) : base(blogContext)
        {
            _blogContext = blogContext;
            this.productRepository = productRepository;
            this.articleRepository = articleRepository;
        }

        public List<CommentViewModel> Search(CommentSearchModel model)
        {
            var query = _blogContext.Comments.Select(c => new CommentViewModel
            {
                Id = c.Id,
                Name = c.Name,
                Mobile = c.Mobile,
                Message = c.Message,
                OwnerRecordId=c.OwnerRecordId,
                Type = c.Type,
                TypeName=(c.Type==CommentType.Article?"مقالات":"محصولات"),
                ParentId = c.ParentId,
                IsCanceld = c.IsCanceld,
                IsConfirm = c.IsConfirm,
               
                CreationDate = c.CreationDate.ToFarsi()
            });
            
            if (!string.IsNullOrWhiteSpace(model.Name))
                query = query.Where(c => c.Name.Contains(model.Name));

            if (!string.IsNullOrWhiteSpace(model.Mobile))
                query = query.Where(c => c.Mobile.Contains(model.Mobile));

            if (model.OwnerRecordId > 0)
                query = query.Where(c => c.OwnerRecordId == model.OwnerRecordId);

           var comments= query.OrderByDescending(x => x.Id).ToList();

            foreach (var comment in comments)
            {
                if(comment.Type == CommentType.Article)
                    comment.OwnerRecord=articleRepository.Get(comment.OwnerRecordId)?.Title;

                if (comment.Type == CommentType.Product)
                    comment.OwnerRecord = productRepository.Get(comment.OwnerRecordId).Name;
            }

            return comments;
        }
      
    }
}
