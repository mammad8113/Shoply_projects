using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiscountManagement.Application.Contracts.ColleagueDiscount
{
    public class ColleagueDiscountviewModel
    {
        public long Id { get; set; }
        public long ProductId { get; set; }
        public string Product { get; set; }
        public int Discount { get; set; }
        public bool IsRemoved { get; set; }
        public string CreationDate { get; set; }
    }
}
