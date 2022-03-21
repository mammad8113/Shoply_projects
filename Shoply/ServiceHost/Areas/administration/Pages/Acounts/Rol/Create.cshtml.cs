using _01_framwork.Infrastructure;
using AcountManagement.Application.Contracts.Rol;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;

namespace ServiceHost.Areas.administration.Pages.Acounts.Rol
{
    public class CreateModel : PageModel
    {
        public CreateRol command { get; set; }

        public List<SelectListItem> Permissions { get; set; } = new List<SelectListItem>();


        private readonly IRolApplication rolApplication;
        private readonly IEnumerable<IPermissionsExposer> exposers;

        public CreateModel(IRolApplication rolApplication, IEnumerable<IPermissionsExposer> exposers)
        {
            this.rolApplication = rolApplication;
            this.exposers = exposers;
        }

        public void OnGet()
        {
            foreach (var exposer in exposers)
            {
                var permissionExposer = exposer.Expos();
                foreach (var (key, value) in permissionExposer)
                {
                    var group = new SelectListGroup
                    {
                        Name = key,
                    };

                    foreach (var permission in value)
                    {
                        var item = new SelectListItem(permission.Name, permission.Code.ToString())
                        {
                            Group = group,
                        };
                        Permissions.Add(item);
                    }
                }
            }


        }

        public IActionResult OnPost(CreateRol command)
        {
            var result = rolApplication.Create(command);
            return RedirectToPage(result);
        }

    }
}
