using _01_Shoplyquery.Contracts.Inventory;
using InventoryManagement.Application.Contracts.Inventory;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace InventoryManagement.Presentation.Api
{
    [Route("api/[controller]")]
    [ApiController]
    public class InventoryController : ControllerBase
    {
        private readonly IInventoryApplication inventoryApplication;
        private readonly IInventoryquery inventoryquery;

        public InventoryController(IInventoryApplication inventoryApplication, IInventoryquery inventoryquery)
        {
            this.inventoryApplication = inventoryApplication;
            this.inventoryquery = inventoryquery;
        }

        [HttpGet("{id}")]
        public List<InventoryOperationViewModel> GetOperation(long id)
        {
            return inventoryApplication.GetOperation(id);
        }

        [HttpPost]
        public InStock CheckInstock(StatuseInevntory statuseInevntory)
        {
            return inventoryquery.CheckInstock(statuseInevntory);
        }
    }
}
