using ShopManagement.Application.Contracts.Order;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopManagement.Application.Order
{
    public class CityServices : ICityServices
    {
        public List<Cities> Cities { get; set; }
        public List<Cities> Get()
        {
            return this.Cities;
        }

        public void Set(List<Cities> cities)
        {
            this.Cities = cities;
        }
    }
}
