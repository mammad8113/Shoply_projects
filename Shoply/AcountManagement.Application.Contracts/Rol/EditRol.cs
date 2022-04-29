using _01_framwork.Infrastructure;
using System.Collections.Generic;

namespace AcountManagement.Application.Contracts.Rol
{
    public class EditRol:CreateRol
    {
        public long Id { get; set; }
        public List<PermissionsDTO> MappPermision { get; set; }=new List<PermissionsDTO>();
    }
}
