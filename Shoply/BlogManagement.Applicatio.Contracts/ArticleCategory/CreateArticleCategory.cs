using _01_framwork.Applicatin;
using Microsoft.AspNetCore.Http;
using System;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogManagement.Application.Contracts.ArticleCategory
{
    public class CreateArticleCategory
    {
        [Required(ErrorMessage = VallidationMessage.Message)]
        public string Name { get; set; }
        
        [Required(ErrorMessage = VallidationMessage.Message)]
        public string ShortDescription { get; set; }
        
        [Required(ErrorMessage = VallidationMessage.Message)]
        public string Description { get; set; }

        [Required(ErrorMessage = VallidationMessage.Message)]
        public IFormFile Picture { get; set; }

        [Required(ErrorMessage = VallidationMessage.Message)]
        public string PictureAlt { get; set; }
        
        [Required(ErrorMessage = VallidationMessage.Message)]
        public string PictureTitle { get; set; }

        [Required(ErrorMessage = VallidationMessage.Message)]
        public int ShowOrder { get; set; }

        [Required(ErrorMessage = VallidationMessage.Message)]
        public string Slug { get; set; }
        
        [Required(ErrorMessage = VallidationMessage.Message)]
        public string KeyWords { get; set; }
       
        [Required(ErrorMessage = VallidationMessage.Message)]
        public string MetaDescription { get; set; }
       
        [Required(ErrorMessage = VallidationMessage.Message)]
        public string CanonicalAddress { get; set; }
    }
}
