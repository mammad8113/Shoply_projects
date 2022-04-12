using _01_framwork.Applicatin;
using InventoryManagement.Application.Contracts.Inventory;
using InventoryManagement.Domain.Inventory.Agg;
using InventoryManagement.Infrastructure.Repository;
using ShopManagement.Application.Contracts.Order;
using System;
using System.Collections.Generic;

namespace InventoryManagement.Application
{
    public class InevntoryApplication : IInventoryApplication
    {
        private readonly IInventoryRepository inventoryRepository;
        private readonly IAuthHelper authHelper;
        public InevntoryApplication(IInventoryRepository inventoryRepository, IAuthHelper authHelper)
        {
            this.inventoryRepository = inventoryRepository;
            this.authHelper = authHelper;
        }

        public OperationResult Create(CreateInventory command)
        {
            var result = new OperationResult();
            if (inventoryRepository.Exist(x => x.ProductId == command.ProductId))
                return result.Faild(ApplicationMessage.DoblicatedMessage);

            Inventory inventory = new Inventory(command.ProductId, command.UnitPrice);
            inventoryRepository.Create(inventory);
            inventoryRepository.Save();
            return result.Success();

        }

        public OperationResult Reduce(DecreaseInventory command)
        {
            var result = new OperationResult();

            var inventory = inventoryRepository.Get(command.InventoryId);
            if (inventory is null)
                return result.Faild(ApplicationMessage.NullMessage);

            var operatorId = authHelper.CurrentAccountId();

            inventory.Reduce(command.Count, operatorId, command.Description, 0);
            inventoryRepository.Save();
            return result.Success();
        }

        public OperationResult Reduce(List<DecreaseInventory> command)
        {
            var result = new OperationResult();

            var operatorId = authHelper.CurrentAccountId();

            foreach (var item in command)
            {
                var inventory = inventoryRepository.GetBy(item.ProductId);
                if (inventory is null)
                    return result.Faild(ApplicationMessage.NullMessage);

                inventory.Reduce(item.Count, operatorId, item.Description, item.OrederId);
            }

            inventoryRepository.Save();
            return result.Success();
        }

        public OperationResult Edit(EditInventory command)
        {
            var result = new OperationResult();
            var inventory = inventoryRepository.Get(command.Id);

            if (inventory is null)
                return result.Faild(ApplicationMessage.NullMessage);

            if (inventoryRepository.Exist(x => x.ProductId == command.ProductId && x.Id != command.Id))
                return result.Faild(ApplicationMessage.DoblicatedMessage);

            inventory.Edit(command.ProductId, command.UnitPrice);
            inventoryRepository.Save();
            return result.Success();
        }

        public EditInventory GetDetals(long id)
        {
            return inventoryRepository.GetDetals(id);
        }

        public OperationResult Increase(IncreaseInventory command)
        {
            var result = new OperationResult();
            var inventory = inventoryRepository.Get(command.InventoryId);
            if (inventory is null)
                return result.Faild(ApplicationMessage.NullMessage);

            var operatorId = authHelper.CurrentAccountId();

            inventory.Increase(command.Count, operatorId, command.Description);
            inventoryRepository.Save();
            return result.Success();
        }

        public List<InventoryViewModel> Search(InventorySearchModel inventorySearchModel)
        {
            return inventoryRepository.Search(inventorySearchModel);
        }

        public List<InventoryOperationViewModel> GetOperation(long id)
        {
            return inventoryRepository.GetOperation(id);
        }

        public Chart GetChart()
        {
          return  inventoryRepository.GetChart();
        }
    }
}
