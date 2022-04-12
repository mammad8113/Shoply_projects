using _01_framwork.Domain;
using ShopManagement.Application.Contracts.Address;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopManagement.Domain.Address.Agg
{
    public interface IAddressRepository:IRepository<long,Address>
    {
        EditAddress GetDetals(long id);
        List<AddressViewModel> GetAll();
    }
}
