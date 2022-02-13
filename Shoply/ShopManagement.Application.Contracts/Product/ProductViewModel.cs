using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopManagement.Application.Contracts.Product
{
    public class ProductViewModel
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string Code { get; set; }
        public string ShortDescription { get; set; }
        public string CreationDate { get; set; }
        public string Picture { get; set; }
        public double Price { get; set; }
        public string ProductCategory { get; set; }
        public long ProductCategoryId { get; set; }
        public bool IsInStock { get; set; }
    }
}
