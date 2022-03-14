using _01_framwork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogManagement.Domain.ArticleCategory.Agg
{
    public class ArticleCategory : EntityBase<long>
    {
        public string Name { get; private set; }
        public string ShortDescription { get; private set; }
        public string Description { get; private set; }
        public string Picture { get; private set; }
        public string PictureAlt { get; private set; }
        public string PictureTitle { get; private set; }
        public int ShowOrder { get; private set; }
        public bool IsRemove { get; private set; }
        public string Slug { get; private set; }
        public string KeyWords { get; private set; }
        public string MetaDescription { get; private set; }
        public string CanonicalAddress { get; private set; }
        public List<Article.Agg.Article> Articles { get;private set; }

        public ArticleCategory(string name, string shortDescription, string picture, string pictureAlt, string pictureTitle, string description, int showOrder,
            string slug, string keyWords, string metaDescription, string canonicalAddress)
        {
            Name = name;
            ShortDescription = shortDescription;
            Picture = picture;
            PictureAlt = pictureAlt;
            PictureTitle = pictureTitle;
            Description = description;
            ShowOrder = showOrder;
            Slug = slug;
            KeyWords = keyWords;
            MetaDescription = metaDescription;
            CanonicalAddress = canonicalAddress;
            IsRemove = false;
        }
        public void Edit(string name, string shortDescription, string description, string picture, string pictureAlt, string pictureTitle, int showOrder,
          string slug, string keyWords, string metaDescription, string canonicalAddress)
        {
            Name = name;
            ShortDescription = shortDescription;
            Description = description;
            if (picture != null)
                Picture = picture;

            PictureAlt = pictureAlt;
            PictureTitle = pictureTitle;
            ShowOrder = showOrder;
            Slug = slug;
            KeyWords = keyWords;
            MetaDescription = metaDescription;
            CanonicalAddress = canonicalAddress;
        }

   

        public void Remove()
        {
            IsRemove = true;
        }
        public void Activate()
        {
            IsRemove = false;
        }
    }
}
