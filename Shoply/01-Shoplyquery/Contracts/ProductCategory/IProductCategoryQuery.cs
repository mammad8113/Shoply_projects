using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01_Shoplyquery.Contracts.ProductCategory
{
    public interface IProductCategoryQuery
    {
        int Count(string? slug);
        ProductCategoryQueryModel GetProductCategoryWithProductsForPagationBy(string slug,int page,int number=1);
        List<ProductCategoryQueryModel> GetAll();
        List<ProductCategoryQueryModel> GetProductCategoryWithProducts();
    }
}
