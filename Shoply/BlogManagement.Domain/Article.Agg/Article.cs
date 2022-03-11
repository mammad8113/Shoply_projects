using _01_framwork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogManagement.Domain.Article.Agg
{
    public class Article : EntityBase<long>
    {
        public string Title { get; private set; }
        public string Picture { get; private set; }
        public string PictureAlt { get; private set; }
        public string PictureTitle { get; private set; }
        public string ShortDescription { get; private set; }
        public string Description { get; private set; }
        public DateTime PublishDate { get; private set; }
        public bool IsRemove { get; private set; }
        public string Slug { get; private set; }
        public string KeyWords { get; private set; }
        public string MetaDescription { get; private set; }
        public string CanonicalAddress { get; private set; }
        public long ArticleCategoryId { get; private set; }
        public ArticleCategory.Agg.ArticleCategory ArticleCategory { get; private set; }

        public Article(string title, string picture, string shortDescription, string description, DateTime publishDate, string slug, string keyWords, string metaDescription, string canonicalAddress,
            long articleCategoryId)
        {
            Title = title;
            Picture = picture;
            PictureAlt = title;
            PictureTitle = title;
            ShortDescription = shortDescription;
            Description = description;
            PublishDate = publishDate;
            Slug = slug;
            KeyWords = keyWords;
            MetaDescription = metaDescription;
            CanonicalAddress = canonicalAddress;
            ArticleCategoryId = articleCategoryId;
            IsRemove = false;
        }
        public void Edit(string title, string picture, string shortDescription, string description, DateTime publishDate, string slug, string keyWords, string metaDescription, string canonicalAddress,
        long articleCategoryId)
        {
            Title = title;
            if (picture != null && picture != "")
                Picture = picture;

            PictureAlt = title;
            PictureTitle = title;
            ShortDescription = shortDescription;
            Description = description;
            PublishDate = publishDate;
            Slug = slug;
            KeyWords = keyWords;
            MetaDescription = metaDescription;
            CanonicalAddress = canonicalAddress;
            ArticleCategoryId = articleCategoryId;
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
