using _01_Shoplyquery.Contracts.Article;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01_Shoplyquery.Contracts.ArticleCategory
{
    public class ArticleCategoryQueryModel
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string ShortDescription { get; set; }
        public string Description { get; set; }
        public string Picture { get; set; }
        public string PictureAlt { get; set; }
        public string PictureTitle { get; set; }
        public int ShowOrder { get; set; }
        public bool IsRemove { get; set; }
        public string Slug { get; set; }
        public string KeyWords { get; set; }
        public List<string> KeyWordsList { get; set; }
        public string MetaDescription { get; set; }
        public string CanonicalAddress { get; set; }
        public int ArticleCount { get; set; }
        public List<ArticleQueryModel> Articles { get; set; }
}
}
