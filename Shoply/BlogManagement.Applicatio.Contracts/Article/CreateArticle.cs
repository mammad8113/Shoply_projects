using _01_framwork.Applicatin;
using BlogManagement.Application.Contracts.ArticleCategory;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogManagement.Application.Contracts.Article
{
    public class CreateArticle
    {
        [Required(ErrorMessage = VallidationMessage.Message)]
        public string Title { get; set; }
        [MaxSizeAttribut(3 * 1024 * 1024, ErrorMessage = "حجم فایل نباید بیشتر از 3 مگابایت باشد")]
        [FileExtention(".png", ".jpeg", ".jpg", ErrorMessage = "فرمت فایل درست نیست")]
        public IFormFile Picture { get; set; }
        [Required(ErrorMessage = VallidationMessage.Message)]
        [MaxLength(106)]
        public string ShortDescription { get; set; }
        [Required(ErrorMessage = VallidationMessage.Message)]

        public string Description { get; set; }
        [Required(ErrorMessage = VallidationMessage.Message)]

        public string PublishDate { get; set; }
        [Required(ErrorMessage = VallidationMessage.Message)]

        public string Slug { get; set; }
        [Required(ErrorMessage = VallidationMessage.Message)]

        public string KeyWords { get; set; }
        [Required(ErrorMessage = VallidationMessage.Message)]

        public string MetaDescription { get; set; }
        [Required(ErrorMessage = VallidationMessage.Message)]

        public string CanonicalAddress { get; set; }
        [Required(ErrorMessage = VallidationMessage.Message)]

        [Range(1,1000,ErrorMessage =VallidationMessage.Message)]
        public long ArticleCategoryId { get; set; }
    }
}
