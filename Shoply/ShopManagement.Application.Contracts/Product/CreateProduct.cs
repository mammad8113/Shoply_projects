using _01_framwork.Applicatin;
using Microsoft.AspNetCore.Http;
using ShopManagement.Application.Contracts.ProductCategory;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
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

        [FileExtention(".jpeg", ".jpg", ".png", ErrorMessage = "فرمت عکس مجاز نیست")]
        [MaxSizeAttribut(3 * 1024 * 1024, ErrorMessage = "فایل نباید حجیم تر از 3 مگابایت باشد")]
        public IFormFile Picture { get; set; }
        public string PictureAlt { get; set; }
        public string PictureTitle { get; set; }
     
        [Required(ErrorMessage = VallidationMessage.Message)]

        public string Slug { get; set; }
        [Required(ErrorMessage = VallidationMessage.Message)]

        public string MetaDescription { get; set; }
        [Required(ErrorMessage = VallidationMessage.Message)]

        public string KeyWords { get; set; }
        [Range(1,100000,ErrorMessage = VallidationMessage.Message)]

        public long ProductCategoryId { get; set; }
        public List<ProductCategoryViewModel> ProductCategories{ get; set; }
    }
}
