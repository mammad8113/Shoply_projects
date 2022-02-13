using _01_framwork.Applicatin;
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
        [Required(ErrorMessage =VallidationMessage.Message)]
        public string Name { get; set; }
        [Required(ErrorMessage = VallidationMessage.Message)]

        public string Description { get; set; }
        [Required(ErrorMessage = VallidationMessage.Message)]

        public string Picture { get; set; }
        [Required(ErrorMessage = VallidationMessage.Message)]

        public string PictureAlt { get; set; }
        [Required(ErrorMessage = VallidationMessage.Message)]

        public string PictureTitle { get; set; }
  
        [Required(ErrorMessage =VallidationMessage.Message)]

        public string Keywords { get; set; }
        [Required(ErrorMessage = VallidationMessage.Message)]

        public string MetaDescription { get; set; }
        [Required(ErrorMessage =VallidationMessage.Message)]

        public string Slug { get; set; }
    }
}
