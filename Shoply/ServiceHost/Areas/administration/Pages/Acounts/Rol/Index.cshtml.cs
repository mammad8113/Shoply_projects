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
    
    }
}
