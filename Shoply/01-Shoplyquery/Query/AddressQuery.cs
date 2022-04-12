using _01_Shoplyquery.Contracts.Address;
using AcountManagement.Infrastructure.EfCore;
using ShopManagement.Application.Contracts.Order;
using ShopManagement.Infrastructure.EfCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01_Shoplyquery.Query
{
    public class AddressQuery : IAddressQuery
    {
        private readonly ShopContext shopContext;
        private readonly AcountContext acountContext;
        public AddressQuery(ShopContext shopContext, AcountContext acountContext)
        {
            this.shopContext = shopContext;
            this.acountContext = acountContext;
        }

        public List<AddressqueryModel> GetAcountAddress(long id)
        {
            var addresses = shopContext.Addresses.Where(x => x.AcountId == id&& !x.IsRemove).Select(x => new AddressqueryModel
            {
                Id = x.Id,
                Street = x.Street,
                State = States.getBy(x.State).Name,
                StateId=x.State,
                City = Cities.GetBy(x.City).Name,
                AcountId = x.AcountId,
            }).OrderByDescending(x => x.Id).ToList();

            foreach (var address in addresses)
            {
                address.Acount = acountContext.Acounts.FirstOrDefault(x => x.Id == address.AcountId).Fullname;
            }

            return addresses;
        }
    }
}
