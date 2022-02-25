using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiscountManagement.Application.Contracts.CustomerDiscount
{
    public class CustomerDiscountViewModel
    {
        public long Id { get; set; }
        public long ProductId { get; set; }
        public string Product { get; set; }
        public int Discount { get; set; }
        public string StartDiscount { get; set; }
        public DateTime StartDiscountGr { get; set; }
        public string EndDiscount { get; set; }
        public DateTime EndDiscountGr { get; set; }
        public string Title { get; set; }
        public string CreationDate { get; set; }
    }
}
