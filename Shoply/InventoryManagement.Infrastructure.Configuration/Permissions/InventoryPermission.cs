using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManagement.Infrastructure.Configuration.Permissions
{
    public enum InventoryPermission
    {

        ListInventory = 50,
        SearchInventory = 51,
        CreateInventory = 51,
        EditInventory = 53,
        Reduce = 54,
        Increase = 55,
        Operation=56
    }
}
