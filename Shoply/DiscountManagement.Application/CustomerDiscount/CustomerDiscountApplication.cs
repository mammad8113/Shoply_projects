using _0_Framework.Application;
using _01_framwork.Applicatin;
using DiscountManagement.Application.Contracts.CustomerDiscount;
using DiscountManagement.Domain.CustomerDiscount.Agg;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiscountManagement.Application.CustomerDiscount
{
    public class CustomerDiscountApplication : ICustomerDiscountApplication
    {
        private readonly ICustomerDiscountRepository customerDiscountRepository;

        public CustomerDiscountApplication(ICustomerDiscountRepository customerDiscountRepository)
        {
            this.customerDiscountRepository = customerDiscountRepository;
        }

        public OperationResult Create(CreateCustomerDiscount command)
        {
            OperationResult result = new OperationResult();
            if (customerDiscountRepository.Exist(x => x.ProductId == command.ProductId))
                return result.Faild(ApplicationMessage.DoblicatedMessage);

            var customerDiscount = new Domain.CustomerDiscount.Agg.CustomerDiscount(command.ProductId, command.Discount,
                command.StartDiscount.ToGeorgianDateTime(), command.EndDiscount.ToGeorgianDateTime(), command.Title);
            customerDiscountRepository.Create(customerDiscount);
            customerDiscountRepository.Save();
            return result.Success();

        }

        public OperationResult Edit(EditCustomerDiscount command)
        {
            OperationResult result = new OperationResult();
            var customerdiscount = customerDiscountRepository.Get(command.Id);
            if (customerdiscount is null)
                return result.Faild(ApplicationMessage.NullMessage);

            if (customerDiscountRepository.Exist(x => x.ProductId == command.ProductId && x.Id != command.Id))
                return result.Faild(ApplicationMessage.DoblicatedMessage);

            customerdiscount.Edit(command.ProductId, command.Discount,
                command.StartDiscount.ToGeorgianDateTime(), command.EndDiscount.ToGeorgianDateTime(), command.Title);
            customerDiscountRepository.Save();

            return result.Success();

        }

        public EditCustomerDiscount GetDetals(long id)
        {
           return customerDiscountRepository.GetDetals(id);
        }

        public List<CustomerDiscountViewModel> Search(CustomerDiscountSearchModel searchModel)
        {
            return customerDiscountRepository.Search(searchModel);  
        }
    }
}
