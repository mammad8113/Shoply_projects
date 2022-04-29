using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01_Shoplyquery.Contracts.ProductCategory
{
    public interface IProductCategoryQuery
    {
        int Count(string slug);
        ProductCategoryQueryModel GetProductCategoryWithProductsForPagationBy(string slug);
        List<ProductCategoryQueryModel> GetAll();
        List<ProductCategoryQueryModel> GetProductCategoryWithProducts();
        public List<Breadcrumb> GetParent(long? id);
        ProductCategoryQueryModel GetCategoryName(long? id);
        public List<ProductCategoryQueryModel> GetChildren(long id);
        public ProductCategoryQueryModel GetCategory(long id);
        public List<ProductCategoryQueryModel> GetCategoriesOverriding();
    }
}
