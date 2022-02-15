using _01_framwork.Applicatin;
using ShopManagement.Application.Contracts.Slide;
using ShopManagement.Domain.Slide.Agg;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopManagement.Application.Slider
{
    public class SlideApplication : ISlideApplication
    {
        private readonly ISlideRepository sliderepository;

        public SlideApplication(ISlideRepository sliderepository)
        {
            this.sliderepository = sliderepository;
        }

        public OperationResult Activate(long id)
        {
            OperationResult result = new OperationResult();
            var slide = sliderepository.Get(id);
            if (slide == null)
                return result.Faild(ApplicationMessage.NullMessage);

            slide.Activate();
            sliderepository.Save();
            return result.Success();
        }

        public OperationResult Create(CreateSlide command)
        {
            var result = new OperationResult();
            if (sliderepository.Exist(x => x.Picture == command.Picture && x.Heding == command.Heding))
                return result.Faild(ApplicationMessage.DoblicatedMessage);

            var slide = new Slide(command.Picture, command.PictureAlt, command.PictureTitle, command.Heding, command.Link, command.Title, command.Text, command.BtnText);
            sliderepository.Create(slide);
            sliderepository.Save();
            return result.Success();
        }

        public OperationResult Edit(EditSlide command)
        {
            OperationResult result = new OperationResult();
            var slide = sliderepository.Get(command.Id);
            if (slide == null)
                return result.Faild(ApplicationMessage.NullMessage);

            if (sliderepository.Exist(x => x.Picture == command.Picture && x.Heding == command.Heding && x.Id != command.Id))
                return result.Faild(ApplicationMessage.DoblicatedMessage);

            slide.Edit(command.Picture, command.PictureAlt, command.PictureTitle, command.Heding, command.Link, command.Title, command.Text, command.BtnText);
            sliderepository.Save();
            return result.Success();
        }

        public List<SlideViewModel> GetAll()
        {
            return sliderepository.GetAll();
        }

        public EditSlide GetDetals(long id)
        {
            return sliderepository.GetDetals(id);
        }

        public OperationResult Remove(long id)
        {
            OperationResult result = new OperationResult();
            var slide = sliderepository.Get(id);
            if (slide == null)
                return result.Faild(ApplicationMessage.NullMessage);

            slide.Remove();
            sliderepository.Save();
            return result.Success();
        }
    }
}
