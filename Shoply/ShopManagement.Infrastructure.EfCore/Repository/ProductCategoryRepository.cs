using _01_framwork.Applicatin;
using _01_framwork.Infrastructure;
using ShopManagement.Application.Contracts.ProductCategory;
using ShopManagement.Domain.ProductCategory;
using ShopManagement.Domain.ProductCategory.Agg;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ShopManagement.Infrastructure.EfCore.Repository
{
    public class ProductCategoryRepository : BaseRepository<long, ProductCategory>, IProductCategoryRepository
    {
        private readonly ShopContext _shopContext;

        public ProductCategoryRepository(ShopContext shopContext) : base(shopContext)
        {
            _shopContext = shopContext;
        }

        public EditProductCategory GetDetals(long id)
        {
            return _shopContext.ProductCategories.Select(x => new EditProductCategory
            {
                Id = x.Id,
                Name = x.Name,
                Description = x.Description,
                PicturePath = x.Picture,
                PictureTitle = x.PictureTitle,
                PictureAlt = x.PictureAlt,

                MetaDescription = x.MetaDescription,
                Keywords = x.Keywords,
                Slug = x.Slug,

            }).FirstOrDefault(x => x.Id == id);

        }

        public List<ProductCategoryViewModel> GetProductCategories(long id)
        {
            var query = _shopContext.ProductCategories;
            if (id != 0)
                query.Where(x => x.Parent == id);

            return query.Select(x => new ProductCategoryViewModel
            {
                Id = x.Id,
                Name = x.Name,
                CreationDate = x.CreationDate.ToShamsi(),
                Picture = x.Picture,
                IsRemoved = x.IsRemoved,

            }).OrderByDescending(x => x.Id).ToList();
        }

        public string GetSlug(long id)
        {
           return _shopContext.ProductCategories.Select(x => new {x.Id,x.Slug}).FirstOrDefault(x=>x.Id == id).Slug;
        }

        public List<ProductCategoryViewModel> Search(ProductCategorySearchModel searchModel)
        {
            var query = _shopContext.ProductCategories.Where(x => x.Parent == searchModel.Parent).Select(x => new ProductCategoryViewModel
            {
                Id = x.Id,
                Name = x.Name,
                CreationDate = x.CreationDate.ToString(),
                Picture = x.Picture,
                IsRemoved = x.IsRemoved,


            });

            if (!string.IsNullOrWhiteSpace(searchModel.Name))
                query = query.Where(x => x.Name.Contains(searchModel.Name));

            return query.OrderByDescending(x => x.Id).ToList();
        }
    }
}
