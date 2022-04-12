using _0_Framework.Application;
using _01_framwork.Domain;
using _01_framwork.Infrastructure;
using AcountManagement.Infrastructure.EfCore;
using ShopManagement.Application.Contracts.Address;
using ShopManagement.Domain.Address.Agg;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ShopManagement.Infrastructure.EfCore.Repository
{
    public class AddressRepository : BaseRepository<long, Address>, IAddressRepository
    {
        private readonly ShopContext _shopContext;
        private readonly AcountContext acountContext;
        public AddressRepository(ShopContext shopContext, AcountContext acountContext) : base(shopContext)
        {
            _shopContext = shopContext;
            this.acountContext = acountContext;
        }
        public EditAddress GetDetals(long id)
        {
            return _shopContext.Addresses.Select(x=>new EditAddress
            {
                Id = x.Id,    
                State = x.State,
                City = x.City,
                Street = x.Street,
                AcountId = x.AcountId,
            }).FirstOrDefault(x=>x.Id == id);
        }
        List<AddressViewModel> IAddressRepository.GetAll()
        {
            var addresses= _shopContext.Addresses.Select(x => new AddressViewModel
            {
                Id=x.Id,
              
                Street = x.Street,
            
                AcountId=x.AcountId,
                CreationDate=x.CreationDate.ToFarsi(),
             
            }).OrderByDescending(x => x.Id).ToList();

            foreach (var item in addresses)
            {
                item.Acount = acountContext.Acounts.FirstOrDefault(x => x.Id == item.AcountId).Fullname;
            }
            return addresses;
        }
    }
}
