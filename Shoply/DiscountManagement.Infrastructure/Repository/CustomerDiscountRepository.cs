using _0_Framework.Application;
using _01_framwork.Infrastructure;
using DiscountManagement.Application.Contracts.CustomerDiscount;
using DiscountManagement.Domain.CustomerDiscount.Agg;
using ShopManagement.Infrastructure.EfCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiscountManagement.Infrastructure.Repository
{
    public class CustomerDiscountRepository : BaseRepository<long, CustomerDiscount>, ICustomerDiscountRepository
    {
        private readonly DiscountContext _context;
        private readonly ShopContext shopContext;

        public CustomerDiscountRepository(DiscountContext context, ShopContext shopContext) : base(context)
        {
            _context = context;
            this.shopContext = shopContext;
        }

        public EditCustomerDiscount GetDetals(long id)
        {
            return _context.CustomerDiscounts.Select(x => new EditCustomerDiscount
            {
                Id = x.Id,
                Discount = x.Discount,
                StartDiscount = x.StartDiscount.ToFarsi(),
                EndDiscount = x.EndDiscount.ToFarsi(),
                Title = x.Title,
                ProductId = x.ProductId,
            }).FirstOrDefault(x => x.Id == id);
        }

        public List<CustomerDiscountViewModel> Search(CustomerDiscountSearchModel searchModel)
        {
            var products = shopContext.Products.Select(x => new { Id = x.Id, Name = x.Name }).ToList();
            var query = _context.CustomerDiscounts.Select(x => new CustomerDiscountViewModel
            {
                Id = x.Id,
                ProductId = x.ProductId,
                StartDiscount = x.StartDiscount.ToFarsi(),
                StartDiscountGr=x.StartDiscount,
                EndDiscount = x.EndDiscount.ToFarsi(),
                EndDiscountGr=x.EndDiscount,
                Discount = x.Discount,
                Title = x.Title,
                CreationDate = x.CreationDate.ToFarsi(),
            });

            if (searchModel.ProductId > 0)
                query = query.Where(x => x.ProductId == searchModel.ProductId);

            if (!string.IsNullOrEmpty(searchModel.StartDiscount))
            {
                query = query.Where(x => x.StartDiscountGr >= searchModel.StartDiscount.ToGeorgianDateTime());
            }
            if (!string.IsNullOrEmpty(searchModel.EndDiscount))
            {
                query = query.Where(x => x.EndDiscountGr <= searchModel.EndDiscount.ToGeorgianDateTime());
            }

            var discount = query.OrderByDescending(x => x.Id).ToList();

            discount.ForEach(discount => discount.Product = products.FirstOrDefault(x => x.Id == discount.ProductId).Name);

            return discount;
        }
    }
}
