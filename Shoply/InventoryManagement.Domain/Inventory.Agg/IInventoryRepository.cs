using _01_framwork.Domain;
using InventoryManagement.Application.Contracts.Inventory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManagement.Domain.Inventory.Agg
{
    public interface IInventoryRepository:IRepository<long, Inventory>
    {
        EditInventory GetDetals(long id);
        Inventory GetBy(long productId);
        List<InventoryViewModel> Search(InventorySearchModel inventorySearchModel);
        List<InventoryOperationViewModel> GetOperation(long id);

    }
}
