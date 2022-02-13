using _01_framwork.Applicatin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopManagement.Application.Contracts.ProductCategory
{
    public interface IProductCategoryApplication
    {
        OperationResult Create(CreateProductCategory command);
        OperationResult Edit(EditProductCategory command);
        void Removed(long id);
        void Activate(long id);
        EditProductCategory GetDetals(int id);
        List<ProductCategoryViewModel> Search(ProductCategorySearchModel search);
        List<ProductCategoryViewModel> GetProductCategories();

    }
}

