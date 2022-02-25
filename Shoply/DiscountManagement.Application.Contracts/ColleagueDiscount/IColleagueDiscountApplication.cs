using _01_framwork.Applicatin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiscountManagement.Application.Contracts.ColleagueDiscount
{
    public interface IColleagueDiscountApplication
    {
        OperationResult Create(CreateColleagueDiscount command);
        OperationResult Edit(EditColleagueDiscount command);
        OperationResult Removed(long id);
        OperationResult Activate(long id);
        EditColleagueDiscount GetDetals(long id);
        public List<ColleagueDiscountviewModel> Search(ColleagueDiscountSearchModel searchModel);
    }
}
