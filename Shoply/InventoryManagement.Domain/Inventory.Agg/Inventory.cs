using _01_framwork;
using System.Collections.Generic;
using System.Linq;

namespace InventoryManagement.Domain.Inventory.Agg
{
    public class Inventory : EntityBase<long>
    {
        public long ProductId { get; private set ; }
        public double UnitPrice { get; private set ; }
        public bool InStock { get; private set ; }
        public List<InventoryOperation> Operations { get; private set ; }

        protected Inventory()
        {

        }
        public Inventory(long productId, double unitPrice)
        {
            ProductId = productId;
            UnitPrice = unitPrice;
            InStock = false;
        }
        public void Edit(long productId, double unitPrice)
        {
            ProductId = productId;
            UnitPrice = unitPrice;
        }

        public long CalculatorCurrentCount()
        {
            var plus = Operations.Where(x => x.Operation).Sum(x => x.Count);
            var minus = Operations.Where(x => !x.Operation).Sum(x => x.Count);
            return plus - minus;
        }
        public void Increase(long count, long operatorId, string description)
        {
            var currentCount = CalculatorCurrentCount() + count;
            var operation = new InventoryOperation(true, count, operatorId, currentCount, description, 0, Id);
            Operations.Add(operation);
            InStock = currentCount > 0;
        }
        public void Reduce(long count, long operatorId, string description, long orderId)
        {
            var currentCount = CalculatorCurrentCount() - count;
            var operation = new InventoryOperation(false, count, operatorId, currentCount, description, orderId, Id);
            Operations.Add(operation);
            InStock = currentCount > 0;
        }
    }
}
