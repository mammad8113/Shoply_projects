using _01_framwork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommentManagement.Domain.Comment.Agg
{
    public class Comment : EntityBase<long>
    {
        public string Name { get; private set; }
        public string Message { get; private set; }
        public string Mobile { get; private set; }
        public bool IsCanceld { get; private set; }
        public bool IsConfirm { get; private set; }
        public long AcountId { get; set; }
        public long OwnerRecordId { get; private set; }
        public int Type { get; private set; }
        public long? ParentId { get; set; }
        public Comment Parent { get; set; }
        public List<Comment> Children { get; set; }


        protected Comment()
        {
        }
        public Comment(string name, string message,string mobile , long ownerRecordId, long acountId,int type, long? parentId)
        {
            Name = name;
            Message = message;
           Mobile = mobile;
            OwnerRecordId = ownerRecordId;
            AcountId = acountId;
            Type = type;
            ParentId = parentId;
        }
        public void Confirm()
        {
            IsConfirm = true;
            IsCanceld = false;
        }
        public void Canceld()
        {
            IsCanceld = true;
            IsConfirm = false;
        }
    }
}
