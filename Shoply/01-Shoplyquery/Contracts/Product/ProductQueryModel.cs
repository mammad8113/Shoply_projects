﻿using _01_Shoplyquery.Contracts.ProductCategory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01_Shoplyquery.Contracts.Product
{
    public class ProductQueryModel
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string Picture { get; set; }
        public string PictureAlt { get; set; }
        public string PictureTitle { get; set; }
        public string Price { get; set; }
        public double DoublePrice { get; set; }
        public bool InStock { get; set; }
        public string ShortDescription { get; set; }
        public string PricewithDicount { get; set; }
        public double DoublePricewithDicount { get; set; }
        public int DiscountRate { get; set; }
        public string Category { get; set; }
        public long CategoryId { get; set; }
        public List<string> Categories { get; set; }
        public string CategorySlug { get; set; }
        public string Slug { get; set; }
        public bool HasDiscount { get; set; }
        public string EndDate { get; set; }
        public string Code { get; set; }
        public int Rating { get; set; }
        public string Description { get; set; }
        public bool IsRemoved { get; set; }
        public string MetaDescription { get; set; }
        public string KeyWords { get; set; }
        public List<string> KeyWordsList { get; set; }
        public List<ProductPictureQueryModel> Pictures { get; set; }
        public List<CommentQueryModel> Comments { get; set; }
    }
}
