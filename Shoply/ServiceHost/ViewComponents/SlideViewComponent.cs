using _01_Shoplyquery.Contracts.Slide;
using Microsoft.AspNetCore.Mvc;

namespace ServiceHost.ViewComponents
{
    public class SlideViewComponent:ViewComponent
    {
        private readonly ISlidequery slidequery;

        public SlideViewComponent(ISlidequery slidequery)
        {
            this.slidequery = slidequery;
        }

        public IViewComponentResult Invoke()
        {
            var slides = slidequery.GetAll();
            return View(slides);
        }
    }
}
