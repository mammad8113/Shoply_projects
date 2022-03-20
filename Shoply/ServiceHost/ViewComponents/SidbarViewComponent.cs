using _01_framwork.Applicatin;
using _01_Shoplyquery.Contracts.ProductCategory;
using AcountManagement.Application.Contracts.Acount;
using Microsoft.AspNetCore.Mvc;

namespace ServiceHost.ViewComponents
{
    public class SidbarViewComponent : ViewComponent
    {

        private readonly IAcountApplication acountApplication;
        private readonly IAuthHelper authHelper;

        public SidbarViewComponent(IAcountApplication acountApplication, IAuthHelper authHelper)
        {
            this.acountApplication = acountApplication;
            this.authHelper = authHelper;
        }

        public IViewComponentResult Invoke()
        {
            var acountId = authHelper.CurrentAccountId();
            var acount = acountApplication.GetAcount(acountId);
            return View(acount);
        }
    }
}
