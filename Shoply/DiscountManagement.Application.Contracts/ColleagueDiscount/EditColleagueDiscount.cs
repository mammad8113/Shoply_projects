using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiscountManagement.Application.Contracts.ColleagueDiscount
{
    public class EditColleagueDiscount:CreateColleagueDiscount
    {
        public long Id { get; set; }
    }
}
