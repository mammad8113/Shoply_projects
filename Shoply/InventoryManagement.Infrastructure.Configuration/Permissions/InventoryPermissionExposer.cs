using _01_framwork.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManagement.Infrastructure.Configuration.Permissions
{
    public class InventoryPermissionExposer : IPermissionsExposer
    {
        public Dictionary<string, List<PermissionsDTO>> Expos()
        {
            return new Dictionary<string, List<PermissionsDTO>>
            {
                {
                    "Inventory",new List<PermissionsDTO>
                    {
                        new PermissionsDTO((int) InventoryPermission.ListInventory,"ListInventory"),
                        new PermissionsDTO((int) InventoryPermission.SearchInventory,"SearchInventory"),
                        new PermissionsDTO((int) InventoryPermission.CreateInventory,"CreateInventory"),
                        new PermissionsDTO((int) InventoryPermission.EditInventory,"EditInventory"),
                        new PermissionsDTO((int) InventoryPermission.Reduce,"ReduceInventory"),
                        new PermissionsDTO((int) InventoryPermission.Increase,"IncreaseInventory"),
                        new PermissionsDTO((int) InventoryPermission.Operation,"OperationInventory"),
                    }
                }
            };
        }
    }
}
