using _01_framwork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopManagement.Domain.Order.Agg
{
    public class Order : EntityBase<long>
    {
        public long AcountId { get; private set; }
        public int PaymentMethod { get; set; }
        public double TotalAmount { get; private set; }
        public double DiscountAmount { get; private set; }
        public double PayAmount { get; private set; }
        public bool IsPiad { get; private set; }
        public bool IsCanceled { get; private set; }
        public string IssueTrakingNo { get; private set; }
        public long RefId { get; private set; }
        public long AddressId { get; private set; }
        public bool IsShow { get; set; }
        public Address.Agg.Address Address { get; set; }
        public List<OrderItem> OrderItems { get; private set; }
        
        protected Order()
        {
        }
        public Order(long acountId, int paymentMethod, double totalAmount, double discountAmount, double payAmount, long addressId)
        {
            AcountId = acountId;
            PaymentMethod = paymentMethod;
            TotalAmount = totalAmount;
            DiscountAmount = discountAmount;
            PayAmount = payAmount;
            AddressId = addressId;
            IsCanceled = false;
            IsPiad = false;
            RefId = 0;
            IsShow = false;
            OrderItems = new List<OrderItem>();
        }

        public void PaymentSuccedd(long refid)
        {
            IsPiad = true;
            if (refid != 0)
                RefId = refid;
        }
        public void Cancel()
        {
            IsCanceled = true;
        }

        public void SetIssueTrakingNo(string issueTrakingNo)
        {
            IssueTrakingNo = issueTrakingNo;
        }
        public void AddItem(OrderItem orderItem)
        {
            OrderItems.Add(orderItem);
        }
        public void Show()
        {
            IsShow = true;
        }
    }
}
