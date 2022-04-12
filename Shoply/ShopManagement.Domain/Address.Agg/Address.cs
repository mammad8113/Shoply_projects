using _01_framwork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopManagement.Domain.Address.Agg
{
    public class Address : EntityBase<long>
    {
        public string Street { get; private set; }
        public long State { get; private set; }
        public long City { get; private set; }
        public bool IsRemove { get; set; }
        public long AcountId { get; private set; }
        public List<Order.Agg.Order> Orders { get; set; }

        public Address(string street, long state, long city, long acountId)
        {
            Street = street;
            State = state;
            City = city;
            AcountId = acountId;
            IsRemove = false;
        }

        public void Edit(string street, long state, long city, long acountId)
        {
            Street = street;
            State = state;
            City = city;
            AcountId = acountId;
        }

        public void Remove()
        {
            IsRemove = true;
        }
    }
}
