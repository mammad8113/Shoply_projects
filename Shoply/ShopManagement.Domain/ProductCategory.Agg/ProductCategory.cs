using _01_framwork;
using _01_framwork.Applicatin;
using ShopManagement.Domain.ProductCategory.Agg.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopManagement.Domain.ProductCategory
{
    public class ProductCategory : EntityBase<long>
    {
        public string Name { get; private set; }
        public string Description { get; private set; }
        public string Picture { get; private set; }
        public string PictureAlt { get; private set; }
        public string PictureTitle { get; private set; }
        public int Level { get; set; }
        public long Parent { get; set; }
        public bool IsRemoved { get; private set; }
        public string Keywords { get; private set; }
        public string MetaDescription { get; private set; }
        public string Slug { get; private set; }
        public List<Domain.Product.Agg.Product> Products { get; set; }

        protected ProductCategory()
        {
            Products = new List<Product.Agg.Product>();
        }
        public ProductCategory(string name, string description, string picture,
            string pictureAlt, string pictureTitle,
            string keywords, string metaDescription, string slug, IValidationProducatCategory validation, long parent = 0)
        {

            CheckNull(name, description, picture, pictureAlt, pictureTitle,
               keywords, metaDescription, slug);
            validation.Doblicated(x => x.Name == name && x.Picture == picture);
            Name = name;
            Description = description;
            Picture = picture;
            PictureAlt = pictureAlt;
            PictureTitle = pictureTitle;
            Keywords = keywords;
            MetaDescription = metaDescription;
            Slug = slug;
            IsRemoved = false;
            Level = 0;
            Parent = parent;
        }
        public OperationResult Edit(string name, string description, string picture,
            string pictureAlt, string pictureTitle,
            string keywords, string metaDescription, string slug, IValidationProducatCategory validation, long parent = 0)
        {
            OperationResult operation = new OperationResult();
            try
            {
                CheckNull(name, description, picture, pictureAlt, pictureTitle, keywords, metaDescription, slug);
                validation.Doblicated(x => x.Name == name && x.Picture == picture && x.Id != x.Id);
                Name = name;
                Description = description;
                Picture = picture;
                PictureAlt = pictureAlt;
                PictureTitle = pictureTitle;
                Keywords = keywords;
                MetaDescription = metaDescription;
                Slug = slug;
                Parent = parent;
                return operation.Success();
            }
            catch (Exception e)
            {
                return operation.Faild(e.Message);
            }
        }

        public void CheckNull(string name, string description, string picture,
            string pictureAlt, string pictureTitle,
            string keywords, string metaDescription, string slug)
        {
            if (name == null || description == null || picture == null || pictureAlt == null || pictureTitle == null || keywords == null
                || metaDescription == null || slug == null)
                throw new ArgumentNullException("لطفا اطلاعات را کامل فرمایید");
        }
        public void Remove()
        {
            IsRemoved = true;
        }
        public void Activate()
        {
            IsRemoved = false;
        }
    }
}
