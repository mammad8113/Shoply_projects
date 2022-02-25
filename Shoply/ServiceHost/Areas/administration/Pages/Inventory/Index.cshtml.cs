using _01_framwork.Applicatin;
using DiscountManagement.Application.Contracts.ColleagueDiscount;
using DiscountManagement.Application.Contracts.CustomerDiscount;
using InventoryManagement.Application.Contracts.Inventory;
using InventoryManagement.Domain.Inventory.Agg;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using ShopManagement.Application.Contracts.Product;
using ShopManagement.Application.Contracts.ProductCategory;
using ShopManagement.Application.ProductCategorys;
using System.Collections.Generic;

namespace ServiceHost.Areas.administration.Pages.Inventory
{
    public class IndexModel : PageModel
    {
        private readonly IProductApplication productApplication;
        private readonly IInventoryApplication inventoryApplication;
        public List<InventoryViewModel> Inventories { get; set; }
        public InventorySearchModel SearchModel { get; set; }
        public SelectList Products { get; set; }
        public IndexModel(IProductApplication productApplication, IInventoryApplication inventoryApplication)
        {
            this.productApplication = productApplication;
            this.inventoryApplication = inventoryApplication;
        }

        public void OnGet(InventorySearchModel searchModel)
        {
            Inventories = inventoryApplication.Search(searchModel);
            Products = new SelectList(productApplication.GetProducts(), "Id", "Name");
        }
        public IActionResult OnGetCreate()
        {
            var command = new CreateInventory();
            command.Products = productApplication.GetProducts();
            return Partial("./Create", command);
        }
        public JsonResult OnPostCreate(CreateInventory command)
        {
            var result = inventoryApplication.Create(command);
            return new JsonResult(result);
        }
        public IActionResult OnGetEdit(long id)
        {
            var inventory = inventoryApplication.GetDetals(id);
            inventory.Products = productApplication.GetProducts();
            return Partial("./Edit", inventory);
        }

        public JsonResult OnPostEdit(EditInventory command)
        {
            var result = inventoryApplication.Edit(command);
            return new JsonResult(result);
        }
        public IActionResult OnGetIncrease(long id)
        {
            var operation = new IncreaseInventory()
            {
                InventoryId = id,
            };
            return Partial("./Increase", operation);
        }

        public JsonResult OnPostIncrease(IncreaseInventory command)
        {
            var result = inventoryApplication.Increase(command);
            return new JsonResult(result);
        }
        public IActionResult OnGetReduce(long id)
        {
            var operation = new DecreaseInventory()
            {
                InventoryId = id,
            };
            return Partial("./Reduce", operation);
        }

        public JsonResult OnPostReduce(DecreaseInventory command)
        {
            var result = inventoryApplication.Reduce(command);
            return new JsonResult(result);
        }

        public IActionResult OnGetLog(long id)
        {
            var Log = inventoryApplication.GetOperation(id);
            return Partial("./Log", Log);
        }
    }
}
