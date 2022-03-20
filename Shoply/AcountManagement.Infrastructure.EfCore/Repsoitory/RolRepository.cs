using _0_Framework.Application;
using _01_framwork.Infrastructure;
using AcountManagement.Application.Contracts.Rol;
using AcountManagement.Domain.Rol.Agg;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcountManagement.Infrastructure.EfCore.Repsoitory
{
    public class RolRepository : BaseRepository<long, Rol>, IRolRepository
    {
        private AcountContext _context;

        public RolRepository(AcountContext context):base(context)
        {
            _context = context;
        }

        public EditRol GetDetals(long id)
        {
            return _context.Rols.Select(x => new EditRol
            {
                Id = id,
                Name = x.Name,
            }).FirstOrDefault(x => x.Id==id);
        }

        List<RolViewModel> IRolRepository.GetAll()
        {
           return _context.Rols.Select(x=>new RolViewModel
           {
               Id = x.Id,
               Name = x.Name,
               CreationDate=x.CreationDate.ToFarsi(),
           }).OrderByDescending(x=>x.Id).ToList();
        }
    }
}
