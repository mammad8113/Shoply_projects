using ShopManagement.Application.Contracts.Order;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopManagement.Application.Contracts.Address
{
    public class CreateAddress
    {
        public string Street { get; set; }
        public long State { get; set; }
        public long City { get; set; }
        public long AcountId { get; set; }
        public List<States> States { get; set; }
        public List<Cities> Cities { get; set; }
    }
}
