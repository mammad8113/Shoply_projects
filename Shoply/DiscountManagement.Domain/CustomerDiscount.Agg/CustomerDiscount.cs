using _01_framwork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiscountManagement.Domain.CustomerDiscount.Agg
{
    public class CustomerDiscount : EntityBase<long>
    {
        public long ProductId { get; private set; }
        public int Discount { get; private set; }
        public DateTime StartDiscount { get; private set; }
        public DateTime EndDiscount { get; private set; }
        public string Title { get; private set; }

        public CustomerDiscount(long productId, int discount, DateTime startDiscount, DateTime endDiscount, string title)
        {
            ProductId = productId;
            Discount = discount;
            StartDiscount = startDiscount;
            EndDiscount = endDiscount;
            Title = title;
        }

        public void Edit(long productId, int discount, DateTime startDiscount, DateTime endDiscount, string title)
        {
            ProductId = productId;
            Discount = discount;
            StartDiscount = startDiscount;
            EndDiscount = endDiscount;
            Title = title;
        }
    }
}
