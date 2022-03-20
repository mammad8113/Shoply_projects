using AcountManagement.Application.Contracts.Acount;
using AcountManagement.Application.Contracts.Rol;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using ShopManagement.Application.Contracts.Product;
using ShopManagement.Application.Contracts.ProductCategory;
using ShopManagement.Application.ProductCategorys;
using System.Collections.Generic;

namespace ServiceHost.Areas.administration.Pages.Acounts.Rol
{
    public class IndexModel : PageModel
    {
        private readonly IRolApplication rolApplication;
        public List<RolViewModel> Rols { get; set; }
        public IndexModel(IRolApplication rolApplication)
        {
            this.rolApplication = rolApplication;
        }

        public void OnGet()
        {
            Rols = rolApplication.GetAll();
        }
        public IActionResult OnGetCreate()
        {
            var command = new CreateRol();
            return Partial("./Create", command);
        }
        public JsonResult OnPostCreate(EditRol command)
        {
            var result = rolApplication.Create(command);
            return new JsonResult(result);
        }
        public IActionResult OnGetEdit(long id)
        {
            var product = rolApplication.GetDetals(id);
            return Partial("./Edit", product);
        }

        public JsonResult OnPostEdit(EditRol command)
        {
            var result = rolApplication.Edit(command);
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

    }
}
