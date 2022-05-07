using _01_framwork.Applicatin;
using AcountManagement.Application.Contracts.Acount;
using AcountManagement.Application.Contracts.Rol;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using ShopManagement.Application.Contracts.Product;
using ShopManagement.Application.Contracts.ProductCategory;
using ShopManagement.Application.ProductCategorys;
using System.Collections.Generic;

namespace ServiceHost.Areas.administration.Pages.Acounts.Acount
{
    public class IndexModel : PageModel
    {

        private readonly AcountManagement.Application.Contracts.Acount.IAcountApplication acountApplication;
        private readonly IRolApplication rolApplication;
        public List<AcountViewModel> Acounts { get; set; }
        public AcountSearchModel SearchModel { get; set; }
        public SelectList RolList { get; set; }
        public IndexModel(AcountManagement.Application.Contracts.Acount.IAcountApplication acountApplication, IRolApplication rolApplication)
        {
            this.acountApplication = acountApplication;
            this.rolApplication = rolApplication;
        }

        public void OnGet(AcountSearchModel searchModel)
        {
            Acounts = acountApplication.Search(searchModel);
            RolList = new SelectList(rolApplication.GetAll(), "Id", "Name");
        }
        public IActionResult OnGetCreate()
        {
            var command = new RegisterAcount();
            command.RolViewModels = rolApplication.GetAll();
            return Partial("./Create", command);
        }
        public JsonResult OnPostCreate(RegisterAcount command)
        {
            var result = acountApplication.Create(command);
            return new JsonResult(result);

        }
        public IActionResult OnGetEdit(long id)
        {
            var Acount = acountApplication.GetDetals(id);
            Acount.RolViewModels = rolApplication.GetAll();
            return Partial("./Edit", Acount);
        }

        public JsonResult OnPostEdit(EditAcount command)
        {
            var result = acountApplication.Edit(command);
            return new JsonResult(result);
        }

        public IActionResult OnGetChangPassword(long id)
        {
            var command = new ChangPassword()
            {
                Id = id
            };
            return Partial("./ChangPassword", command);
        }

        public JsonResult OnPostChangPassword(ChangPassword command)
        {
            var result = acountApplication.ChangPassword(command);
            return new JsonResult(result);
        }
    }
}
