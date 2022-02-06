using _01_framwork.Applicatin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ShopManagement.Domain.ProductCategory.Agg.Services
{
    public class ValidationProductCategory : IValidationProducatCategory
    {
        private readonly IProductCategoryRepository productCategoryRepository;

        public ValidationProductCategory(IProductCategoryRepository productCategoryRepository)
        {
            this.productCategoryRepository = productCategoryRepository;
        }

        public void Doblicated(Expression<Func<ProductCategory, bool>> expression)
        {

            if (productCategoryRepository.Exist(expression))
                throw new Exception("امکان ثبت رکورد تکراری وجود ندارد");
         
           
        }
    }
}
