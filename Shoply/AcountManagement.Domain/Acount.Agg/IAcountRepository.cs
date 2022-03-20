using _01_framwork.Domain;
using AcountManagement.Application.Contracts.Acount;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcountManagement.Domain.Acount.Agg
{
    public interface IAcountRepository:IRepository<long,Acount>
    {
        EditAcount GetDetals(long id);
        public AcountViewModel GetAcount(long id);
        List<AcountViewModel> Search(AcountSearchModel searchModel);
        public List<AcountViewModel> GetAcounts();
    }
}
