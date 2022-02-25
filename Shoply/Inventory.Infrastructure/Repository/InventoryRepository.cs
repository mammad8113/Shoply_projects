using _0_Framework.Application;
using _01_framwork.Infrastructure;
using InventoryManagement.Application.Contracts.Inventory;
using InventoryManagement.Domain.Inventory.Agg;
using ShopManagement.Infrastructure.EfCore;
using System.Collections.Generic;
using System.Linq;


namespace InventoryManagement.Infrastructure.Repository
{
    public class InventoryRepository : BaseRepository<long, Inventory>, IInventoryRepository
    {
        private readonly InventoryContext _inventoryContext;

        private readonly ShopContext shopContext;
        public InventoryRepository(InventoryContext inventoryContext, ShopContext shopContext) :base(inventoryContext)
        {
            _inventoryContext = inventoryContext;
            this.shopContext = shopContext;
        }

        public Inventory GetBy(long productId)
        {
           return _inventoryContext.Inventories.FirstOrDefault(x=>x.ProductId == productId);
        }

        public EditInventory GetDetals(long id)
        {
          return _inventoryContext.Inventories.Select(x=> new EditInventory { 
          Id = x.Id,
          ProductId = x.ProductId,
          UnitPrice = x.UnitPrice,
          
          }).FirstOrDefault(x=>x.Id == id);
        }

        public List<InventoryOperationViewModel> GetOperation(long id)
        {
            var inventory=_inventoryContext.Inventories.FirstOrDefault(x=>x.Id==id);
            return inventory.Operations.Select(x => new InventoryOperationViewModel {
                Id = x.Id,
                Count = x.Count,
                OperatorId = x.OperatorId,
                Operator = "مدیر سیستم",
                OperatorDate=x.OperatorDate.ToFarsi(),
                Description=x.Description,
                CurrentCount=x.CurrentCount,
                Operation=x.Operation,
                OrderId=x.OrderId,
            }).OrderByDescending(x=>x.Id).ToList();
        }

        public List<InventoryViewModel> Search(InventorySearchModel inventorySearchModel)
        {
            var products = shopContext.Products.Select(x => new { x.Id, x.Name }).ToList();
            var query = _inventoryContext.Inventories.Select(x => new InventoryViewModel { 
            Id = x.Id,
            ProductId=x.ProductId,
            UnitPrice=x.UnitPrice,
            InStock=x.InStock,
            CreationDate=x.CreationDate.ToFarsi(),
            CurrentCount=x.CalculatorCurrentCount()
            });

            if (inventorySearchModel.ProductId > 0)
                query = query.Where(x => x.ProductId == inventorySearchModel.ProductId);

            if (inventorySearchModel.InStock)
                query = query.Where(x => !x.InStock);

            var inventory = query.OrderByDescending(x => x.Id).ToList();
            inventory.ForEach(i => i.Product = products.FirstOrDefault(x => x.Id == i.ProductId)?.Name);

            return inventory;
        }
    }
}
