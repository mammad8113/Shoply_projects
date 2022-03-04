using _01_framwork.Domain;
using ShopManagement.Application.Contracts.Product;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopManagement.Domain.Product.Agg
{
    public interface IProductRepository:IRepository<long,Product>
    {
        EditProduct GetDetals(long id);
        Product GetProductWithCategory(long id);
        List<ProductViewModel> Search(ProductSearchModel searchModel);
        public List<ProductViewModel> GetProducts();

    }
}
