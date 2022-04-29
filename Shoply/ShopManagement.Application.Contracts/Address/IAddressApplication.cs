using _01_framwork.Applicatin;
using System.Collections.Generic;

namespace ShopManagement.Application.Contracts.Address
{
    public interface IAddressApplication
    {
        long Create(CreateAddress command);
        void Remove(long id);
        OperationResult Edit(EditAddress command);
        EditAddress GetDetals(long id);
        public AddressViewModel GetAddress(long id);
        List<AddressViewModel> GetAll();
    }
}
