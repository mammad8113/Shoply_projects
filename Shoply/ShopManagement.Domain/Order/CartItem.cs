using _0_Framework.Application;
using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopManagement.Domain.Order
{

    public class CartItem
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public double Unitprice { get; set; }
        public string UserUnitprice { get; set; }
        public string picture { get; set; }
        public double TotalPrice { get; set; }
        public int Count { get; set; }
        public int DiscountRate { get; set; }
        public double DiscountAmount { get; set; }
        public double ItemPayAmount { get; set; }
        public bool InStock { get; set; }

        public void calculatorTotalPrice()
        {
            TotalPrice = Unitprice * Count;
        }

    }
}
