using _01_Shoplyquery.Contracts.Product;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01_Shoplyquery.Contracts.ProductCategory
{
    public class ProductCategoryQueryModel
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Picture { get; set; }
        public string PictureAlt { get; set; }
        public string PictureTitle { get; set; }
        public bool IsRemoved { get; set; }
        public string Keywords { get; set; }
        public string MetaDescription { get; set; }
        public string Slug { get; set; }
        public long? ParentId { get; set; }
        public string Parent { get; set; }
        public List<string> Parents { get; set; }
        public List<ProductCategoryQueryModel> Children { get; set; }
        public List<ProductQueryModel> Products { get; set; }=new List<ProductQueryModel>();
    }
}
