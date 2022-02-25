using _01_framwork.Applicatin;
using ShopManagement.Application.Contracts.Product;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManagement.Application.Contracts.Inventory
{
    public class CreateInventory
    {
        [Range(1,10000,ErrorMessage =VallidationMessage.Message)]
        public long ProductId { get; set; }
        [Range(1, double.MaxValue, ErrorMessage = VallidationMessage.Message)]

        public double UnitPrice { get; set; }
        public List<ProductViewModel> Products { get; set; }
    }
}
