using _01_framwork.Applicatin;
using Microsoft.AspNetCore.Http;
using ShopManagement.Application.Contracts.Product;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopManagement.Application.Contracts.ProductPicture
{
    public class CreateProductPicture
    {

        [FileExtention(".jpeg", ".jpg", ".png", ErrorMessage = "فرمت عکس مجاز نیست")]
        [MaxSizeAttribut(3 * 1024 * 1024, ErrorMessage = "فایل نباید حجیم تر از 3 مگابایت باشد")]
        public IFormFile Picture { get; set; }

        [Required(ErrorMessage = VallidationMessage.Message)]

        public string PictureAlt { get; set; }
        [Required(ErrorMessage = VallidationMessage.Message)]
        public string PictureTitle { get; set; }

        [Range(1, 90000, ErrorMessage = VallidationMessage.Message)]
        public long ProductId { get; set; }
        public List<ProductViewModel> Products { get; set; } = new List<ProductViewModel>();
    }
}
