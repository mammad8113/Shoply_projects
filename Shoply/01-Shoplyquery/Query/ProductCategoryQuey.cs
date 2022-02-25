using _01_Shoplyquery.Contracts.ProductCategory;
using ShopManagement.Infrastructure.EfCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01_Shoplyquery.Query
{
    public class ProductCategoryQuey : IProductCategoryQuery
    {
        private readonly ShopContext shopContext;

        public ProductCategoryQuey(ShopContext shopContext)
        {
            this.shopContext = shopContext;
        }

        public List<ProductCategoryQueryModel> GetAll()
        {
            return shopContext.ProductCategories.Where(x => x.IsRemoved == false).Select(x => new ProductCategoryQueryModel
            {
                Id = x.Id,
                Picture=x.Picture,
                Name = x.Name,
                PictureAlt=x.PictureAlt,
                PictureTitle=x.PictureTitle,
                Description=x.Description,
                IsRemoved=x.IsRemoved,
                MetaDescription=x.MetaDescription,
                Keywords=x.Keywords,
                Slug=x.Slug,
            }).OrderByDescending(x => x.Id).ToList();
        }
    }
}
