using _01_Shoplyquery.Contracts.Slide;
using ShopManagement.Infrastructure.EfCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01_Shoplyquery.Query
{
    public class SlideQuey : ISlidequery
    {
        private readonly ShopContext shopContext;

        public SlideQuey(ShopContext shopContext)
        {
            this.shopContext = shopContext;
        }

        public List<SlideQuerymodel> GetAll()
        {
            return shopContext.Slides.Where(x => x.IsRemove == false).OrderByDescending(x=>x.CreationDate).Select(x => new SlideQuerymodel
            {
                Picture = x.Picture,
                PictureAlt = x.PictureAlt,
                PictureTitle = x.PictureTitle,
                Heding = x.Heding,
                Link = x.Link,
                Text = x.Text,
                Title = x.Title,
                BtnText = x.BtnText,

            }).ToList();
        }
    }
}
