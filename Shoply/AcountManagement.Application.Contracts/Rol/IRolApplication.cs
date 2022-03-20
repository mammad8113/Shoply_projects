using _01_framwork.Applicatin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcountManagement.Application.Contracts.Rol
{
    public interface IRolApplication
    {
        OperationResult Create(CreateRol command);
        OperationResult Edit(EditRol command);
        EditRol GetDetals(long id);
        List<RolViewModel> GetAll();
    }
}
