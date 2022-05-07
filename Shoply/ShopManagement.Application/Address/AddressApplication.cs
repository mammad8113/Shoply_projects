using _01_framwork.Applicatin;
using ShopManagement.Application.Contracts.Address;
using ShopManagement.Domain.Address.Agg;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopManagement.Application.Address
{
    public class AddressApplication : IAddressApplication
    {
        private readonly IAddressRepository addressRepository;

        public AddressApplication(IAddressRepository addressRepository)
        {
            this.addressRepository = addressRepository;
        }

        public long Create(CreateAddress command)
        {
            var Addresss = new Domain.Address.Agg.Address(command.Street, command.State, command.City, command.AcountId);
            addressRepository.Create(Addresss);
            try
            {
                addressRepository.Save();
            }
            catch (Exception)
            {
                Console.WriteLine(ApplicationMessage.NullFildMessage);
            }
            return Addresss.Id;
        }

        public OperationResult Edit(EditAddress command)
        {
            var operation = new OperationResult();
            var address = addressRepository.GetBy(x => x.Id == command.Id);
            address.Edit(command.Street, command.State, command.City, command.AcountId);
            try
            {
                addressRepository.Save();
            }
            catch
            {
                return operation.Faild(ApplicationMessage.NullFildMessage);
            }
            return operation.Success();
        }

        public AddressViewModel GetAddress(long id)
        {
            return addressRepository.GetAddress(id);
        }

        public List<AddressViewModel> GetAll()
        {
            return addressRepository.GetAll();
        }

        public EditAddress GetDetals(long id)
        {
            return addressRepository.GetDetals(id);
        }

        public void Remove(long id)
        {
            var address = addressRepository.Get(id);
            if (address != null)
                address.Remove();
            try
            {
                addressRepository.Save();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
