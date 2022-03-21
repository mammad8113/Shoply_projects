using _01_framwork.Infrastructure;
using AcountManagement.Application.Contracts.Rol;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using System.Linq;

namespace ServiceHost.Areas.administration.Pages.Acounts.Rol
{
    public class EditModel : PageModel
    {
        public EditRol command { get; set; }
        public List<SelectListItem> Permissions { get; set; } = new List<SelectListItem>();

        private readonly IEnumerable<IPermissionsExposer> exposers;
        private readonly IRolApplication rolApplication;
        public EditModel(IRolApplication rolApplication, IEnumerable<IPermissionsExposer> exposers)
        {
            this.rolApplication = rolApplication;
            this.exposers = exposers;
        }

        public void OnGet(long id)
        {
            command = rolApplication.GetDetals(id);

            foreach (var exposer in exposers)
            {
                var ExposedPermission = exposer.Expos();

                foreach (var (key, value) in ExposedPermission)
                {
                    var group = new SelectListGroup()
                    {
                        Name = key,
                    };

                    foreach (var permission in value)
                    {
                        var item = new SelectListItem(permission.Name, permission.Code.ToString())
                        {
                            Group = group,

                        };

                        if (command.MappPermision.Any(x => x.Code == permission.Code))
                            item.Selected = true;

                        Permissions.Add(item);
                    }
                }
            }
        }

        public IActionResult OnPost(EditRol command)
        {
            var result = rolApplication.Edit(command);
            return RedirectToPage("./Index");
        }
    }
}
