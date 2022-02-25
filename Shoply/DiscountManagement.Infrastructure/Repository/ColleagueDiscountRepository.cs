using _0_Framework.Application;
using _01_framwork.Infrastructure;
using DiscountManagement.Application.Contracts.ColleagueDiscount;
using DiscountManagement.Domain.ColleagueDiscount.Agg;
using ShopManagement.Infrastructure.EfCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiscountManagement.Infrastructure.Repository
{
    public class ColleagueDiscountRepository : BaseRepository<long, ColleagueDiscount>, IColleagueDiscountRepository
    {
        private readonly DiscountContext _context;
        private readonly ShopContext shopContext;
        public ColleagueDiscountRepository(DiscountContext context, ShopContext shopContext) :base(context)
        {
            _context = context;
           this.shopContext = shopContext;
        }

        public EditColleagueDiscount GetDetals(long id)
        {
            return _context.ColleagueDiscounts.Select(x=>new EditColleagueDiscount { 
            Id = x.Id,
            Discount = x.Discount,
            ProductId = x.ProductId,
            
            }).FirstOrDefault(x=>x.Id == id);
        }

        public List<ColleagueDiscountviewModel> Search(ColleagueDiscountSearchModel searchModel)
        {var Products=shopContext.Products.Select(x=>new {id=x.Id,name=x.Name}).ToList();
            var query = _context.ColleagueDiscounts.Select(x => new ColleagueDiscountviewModel { 
            Id = x.Id,
            ProductId = x.ProductId,
            Discount=x.Discount,
            CreationDate=x.CreationDate.ToFarsi(),
            IsRemoved=x.IsRemoved,
            });

            if(searchModel.ProductId>0)
                query=query.Where(x=>x.ProductId==searchModel.ProductId);

            var discount = query.OrderByDescending(x => x.Id).ToList();
            discount.ForEach(d => d.Product = Products.FirstOrDefault(x => x.id == d.ProductId).name);

            return discount;
        }
    }
}
