using _01_framwork.Applicatin;
using InventoryManagement.Application.Contracts.Inventory;
using InventoryManagement.Domain.Inventory.Agg;
using InventoryManagement.Infrastructure.Repository;
using System;
using System.Collections.Generic;

namespace InventoryManagement.Application
{
    public class InevntoryApplication : IInventoryApplication
    {
        private readonly IInventoryRepository inventoryRepository;
        public InevntoryApplication(IInventoryRepository inventoryRepository)
        {
            this.inventoryRepository = inventoryRepository;
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

            const long operatorId = 1;

            inventory.Reduce(command.Count, operatorId, command.Description, 0);
            inventoryRepository.Save();
            return result.Success();
        }

        public OperationResult Reduce(List<DecreaseInventory> command)
        {
            var result = new OperationResult();

            const long operatorId = 1;
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

            const long operatorId = 1;

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
    }
}
