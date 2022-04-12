using _0_Framework.Application;
using _01_framwork.Applicatin;
using _01_framwork.Infrastructure;
using AcountManagement.Infrastructure.EfCore;
using InventoryManagement.Application.Contracts.Inventory;
using InventoryManagement.Domain.Inventory.Agg;
using ShopManagement.Application.Contracts.Order;
using ShopManagement.Infrastructure.EfCore;
using System;
using System.Collections.Generic;
using System.Linq;


namespace InventoryManagement.Infrastructure.Repository
{
    public class InventoryRepository : BaseRepository<long, Inventory>, IInventoryRepository
    {
        private readonly InventoryContext _inventoryContext;
        private readonly ShopContext shopContext;
        private readonly AcountContext acountContext;
        public InventoryRepository(InventoryContext inventoryContext, ShopContext shopContext, AcountContext acountContext) : base(inventoryContext)
        {
            _inventoryContext = inventoryContext;
            this.shopContext = shopContext;
            this.acountContext = acountContext;
        }

        public Inventory GetBy(long productId)
        {
            return _inventoryContext.Inventories.FirstOrDefault(x => x.ProductId == productId);
        }

        public EditInventory GetDetals(long id)
        {
            return _inventoryContext.Inventories.Select(x => new EditInventory
            {
                Id = x.Id,
                ProductId = x.ProductId,
                UnitPrice = x.UnitPrice,

            }).FirstOrDefault(x => x.Id == id);
        }

        public List<InventoryOperationViewModel> GetOperation(long id)
        {
            var inventory = _inventoryContext.Inventories.FirstOrDefault(x => x.Id == id);
            var Productinventory = inventory.Operations.Select(x => new InventoryOperationViewModel
            {
                Id = x.Id,
                Count = x.Count,
                OperatorId = x.OperatorId,
                OperatorDate = x.OperatorDate.ToFarsi(),
                Description = x.Description,
                CurrentCount = x.CurrentCount,
                Operation = x.Operation,
                OrderId = x.OrderId,
            }).OrderByDescending(x => x.Id).ToList();

            foreach (var item in Productinventory)
            {
                item.Operator = acountContext.Acounts.FirstOrDefault(x => x.Id == item.OperatorId)?.Fullname;
            }
            return Productinventory;
        }


        public List<InventoryViewModel> Search(InventorySearchModel inventorySearchModel)
        {
            var products = shopContext.Products.Select(x => new { x.Id, x.Name }).ToList();
            var query = _inventoryContext.Inventories.Select(x => new InventoryViewModel
            {
                Id = x.Id,
                ProductId = x.ProductId,
                UnitPrice = x.UnitPrice,
                InStock = x.InStock,
                CreationDate = x.CreationDate.ToFarsi(),
                CurrentCount = x.CalculatorCurrentCount()
            });

            if (inventorySearchModel.ProductId > 0)
                query = query.Where(x => x.ProductId == inventorySearchModel.ProductId);

            if (inventorySearchModel.InStock)
                query = query.Where(x => !x.InStock);

            var inventory = query.OrderByDescending(x => x.Id).ToList();
            inventory.ForEach(i => i.Product = products.FirstOrDefault(x => x.Id == i.ProductId)?.Name);

            return inventory;
        }
        public Chart GetChart()
        {



            var countpay = new List<int>();
            var chart = new Chart();
            var BackgroundColor = new List<string>();
            chart.BorderColor = "#161a1d";

            var week = DateTime.Now.Day - 7;

            var startDate = new DateTime(DateTime.Now.Year, DateTime.Now.Month, week);
            var endDate = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day);
            var inventory = _inventoryContext.Inventories.Select(x => new { x.Id, x.ProductId, count = x.CalculatorCurrentCount(), x.Operations }).OrderByDescending(x => x.Id).ToList();
            long totalpay = 0;

            foreach (var item in inventory)
            {
                totalpay += item.Operations.Where(x => !x.Operation).Where(x => x.OperatorDate >= startDate && x.OperatorDate <= endDate).Sum(x => x.Count);

            }

            foreach (var item in inventory)
            {
                var count = item.Operations.Where(x => !x.Operation).Where(x => x.OperatorDate >= startDate && x.OperatorDate <= endDate).Sum(x => x.Count);

                if (count > 0)
                {
                    var darsad = ((count * 100) / totalpay);
                    countpay.Add(Convert.ToInt16(darsad));
                    var name = shopContext.Products.FirstOrDefault(x => x.Id == item.ProductId)?.Name;
                    chart.Labels.Add(name);
                    chart.Label = name;
                    Random random = new Random();
                    var r = random.Next(0, 255);
                    var g = random.Next(0, 255);
                    var b = random.Next(0, 255);
                    BackgroundColor.Add($"rgb({r},{g},{b})");
                }
            }

            chart.Data = countpay;
            chart.BackgroundColor = BackgroundColor;

            return chart;
        }
    }
}
