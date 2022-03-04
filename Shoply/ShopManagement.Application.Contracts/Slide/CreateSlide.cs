using _01_framwork.Applicatin;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopManagement.Application.Contracts.Slide
{
    public class CreateSlide
    {
        [FileExtention(".jpeg", ".jpg", ".png", ErrorMessage = "فرمت عکس مجاز نیست")]
        [MaxSizeAttribut(3 * 1024 * 1024, ErrorMessage = "فایل نباید حجیم تر از 3 مگابایت باشد")]
        public IFormFile Picture { get; set; }
        [Required(ErrorMessage = VallidationMessage.Message)]

        public string PictureAlt { get; set; }
        [Required(ErrorMessage = VallidationMessage.Message)]

        public string PictureTitle { get; set; }
        [Required(ErrorMessage = VallidationMessage.Message)]

        public string Heding { get; set; }
        [Required(ErrorMessage = VallidationMessage.Message)]

        public string Link { get; set; }
        [Required(ErrorMessage = VallidationMessage.Message)]

        public string Title { get; set; }
        [Required(ErrorMessage = VallidationMessage.Message)]

        public string Text { get; set; }
        [Required(ErrorMessage = VallidationMessage.Message)]
        public string BtnText { get; set; }
    }
}
