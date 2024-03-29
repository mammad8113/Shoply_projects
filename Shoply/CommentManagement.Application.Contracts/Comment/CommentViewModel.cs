﻿namespace CommentManagement.Application.Contracts.Comment
{
    public class CommentViewModel
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string Message { get; set; }
        public string Mobile { get; set; }
        public bool IsCanceld { get; set; }
        public bool IsConfirm { get; set; }
        public long OwnerRecordId { get; set; }
        public int Type { get; set; }
        public string TypeName { get; set; }
        public long? ParentId { get; set; }
        public string OwnerRecord { get; set; }
        public string CreationDate { get; set; }
    }
}
