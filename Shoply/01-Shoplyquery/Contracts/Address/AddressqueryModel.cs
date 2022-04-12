using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01_Shoplyquery.Contracts.Address
{
    public class AddressqueryModel
    {
        public long Id { get; set; }
        public string State { get; set; }
        public long StateId { get; set; }
        public string City { get; set; }
        public string Street { get; set; }
        public string Acount { get; set; }
        public long AcountId { get; set; }
    }
}
