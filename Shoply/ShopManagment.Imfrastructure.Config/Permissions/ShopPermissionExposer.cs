using _01_framwork.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopManagment.Infrastructure.Config.Permissions
{
    public class ShopPermissionExposer : IPermissionsExposer
    {
        public Dictionary<string, List<PermissionsDTO>> Expos()
        {
            return new Dictionary<string, List<PermissionsDTO>>
            {
                {
                    "Product",new List<PermissionsDTO>
                {
                        new PermissionsDTO((int)ShopPermission.ListProducts,"ListProducts"),
                        new PermissionsDTO((int)ShopPermission.SearchProducts,"SearchProducts"),
                        new PermissionsDTO((int)ShopPermission.CreateProduct,"CreateProduct"),
                        new PermissionsDTO((int)ShopPermission.EditProduct,"EditProduct"),
                        new PermissionsDTO((int)ShopPermission.RemoveProduct,"RemoveProduct"),
                        new PermissionsDTO((int)ShopPermission.ActivateProduct,"ActivateProduct"),
                }
                },
                {
                    "ProdcutCategory",new List<PermissionsDTO>
                    {
                        new PermissionsDTO((int)ShopPermission.ListProductCategory,"ListProductCategoris"),
                        new PermissionsDTO((int)ShopPermission.SearchProductCategory,"SearchProdutCategories"),
                        new PermissionsDTO((int)ShopPermission.CreateProductCategory,"CreateProductCategory"),
                        new PermissionsDTO((int)ShopPermission.EditProductCategory,"EditProductCategory"),
                        new PermissionsDTO((int)ShopPermission.RemoveProductCategory,"RemoveProductCategory"),
                        new PermissionsDTO((int)ShopPermission.ActivateProductCategory,"ActivateProductCategory"),
                    }
                }
            };
        }
    }
}
