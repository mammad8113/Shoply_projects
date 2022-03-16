﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommentManagement.Application.Contracts.Comment
{
    public class AddComment
    {
        public string Name { get; set; }
        public string Message { get; set; }
        public string Email { get; set; }
        public string Website { get; set; }
        public long OwnerRecordId { get; set; }
        public int type { get; set; }
        public long? ParentId { get; set; }
    }
}
