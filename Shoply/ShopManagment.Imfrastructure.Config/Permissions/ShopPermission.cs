using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopManagment.Infrastructure.Config.Permissions
{
    public  enum ShopPermission
    {
        // ProductPermissions

        ListProducts = 10,
        SearchProducts = 11,
        CreateProduct = 12,
        EditProduct = 13,
        RemoveProduct = 14,
        ActivateProduct = 15,

        //ProductCategoryPermissions

        ListProductCategory = 20,
        SearchProductCategory = 21,
        CreateProductCategory = 22,
        EditProductCategory = 23,
        RemoveProductCategory = 24,
        ActivateProductCategory = 25,

    }
}
