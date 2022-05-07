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
        private readonly IFileUploader fileUploader;
        public SlideApplication(ISlideRepository sliderepository, IFileUploader fileUploader)
        {
            this.sliderepository = sliderepository;
            this.fileUploader = fileUploader;
        }

        public OperationResult Activate(long id)
        {
            OperationResult result = new OperationResult();
            var slide = sliderepository.Get(id);
            if (slide == null)
                return result.Faild(ApplicationMessage.NullMessage);

            slide.Activate();
            try
            {
                sliderepository.Save();
            }
            catch
            {
                return result.Faild(ApplicationMessage.UnspecifiedError);
            }
            return result.Success();
        }

        public OperationResult Create(CreateSlide command)
        {
            var result = new OperationResult();
            if (sliderepository.Exist(x => x.Heding == command.Heding))
                return result.Faild(ApplicationMessage.DoblicatedMessage);
            var path = "slides";
            var picture = fileUploader.Upload(command.Picture, path);

            var slide = new Slide(picture, command.PictureAlt, command.PictureTitle, command.Heding, command.Link, command.Title, command.Text, command.BtnText);
            sliderepository.Create(slide);
            try
            {
                sliderepository.Save();
            }
            catch
            {
                return result.Faild(ApplicationMessage.NullFildMessage);
            }
            return result.Success();
        }

        public OperationResult Edit(EditSlide command)
        {
            OperationResult result = new OperationResult();
            var slide = sliderepository.Get(command.Id);
            if (slide == null)
                return result.Faild(ApplicationMessage.NullMessage);

            //if (sliderepository.Exist(x => x.Picture == command.Picture && x.Heding == command.Heding && x.Id != command.Id))
            //    return result.Faild(ApplicationMessage.DoblicatedMessage);

            var path = "slides";
            var picture = fileUploader.Upload(command.Picture, path);
            slide.Edit(picture, command.PictureAlt, command.PictureTitle, command.Heding, command.Link, command.Title, command.Text, command.BtnText);
            try
            {
                sliderepository.Save();
            }
            catch
            {
                return result.Faild(ApplicationMessage.NullFildMessage);
            }
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
            try
            {
                sliderepository.Save();
            }
            catch
            {
                return result.Faild(ApplicationMessage.UnspecifiedError);
            }
            return result.Success();
        }
    }
}
