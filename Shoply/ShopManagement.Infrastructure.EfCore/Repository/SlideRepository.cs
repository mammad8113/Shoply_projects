using _01_framwork.Infrastructure;
using ShopManagement.Application.Contracts.Slide;
using ShopManagement.Domain.Slide.Agg;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopManagement.Infrastructure.EfCore.Repository
{
    public class SlideRepository : BaseRepository<long, Slide>, ISlideRepository
    {
        private readonly ShopContext shopContext;

        public SlideRepository(ShopContext shopContext) : base(shopContext)
        {
            this.shopContext = shopContext;
        }

        public EditSlide GetDetals(long id)
        {
            return shopContext.Slides.Select(x => new EditSlide
            {
                Id = id,
                Picture = x.Picture,
                PictureAlt = x.PictureAlt,
                PictureTitle = x.PictureTitle,
                Heding = x.Heding,
                Link = x.Link,
                Text = x.Text,
                Title = x.Title,
                BtnText = x.BtnText,

            }).FirstOrDefault(x => x.Id == id);
        }

        List<SlideViewModel> ISlideRepository.GetAll()
        {
            return shopContext.Slides.Select(x => new SlideViewModel
            {
                Id=x.Id,
                Picture = x.Picture,
                Heding =x.Heding,
                Title = x.Title,
                CreationDate = x.CreationDate.ToShamsi(),
                IsRemove = x.IsRemove,
            }).OrderByDescending(x => x.Id).ToList();
        }
    }
}
