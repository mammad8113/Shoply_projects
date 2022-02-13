using _01_framwork;
using ShopManagement.Domain.ProductCategory.Agg;
using ShopManagement.Domain.ProductCategory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopManagement.Domain.Product.Agg
{
    public class Product : EntityBase<long>
    {
        public string Name { get; private set; }
        public string Code { get; private set; }
        public string Description { get; private set; }
        public string ShortDescription { get; private set; }
        public bool IsInStock { get; private set; }
        public string Picture { get; private set; }
        public string PictureAlt { get; private set; }
        public string PictureTitle { get; private set; }
        public double Price { get; private set; }
        public string Slug { get; private set; }
        public string MetaDescription { get; private set; }
        public string KeyWords { get; private set; }
        public long ProductCategoryId { get; private set; }
        public Domain.ProductCategory.ProductCategory ProductCategory { get; private set; }
        public List<ProductPicture.Agg.ProductPicture> ProductPictures { get; private set; }
        protected Product()
        {
            ProductPictures = new List<ProductPicture.Agg.ProductPicture>();
        }

        public Product(string name, string code, string description, string shortDescription, string picture,
            string pictureAlt, string pictureTitle, double price, string slug, string metaDescription,
            string keyWords, long productCategoryId)
        {
            Name = name;
            Code = code;
            Description = description;
            ShortDescription = shortDescription;
            Picture = picture;
            PictureAlt = pictureAlt;
            PictureTitle = pictureTitle;
            Price = price;
            Slug = slug;
            MetaDescription = metaDescription;
            KeyWords = keyWords;
            ProductCategoryId = productCategoryId;
            IsInStock = true;
        }
        public void Edit(string name, string code, string description, string shortDescription, string picture,
        string pictureAlt, string pictureTitle, double price, string slug, string metaDescription,
        string keyWords, long productCategoryId)
        {
            Name = name;
            Code = code;
            Description = description;
            ShortDescription = shortDescription;
            Picture = picture;
            PictureAlt = pictureAlt;
            PictureTitle = pictureTitle;
            Price = price;
            Slug = slug;
            MetaDescription = metaDescription;
            KeyWords = keyWords;
            ProductCategoryId = productCategoryId;
        }

        public void InStock()
        {
            IsInStock = true;
        }
        public void NotInStock()
        {
            IsInStock = false;
        }
    }
}
