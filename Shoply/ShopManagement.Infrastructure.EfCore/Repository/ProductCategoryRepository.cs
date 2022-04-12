using _0_Framework.Application;
using _01_framwork.Applicatin;
using _01_framwork.Infrastructure;
using Microsoft.EntityFrameworkCore;
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
                ParentId = x.ParentId,
                MetaDescription = x.MetaDescription,
                Keywords = x.Keywords,
                Slug = x.Slug,
               
            }).FirstOrDefault(x => x.Id == id);

        }

        public List<ProductCategoryViewModel> GetProductCategories(long parentId)
        {
            var query = _shopContext.ProductCategories;
            if (parentId != 0)
                query.Where(x => x.ParentId == parentId);

            return query.Select(x => new ProductCategoryViewModel
            {
                Id = x.Id,
                Name = x.Name,
                CreationDate = x.CreationDate.ToFarsi(),
                Picture = x.Picture,
                IsRemoved = x.IsRemoved,

            }).OrderByDescending(x => x.Id).ToList();
        }

        public string GetSlug(long id)
        {
            return _shopContext.ProductCategories.Select(x => new { x.Id, x.Slug }).FirstOrDefault(x => x.Id == id).Slug;
        }

       

        public List<ProductCategoryViewModel> Search(ProductCategorySearchModel searchModel)
        {
            var query = _shopContext.ProductCategories.Include(x => x.Parent).Select(x => new ProductCategoryViewModel
            {
                Id = x.Id,
                Name = x.Name,
                CreationDate = x.CreationDate.ToFarsi(),
                Picture = x.Picture,
                IsRemoved = x.IsRemoved,
                ParentId = x.ParentId,
                Children = MappChilren(x.Children)
            });

            if (!string.IsNullOrWhiteSpace(searchModel.Name))
                query = query.Where(x => x.Name.Contains(searchModel.Name));

            var categories = query.OrderByDescending(x => x.Id).ToList();

            return categories;
        }

        private static List<ProductCategoryViewModel> MappChilren(List<ProductCategory> children)
        {
            if (children == null)
                return new List<ProductCategoryViewModel>();
            return children.Select(x => new ProductCategoryViewModel
            {
                Id = x.Id,
                Name = x.Name,
                IsRemoved = x.IsRemoved,
                Picture = x.Picture,
                ParentId = x.ParentId,
                CreationDate = x.CreationDate.ToFarsi(),
                Children = MappChilren(x.Children)
            }).OrderByDescending(x => x.Id).ToList();
        }

        public List<ProductCategoryViewModel> GetProductCategories()
        {
            return _shopContext.ProductCategories.Where(x => !x.IsRemoved && x.ParentId == null).Select(x => new ProductCategoryViewModel
            {
                Id = x.Id,
                Name = x.Name,
                ParentId = x.ParentId,
            }).ToList();
        }
    }
}
