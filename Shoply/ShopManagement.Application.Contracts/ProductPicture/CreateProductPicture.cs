using _01_framwork.Applicatin;
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
        [Required(ErrorMessage =VallidationMessage.Message)]
        public string Picture { get; set; }
        [Required(ErrorMessage = VallidationMessage.Message)]

        public string PictureAlt { get; set; }
        [Required(ErrorMessage = VallidationMessage.Message)]

        public string PictureTitle { get; set; }
        [Range(1,90000,ErrorMessage = VallidationMessage.Message)]

        public long ProductId { get; set; }
       public List<ProductViewModel> Products { get; set; } = new List<ProductViewModel>();
    }
}
