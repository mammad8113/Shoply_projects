using _01_framwork.Applicatin;
using ShopManagement.Application.Contracts.ProductCategory;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopManagement.Application.Contracts.Product
{
    public class CreateProduct
    {
        [Required(ErrorMessage =VallidationMessage.Message)]
        public string Name { get; set; }
        [Required(ErrorMessage = VallidationMessage.Message)]

        public string Code { get; set; }
        public string Description { get; set; }
        [Required(ErrorMessage = VallidationMessage.Message)]

        public string ShortDescription { get; set; }
        public string Picture { get; set; }
        public string PictureAlt { get; set; }
        public string PictureTitle { get; set; }
        [Range(1,9999999999999999,ErrorMessage = VallidationMessage.Message)]
        public double Price { get; set; }
        [Required(ErrorMessage = VallidationMessage.Message)]

        public string Slug { get; set; }
        [Required(ErrorMessage = VallidationMessage.Message)]

        public string MetaDescription { get; set; }
        [Required(ErrorMessage = VallidationMessage.Message)]

        public string KeyWords { get; set; }
        [Range(1,100000,ErrorMessage = VallidationMessage.Message)]

        public long ProductCategoryId { get; set; }
        public List<ProductCategoryViewModel> ProductCategories { get; set; }=new List<ProductCategoryViewModel>();
    }
}
