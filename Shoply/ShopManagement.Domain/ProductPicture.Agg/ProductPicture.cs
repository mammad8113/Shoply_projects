
using _01_framwork;
using _01_framwork.Applicatin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopManagement.Domain.ProductPicture.Agg
{
    public class ProductPicture:EntityBase<long>
    {
        public string Picture { get;private set; }
        public string PictureAlt { get; private set; }
        public string PictureTitle { get; private set; }
        public bool IsRemoved { get; private set; }
        public long ProductId { get; private set; }
        public Product.Agg.Product Product { get; private set; }

        public ProductPicture(string picture, string pictureAlt, string pictureTitle, long productId)
        {
            Picture = picture;
            PictureAlt = pictureAlt;
            PictureTitle = pictureTitle;
            ProductId = productId;
            IsRemoved = false;
        }
        public void Edit(string picture, string pictureAlt, string pictureTitle, long productId)
        {
            Picture = picture;
            PictureAlt = pictureAlt;
            PictureTitle = pictureTitle;
            ProductId = productId;
            IsRemoved = false;
        }

        public void Remove()
        {
            IsRemoved = true;
        }
        public void Activate()
        {
            IsRemoved=false;
        }
    }
}
