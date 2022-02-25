using _01_framwork.Domain;
using DiscountManagement.Application.Contracts.ColleagueDiscount;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiscountManagement.Domain.ColleagueDiscount.Agg
{
    public interface IColleagueDiscountRepository:IRepository<long, ColleagueDiscount>
    {
        EditColleagueDiscount GetDetals(long id);
        public List<ColleagueDiscountviewModel> Search(ColleagueDiscountSearchModel searchModel);
    }
}
