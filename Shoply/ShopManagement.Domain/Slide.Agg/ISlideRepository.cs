using _01_framwork.Domain;
using ShopManagement.Application.Contracts.Slide;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopManagement.Domain.Slide.Agg
{
    public interface ISlideRepository:IRepository<long,Slide>
    {
        EditSlide GetDetals(long id);
        List<SlideViewModel> GetAll();
    }
}
