using _01_framwork.Domain;
using AcountManagement.Application.Contracts.Rol;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcountManagement.Domain.Rol.Agg
{
    public interface IRolRepository:IRepository<long,Role>
    {
        EditRol GetDetals(long id);
        List<RolViewModel> GetAll();
    }
}