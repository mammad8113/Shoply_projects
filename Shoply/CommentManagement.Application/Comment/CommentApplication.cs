using _01_framwork.Applicatin;
using CommentManagement.Application.Contracts.Comment;
using CommentManagement.Domain.Comment.Agg;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopManagement.Application.Comment
{
    public class CommentApplication : ICommentApplication
    {
        private readonly ICommentRepository commentRepository;

        public CommentApplication(ICommentRepository commentRepository)
        {
            this.commentRepository = commentRepository;
        }

        public OperationResult Add(AddComment command)
        {
            var result = new OperationResult();
            if (command == null)
                return result.Faild(ApplicationMessage.NullMessage);

            try
            {
                var comment = new CommentManagement.Domain.Comment.Agg.Comment(command.Name, command.Message, command.Email, command.Website,
                    command.OwnerRecordId, command.type, command.ParentId);
                commentRepository.Create(comment);
                commentRepository.Save();
            }
            catch
            {
                return result.Faild(ApplicationMessage.NullFildMessage);

            }

            return result.Success();
        }

        public OperationResult Canceld(long id)
        {
            var result = new OperationResult();
            var comment = commentRepository.Get(id);
            if (comment == null)
                return result.Faild(ApplicationMessage.NullMessage);

            comment.Canceld();
            commentRepository.Save();
            return result.Success();
        }

        public OperationResult Confirm(long id)
        {
            var result = new OperationResult();
            var comment = commentRepository.Get(id);
            if (comment == null)
                return result.Faild(ApplicationMessage.NullMessage);

            comment.Confirm();
            commentRepository.Save();
            return result.Success();
        }

        public List<CommentViewModel> Search(CommentSearchModel model)
        {
            return commentRepository.Search(model);
        }
    }
}
