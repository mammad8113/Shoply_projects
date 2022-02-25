using _01_framwork.Applicatin;
using InventoryManagement.Domain.Inventory.Agg;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManagement.Application.Contracts.Inventory
{
    public interface IInventoryApplication
    {
        OperationResult Create(CreateInventory command);
        OperationResult Edit(EditInventory command);
        OperationResult Increase(IncreaseInventory command);
        OperationResult Reduce(DecreaseInventory command);
        OperationResult Reduce(List<DecreaseInventory> command);
        EditInventory GetDetals(long id);
        List<InventoryViewModel> Search(InventorySearchModel inventorySearchModel);
        List<InventoryOperationViewModel> GetOperation(long id);
    }
}
