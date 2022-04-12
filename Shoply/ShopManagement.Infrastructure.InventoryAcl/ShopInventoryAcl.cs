using InventoryManagement.Application.Contracts.Inventory;
using ShopManagement.Domain.Order.Agg;
using ShopManagement.Domain.Services;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ShopManagement.Infrastructure.Services.Acl
{
    public class ShopInventoryAcl : IShopInventoryAcl
    {
        private readonly IInventoryApplication inventoryApplication;

        public ShopInventoryAcl(IInventoryApplication inventoryApplication)
        {
            this.inventoryApplication = inventoryApplication;
        }

        public bool ReduceFromInventory(List<OrderItem> items)
        {
            var command = items.Select(item =>
                new DecreaseInventory(item.ProductId, item.Count, "خرید مشتری از سایت", item.OrderId)).ToList();
            return inventoryApplication.Reduce(command).IsSuccedded;
        }
    }
}
