using _01_framwork.Applicatin;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopManagement.Application.Contracts.ProductCategory
{
    public class CreateProductCategory
    {
        [Required(ErrorMessage = VallidationMessage.Message)]
        public string Name { get; set; }
        [Required(ErrorMessage = VallidationMessage.Message)]

        public string Description { get; set; }
        
        [FileExtention(".jpeg",".jpg",".png",ErrorMessage ="فرمت عکس مجاز نیست")]
        [MaxSizeAttribut(3 * 1024 * 1024,ErrorMessage ="فایل نباید حجیم تر از 3 مگابایت باشد")]
      
        public IFormFile Picture { get; set; }
        public string PicturePath { get; set; }
        [Required(ErrorMessage = VallidationMessage.Message)]

        public string PictureAlt { get; set; }
        [Required(ErrorMessage = VallidationMessage.Message)]

        public string PictureTitle { get; set; }

        [Required(ErrorMessage = VallidationMessage.Message)]

        public string Keywords { get; set; }
        [Required(ErrorMessage = VallidationMessage.Message)]

        public string MetaDescription { get; set; }
        [Required(ErrorMessage = VallidationMessage.Message)]

        public string Slug { get; set; }

        public long? ParentId { get; set; }
        public List<ProductCategoryViewModel> Parents { get; set; } = new List<ProductCategoryViewModel>();
    }
}
