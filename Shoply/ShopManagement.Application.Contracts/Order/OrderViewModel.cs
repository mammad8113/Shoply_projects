using ShopManagement.Application.Contracts.Address;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopManagement.Application.Contracts.Order
{
    public class OrderViewModel
    {
        public long Id { get; set; }
        public long AcountId { get; set; }
        public string Acount { get; set; }
        public int PaymentMethodId { get; set; }
        public string PaymentMethod { get; set; }
        public double TotalAmount { get; set; }
        public double DiscountAmount { get; set; }
        public double PayAmount { get; set; }
        public bool IsPiad { get; set; }
        public bool IsCanceled { get; set; }
        public string IssueTrakingNo { get; set; }
        public long RefId { get; set; }
        public string CreationDate { get; set; }
        public AddressViewModel Address { get; set; }
    }
}
