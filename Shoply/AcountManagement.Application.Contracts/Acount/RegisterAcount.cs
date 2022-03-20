using _01_framwork.Applicatin;
using AcountManagement.Application.Contracts.Rol;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcountManagement.Application.Contracts.Acount
{
    public class RegisterAcount
    {
        [Required(ErrorMessage = VallidationMessage.Message)]
        public string Fullname { get; set; }
        [Required(ErrorMessage = VallidationMessage.Message)]

        public string Username { get; set; }
        [Required(ErrorMessage = VallidationMessage.Message)]

        public string Mobile { get; set; }
        [Required(ErrorMessage = VallidationMessage.Message)]

        public string Password { get; set; }
        public string RePassword { get; set; }
        [Range(1,int.MaxValue, ErrorMessage = VallidationMessage.Message)]
        public long RolId { get; set; }

        [MaxSizeAttribut(3*1024*1024,ErrorMessage = "حجم فایل باید کمتر از 3 مگابایت باشد")]
        [FileExtention(".jpg", ".png", ".jpeg", ErrorMessage = "فرمت عکس درست نیست")]

        public IFormFile UserPhoto { get; set; }
        public List<RolViewModel> RolViewModels { get; set; }
    }
}
