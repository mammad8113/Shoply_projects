﻿using System.Collections.Generic;

namespace _01_Shoplyquery.Contracts.Product
{
    public class CommentQueryModel
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string Mobile { get; set; }
        public string Message { get; set; }
        public string CreationDate { get; set; }
        public string Parent { get; set; }
        public string Image { get; set; }
        public long AcountId { get; set; }
        public int Rating { get; set; }
        public long? ParentId { get; set; }
        public List<CommentQueryModel> Children { get; set; }
    }
}
