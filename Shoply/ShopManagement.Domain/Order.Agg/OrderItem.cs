using _01_framwork;

namespace ShopManagement.Domain.Order.Agg
{
    public class OrderItem : EntityBase<long>
    {
        public long ProductId { get; private set; }
        public double UnitPrice { get; private set; }
        public int Count { get; private set; }
        public int DiscountRate { get; private set; }
        public double PriceWithdiscount { get; set; }
        public long OrderId { get; private set; }
        public Order Order { get; private set; }

        protected OrderItem()
        {

        }

        public OrderItem(long productId, double unitPrice, double priceWithdiscount, int count, int discountRate)
        {
            ProductId = productId;
            UnitPrice = unitPrice;
            Count = count;
            DiscountRate = discountRate;
            PriceWithdiscount = priceWithdiscount;
        }
    }
}