using _01_framwork.Applicatin;
using DiscountManagement.Application.Contracts.ColleagueDiscount;
using DiscountManagement.Domain.ColleagueDiscount.Agg;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiscountManagement.Application.ColleagueDiscount
{
    public class ColleagueDiscountApplication : IColleagueDiscountApplication
    {
        private readonly IColleagueDiscountRepository colleagueDiscountRepository;

        public ColleagueDiscountApplication(IColleagueDiscountRepository colleagueDiscountRepository)
        {
            this.colleagueDiscountRepository = colleagueDiscountRepository;
        }

        public OperationResult Activate(long id)
        {
           var result=new OperationResult();
            var colleagueDiscount = colleagueDiscountRepository.Get(id);
            if (colleagueDiscount == null)
                return result.Faild(ApplicationMessage.NullMessage);

            colleagueDiscount.Activate();
            colleagueDiscountRepository.Save();
            return result.Success();

        }

        public OperationResult Create(CreateColleagueDiscount command)
        {
            var result = new OperationResult();
            if (colleagueDiscountRepository.Exist(x => x.ProductId == command.ProductId && x.Discount == command.Discount))
                return result.Faild(ApplicationMessage.DoblicatedMessage);

            var ColleagueDiscount=new Domain.ColleagueDiscount.Agg.ColleagueDiscount(command.ProductId,command.Discount);
            colleagueDiscountRepository.Create(ColleagueDiscount);
            colleagueDiscountRepository.Save();
            return result.Success();
        }

        public OperationResult Edit(EditColleagueDiscount command)
        {
            var result = new OperationResult();
            var colleagueDiscount = colleagueDiscountRepository.Get(command.Id);

            if (colleagueDiscount == null)
                return result.Faild(ApplicationMessage.NullMessage);

            if (colleagueDiscountRepository.Exist(x => x.ProductId == command.ProductId && x.Discount == command.Discount&&x.Id!=command.Id))
                return result.Faild(ApplicationMessage.DoblicatedMessage);

            colleagueDiscount.Edit(command.ProductId, command.Discount);
            colleagueDiscountRepository.Save();
            return result.Success();
        }

        public EditColleagueDiscount GetDetals(long id)
        {
            return colleagueDiscountRepository.GetDetals(id);
        }

        public OperationResult Removed(long id)
        {
            var result = new OperationResult();
            var colleagueDiscount = colleagueDiscountRepository.Get(id);
            if (colleagueDiscount == null)
                return result.Faild(ApplicationMessage.NullMessage);

            colleagueDiscount.Remove();
            colleagueDiscountRepository.Save();
            return result.Success();
        }

        public List<ColleagueDiscountviewModel> Search(ColleagueDiscountSearchModel searchModel)
        {
            return colleagueDiscountRepository.Search(searchModel);
        }
    }
}
