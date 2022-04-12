using _01_Shoplyquery.Contracts.Inventory;
using InventoryManagement.Infrastructure;
using ShopManagement.Infrastructure.EfCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01_Shoplyquery.Query
{
    public class InventoryQuery : IInventoryquery
    {
        private readonly ShopContext shopContext;
        private readonly InventoryContext inventoryContext;

        public InventoryQuery(ShopContext shopContext, InventoryContext inventoryContext)
        {
            this.shopContext = shopContext;
            this.inventoryContext = inventoryContext;
        }

        public InStock CheckInstock(StatuseInevntory statuseInevntory)
        {
            var inventory = inventoryContext.Inventories.FirstOrDefault(x => x.ProductId == statuseInevntory.ProductId);
            if (inventory == null || inventory.CalculatorCurrentCount() < statuseInevntory.Count)
            {
                var product = shopContext.Products.Select(x => new { x.Id, x.Name }).FirstOrDefault(x => x.Id == statuseInevntory.ProductId).Name;
                return new InStock
                {
                    IsInstock=false,
                    Product=product
                };
            }


            return new InStock
            {
                IsInstock = true,
            };
        }
    }
}
