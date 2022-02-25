using _01_framwork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiscountManagement.Domain.ColleagueDiscount.Agg
{
    public class ColleagueDiscount:EntityBase<long>
    {
        public long ProductId { get; private set; }
        public int Discount { get;private set; }
        public bool IsRemoved { get; private set; }

        public ColleagueDiscount(long productId, int discount)
        {
            ProductId = productId;
            Discount = discount;
            IsRemoved = false;
        }
        public void Edit(long productId, int discount)
        {
            ProductId = productId;
            Discount = discount;
        }
        public void Remove()
        {
           IsRemoved = true;
        }
        public void Activate()
        {
            IsRemoved = false;
        }
    }
}
