using _01_framwork.Applicatin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ShopManagement.Domain.ProductCategory.Agg.Services
{
    public interface IValidationProducatCategory
    {
        void Doblicated(Expression<Func<ProductCategory, bool>> expression);
       
        
    }
}
