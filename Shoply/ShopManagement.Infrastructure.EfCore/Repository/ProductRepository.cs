﻿using _0_Framework.Application;
using _01_framwork.Infrastructure;
using Microsoft.EntityFrameworkCore;
using ShopManagement.Application.Contracts.Product;
using ShopManagement.Domain.Product.Agg;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopManagement.Infrastructure.EfCore.Repository
{
    public class ProductRepository : BaseRepository<long, Product>, IProductRepository
    {
        public static List<long> parentsId { get; set; }

        private readonly ShopContext _shopContext;

        public ProductRepository(ShopContext shopContext) : base(shopContext)
        {
            _shopContext = shopContext;
            parentsId = new List<long>();
        }

        public EditProduct GetDetals(long id)
        {
            return _shopContext.Products.Select(x => new EditProduct
            {
                Id = x.Id,
                Name = x.Name,
                Code = x.Code,
                //Picture = x.Picture,
                PictureAlt = x.PictureAlt,
                PictureTitle = x.PictureTitle,
                ShortDescription = x.ShortDescription,
                Slug = x.Slug,
                MetaDescription = x.MetaDescription,
                KeyWords = x.KeyWords,
                Description = x.Description,
                ProductCategoryId = x.ProductCategoryId

            }).FirstOrDefault(x => x.Id == id);
        }
        public List<long> GetParent(long id)
        {
            var categories = _shopContext.ProductCategories.Where(x => !x.IsRemoved).Include(x => x.Parent).Select(x => new { x.Id, x.Parent, x.ParentId,x.Children })
            .FirstOrDefault(x => x.Id == id)?.Children;

            parentsId.Add(id);
            if (categories != null&& categories.Any())
            {
                foreach (var category in categories)
                {
                    parentsId.Add(category.Id);

                        GetParent(category.Id);
                }
            }
            return parentsId;
        }

        public List<ProductViewModel> Search(CategorySearchModel searchModel)
        {
            var query = _shopContext.Products.Include(x => x.ProductCategory).Select(x => new ProductViewModel
            {
                Id = x.Id,
                Name = x.Name,
                Picture = x.Picture,
                ShortDescription = x.ShortDescription,
                Code = x.Code,
                IsRemove = x.IsRemoved,
                CreationDate = x.CreationDate.ToFarsi(),
                ProductCategory = x.ProductCategory.Name,
                ProductCategoryId = x.ProductCategoryId,

            });

            if (!string.IsNullOrWhiteSpace(searchModel.Name))
                query = query.Where(x => x.Name.Contains(searchModel.Name));

            if (!string.IsNullOrWhiteSpace(searchModel.Code))
                query = query.Where(x => x.Code.Contains(searchModel.Code));

            if (searchModel.ProductCategoryId != 0)
            {
                var parentsid=GetParent(searchModel.ProductCategoryId);
                query = query.Where(x =>parentsId.Contains(x.ProductCategoryId));
            }
            return query.OrderByDescending(x => x.Id).ToList();
        }
        public List<ProductViewModel> GetProducts()
        {
            return _shopContext.Products.Select(x => new ProductViewModel
            {
                Id = x.Id,
                Name = x.Name,
            }).OrderByDescending(x => x.Id).ToList();
        }

        public string GetSlug(long id)
        {
            return _shopContext.Products.Select(x => new { x.Slug, x.Id }).FirstOrDefault(x => x.Id == id).Slug;
        }

        public Product GetProductWithCategory(long id)
        {
            return _shopContext.Products.Include(x => x.ProductCategory).FirstOrDefault(x => x.Id == id);
        }
    }
}
