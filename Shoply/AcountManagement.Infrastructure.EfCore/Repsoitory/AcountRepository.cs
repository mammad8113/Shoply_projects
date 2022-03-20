using _0_Framework.Application;
using _01_framwork.Infrastructure;
using AcountManagement.Application.Contracts.Acount;
using AcountManagement.Domain.Acount.Agg;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcountManagement.Infrastructure.EfCore.Repsoitory
{
    public class AcountRepository : BaseRepository<long, Acount>, IAcountRepository
    {
        private readonly AcountContext _context;

        public AcountRepository(AcountContext context) : base(context)
        {
            _context = context;
        }

        public EditAcount GetDetals(long id)
        {
            return _context.Acounts.Include(x => x.Rol).Select(x => new EditAcount
            {
                Id = x.Id,
                Fullname = x.Fullname,
                Username = x.Username,
                Mobile = x.Mobile,
                RolId = x.RolId,
            }).FirstOrDefault(x => x.Id == id);
        }

        public List<AcountViewModel> Search(AcountSearchModel searchModel)
        {
            var query = _context.Acounts.Include(x => x.Rol).Select(x => new AcountViewModel
            {
                Id = x.Id,
                Fullname = x.Fullname,
                Username = x.Username,
                Mobile = x.Mobile,
                UserPhoto = x.UserPhoto,
                CreationDate = x.CreationDate.ToFarsi(),
                RolId = x.RolId,
                Rol = x.Rol.Name
            });

            if (!string.IsNullOrWhiteSpace(searchModel.Fullname))
                query = query.Where(x => x.Fullname.Contains(searchModel.Fullname));

            if (!string.IsNullOrWhiteSpace(searchModel.Username))
                query = query.Where(x => x.Username.Contains(searchModel.Username));

            if (!string.IsNullOrWhiteSpace(searchModel.Mobil))
                query = query.Where(x => x.Mobile.Contains(searchModel.Mobil));

            if (searchModel.RolId > 0)
                query = query.Where(x => x.RolId == searchModel.RolId);


            return query.OrderByDescending(x => x.Id).ToList();

        }
        public List<AcountViewModel> GetAcounts()
        {
            return _context.Acounts.Include(x => x.Rol).Select(x => new AcountViewModel
            {
                Id = x.Id,
                Fullname = x.Fullname,
                Username = x.Username,
                Mobile = x.Mobile,
                UserPhoto = x.UserPhoto,
                CreationDate = x.CreationDate.ToFarsi(),
                RolId = x.RolId,
                Rol = x.Rol.Name
            }).OrderByDescending(x => x.Id).ToList();

        }

        public AcountViewModel GetAcount(long id)
        {
            return _context.Acounts.Include(x => x.Rol).Select(x => new AcountViewModel
            {
                Id = x.Id,
                Fullname = x.Fullname,
                Username = x.Username,
                Mobile = x.Mobile,
                UserPhoto= x.UserPhoto,
                RolId = x.RolId,
                Rol=x.Rol.Name
            }).FirstOrDefault(x => x.Id == id);
        }
    }
}
