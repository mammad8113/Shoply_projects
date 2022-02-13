using _01_framwork.Applicatin;
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
        [Required(ErrorMessage = VallidationMessage.Message)]
        public string Picture { get; set; }
        [Required(ErrorMessage = VallidationMessage.Message)]

        public string PictureAlt { get; set; }
        [Required(ErrorMessage = VallidationMessage.Message)]

        public string PictureTitle { get; set; }
        [Required(ErrorMessage = VallidationMessage.Message)]

        public string Heding { get; set; }
        [Required(ErrorMessage = VallidationMessage.Message)]

        public string Title { get; set; }
        [Required(ErrorMessage = VallidationMessage.Message)]

        public string Text { get; set; }
        [Required(ErrorMessage = VallidationMessage.Message)]
        public string BtnText { get; set; }
    }
}
