using _01_framwork.Applicatin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommentManagement.Application.Contracts.Comment
{
    public interface ICommentApplication
    {
        OperationResult Add(AddComment command);
        OperationResult Canceld(long id);
        OperationResult Confirm(long id);
        List<CommentViewModel> Search(CommentSearchModel model);
    }
}
