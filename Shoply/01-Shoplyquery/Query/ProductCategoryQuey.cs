﻿using _0_Framework.Application;
using _01_framwork.Applicatin;
using _01_framwork.Infrastructure;
using _01_Shoplyquery.Contracts.Product;
using _01_Shoplyquery.Contracts.ProductCategory;
using CommentManagement.Infrastructure.EfCore;
using DiscountManagement.Infrastructure;
using InventoryManagement.Infrastructure;
using Microsoft.EntityFrameworkCore;
using ShopManagement.Domain.Product.Agg;
using ShopManagement.Domain.ProductCategory;
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
        private readonly InventoryContext inventoryContext;
        private readonly DiscountContext discountContext;
        private readonly CommentContext commentContext;
        private readonly ShopContext shopContext;
        private readonly IAuthHelper authHelper;
        public static List<ProductQueryModel> Products { get; set; }
        public static List<Breadcrumb> parents { get; set; }
        public ProductCategoryQuey(ShopContext shopContext, InventoryContext inventoryContext, DiscountContext discountContext,
          CommentContext commentContext, IAuthHelper authHelper)
        {
            this.inventoryContext = inventoryContext;
            this.discountContext = discountContext;
            this.commentContext = commentContext;
            this.shopContext = shopContext;
            this.authHelper = authHelper;

            Products = new List<ProductQueryModel>();
            parents = new List<Breadcrumb>();
        }

        public List<ProductCategoryQueryModel> GetAll()
        {
            return shopContext.ProductCategories.Where(x => !x.IsRemoved).Include(x => x.Parent).Select(x => new ProductCategoryQueryModel
            {
                Id = x.Id,
                Picture = x.Picture,
                Name = x.Name,
                PictureAlt = x.PictureAlt,
                PictureTitle = x.PictureTitle,
                Description = x.Description,
                IsRemoved = x.IsRemoved,
                MetaDescription = x.MetaDescription,
                Keywords = x.Keywords,
                Slug = x.Slug,
                ParentId = x.ParentId,
                Parent = x.Parent.Name,
                Children = MappChildren(x.Children)
            }).OrderByDescending(x => x.Id).ToList();
        }

        public List<ProductCategoryQueryModel> GetCategoriesOverriding()
        {

            return shopContext.ProductCategories.Where(x => x.ParentId == null && !x.IsRemoved).Select(x => new ProductCategoryQueryModel
            {
                Id = x.Id,
                Picture = x.Picture,
                Name = x.Name,
                PictureAlt = x.PictureAlt,
                PictureTitle = x.PictureTitle,
                Description = x.Description,
                IsRemoved = x.IsRemoved,
                MetaDescription = x.MetaDescription,
                Keywords = x.Keywords,
                Slug = x.Slug,
                ParentId = x.ParentId,
                Parent = x.Parent.Name,

            }).OrderByDescending(x => x.Id).ToList();
        }

        private static List<ProductCategoryQueryModel> MappChildren(List<ProductCategory> children)
        {
            if (children == null || children.Count <= 0)
                return new List<ProductCategoryQueryModel>();

            return children.Select(x => new ProductCategoryQueryModel
            {
                Id = x.Id,
                Picture = x.Picture,
                Name = x.Name,
                PictureAlt = x.PictureAlt,
                PictureTitle = x.PictureTitle,
                Description = x.Description,
                IsRemoved = x.IsRemoved,
                MetaDescription = x.MetaDescription,
                Keywords = x.Keywords,
                Slug = x.Slug,
                ParentId = x.ParentId,
                Children = MappChildren(x.Children)
            }).OrderByDescending(x => x.Id).ToList();
        }
        public List<ProductQueryModel> getProducts(ProductCategoryQueryModel category)
        {
            if (category != null && category.Children.Any() && category.Children.Count > 0)
            {
                foreach (var children in category.Children.Where(x => !x.IsRemoved))
                {
                    var c = shopContext.ProductCategories.Include(x => x.Products).ThenInclude(x => x.ProductCategory)
                    .Select(x => new ProductCategoryQueryModel
                    {
                        Id = x.Id,
                        Slug = x.Slug,
                        Keywords = x.Keywords,
                        Children = MappChildren(x.Children),
                        Products = MapProduct(x.Products)
                    }).FirstOrDefault(x => x.Id == children.Id);
                    if (c.Products.Any())
                    {
                        Products.AddRange(c.Products);
                    }
                    if (c.Children != null && c.Children.Any() && c.Children.Count >= 0)
                    {
                        getProducts(c);
                    }
                }
                return Products;
            }
            return new List<ProductQueryModel>();
        }
        public List<ProductCategoryQueryModel> GetProductCategoryWithProducts()
        {
            var inventory = inventoryContext.Inventories.Select(x => new { x.ProductId, x.UnitPrice }).ToList();
            var customerdiscount = discountContext.CustomerDiscounts
                .Where(x => x.StartDiscount < DateTime.Now && x.EndDiscount > DateTime.Now)
                .Select(x => new { x.ProductId, x.Discount, x.EndDiscount })
                .ToList();

            var ColleagueDiscounts = discountContext.ColleagueDiscounts
                .Select(x => new { x.ProductId, x.Discount })
                .ToList();

            var categories = shopContext.ProductCategories
                .Where(x => x.IsRemoved == false)
                .Where(x => x.ParentId == null)
                .Include(x => x.Products)
                .ThenInclude(x => x.ProductCategory)
                .Select(x => new ProductCategoryQueryModel
                {
                    Id = x.Id,
                    Name = x.Name,
                    Products = MapProduct(x.Products),
                    Children = MappChildren(x.Children)
                }).OrderByDescending(x => x.Id).ToList();


            foreach (var category in categories)
            {

                category.Products.AddRange(getProducts(category));


                foreach (var product in category.Products)
                {
                    var Productinventory = inventory.FirstOrDefault(x => x.ProductId == product.Id);
                    if (Productinventory != null)
                    {
                        var Price = Productinventory.UnitPrice;
                        product.Price = Price.ToMoney();
                        if (authHelper.IsAuthenticated() && authHelper.CurrentAccountRole() == Rols.Colleague)
                        {
                            var productColleagueDiscounts = ColleagueDiscounts.FirstOrDefault(x => x.ProductId == product.Id);
                            if (productColleagueDiscounts != null)
                            {
                                var discountRate = productColleagueDiscounts.Discount;
                                product.DiscountRate = discountRate;
                                product.HasDiscount = discountRate > 0;
                                var discountAmount = Math.Round((Price * discountRate) / 100);
                                product.PricewithDicount = (Price - discountAmount).ToMoney();
                                product.DoublePricewithDicount = Price - discountAmount;
                            }
                        }
                        else
                        {
                            var productcustomerDiscount = customerdiscount.FirstOrDefault(x => x.ProductId == product.Id);
                            if (productcustomerDiscount != null)
                            {
                                product.EndDate = productcustomerDiscount.EndDiscount.ToString();
                                var discountRate = productcustomerDiscount.Discount;
                                product.DiscountRate = discountRate;

                                product.HasDiscount = discountRate > 0;
                                var discountAmount = Math.Round((Price * discountRate) / 100);
                                product.PricewithDicount = (Price - discountAmount).ToMoney();
                                product.DoublePricewithDicount = Price - discountAmount;
                            }
                        }
                    }

                    product.Comments = commentContext.Comments
                        .Where(x => x.IsConfirm && !x.IsCanceld && x.Type == CommentType.Product && x.OwnerRecordId == product.Id)
                        .Select(x => new CommentQueryModel
                        {
                            Id = x.Id,
                            Rating = x.Rating,
                        }).OrderByDescending(x => x.Id).ToList();

                    product.Rating = product.Comments.Sum(x => x.Rating);
                }
            }

            return categories;
        }

        private static List<ProductQueryModel> MapProduct(List<Product> products)
        {

            return products.Where(x => !x.IsRemoved).Select(x => new ProductQueryModel
            {
                Id = x.Id,
                Name = x.Name,
                Picture = x.Picture,
                PictureAlt = x.PictureAlt,
                PictureTitle = x.PictureTitle,
                Slug = x.Slug,
                CategorySlug = x.ProductCategory.Slug,
                Category = x.ProductCategory.Name,
                CategoryId = x.ProductCategoryId
            }).OrderByDescending(x => x.Id).ToList();
        }

        public ProductCategoryQueryModel GetProductCategoryWithProductsForPagationBy(string slug)
        {
            var inventory = inventoryContext.Inventories.Select(x => new { x.ProductId, x.UnitPrice }).ToList();
            var discount = discountContext.CustomerDiscounts.Where(x => x.StartDiscount < DateTime.Now && x.EndDiscount > DateTime.Now)
                .Select(x => new { x.ProductId, x.Discount, x.EndDiscount }).ToList();
            var category = shopContext.ProductCategories.Include(x => x.Products).ThenInclude(x => x.ProductCategory)
                .Select(x => new ProductCategoryQueryModel
                {
                    Id = x.Id,
                    Name = x.Name,
                    Slug = x.Slug,
                    Picture = x.Picture,
                    PictureAlt = x.PictureAlt,
                    PictureTitle = x.PictureTitle,
                    Description = x.Description,
                    MetaDescription = x.MetaDescription,
                    Keywords = x.Keywords,
                    Children = MappChildren(x.Children),
                    Products = MapProduct(x.Products)
                }).FirstOrDefault(x => x.Slug == slug);

            category.Products.AddRange(getProducts(category));
            foreach (var children in category.Children)
            {
                category.Products.AddRange(children.Products);
            }
            foreach (var product in category.Products)
            {
                var productInventory = inventory.FirstOrDefault(x => x.ProductId == product.Id);
                if (productInventory != null)
                {
                    var Price = productInventory.UnitPrice;
                    product.Price = Price.ToMoney();

                    var productDiscount = discount.FirstOrDefault(x => x.ProductId == product.Id);
                    if (productDiscount != null)
                    {
                        product.EndDate = productDiscount.EndDiscount.ToString();

                        int discountrate = productDiscount.Discount;
                        product.DiscountRate = discountrate;
                        product.HasDiscount = discountrate > 0;

                        var discountAmount = Math.Round((Price * discountrate) / 100);
                        product.PricewithDicount = (Price - discountAmount).ToMoney();
                    }
                }
            }

            return category;
        }

        public int Count(string slug)
        {
            var quey = shopContext.Products.Where(x => !x.IsRemoved);
            if (!string.IsNullOrWhiteSpace(slug))
                quey = quey.Include(x => x.ProductCategory).Where(x => x.ProductCategory.Slug == slug);

            return quey.Count();
        }

        public List<Breadcrumb> GetParent(long? id)
        {
            var category = shopContext.ProductCategories.Where(x => !x.IsRemoved).Select(x => new { x.Id, x.Name, x.Slug })
            .FirstOrDefault(x => x.Id == id);
            var Parent = shopContext.ProductCategories.Where(x => !x.IsRemoved).Include(x => x.Parent).Select(x => new { x.Id, x.Parent, x.ParentId })
            .FirstOrDefault(x => x.Id == id)?.Parent;

            if (Parent != null)
            {
                parents.Add(new Breadcrumb(Parent.Name, Parent.Id, Parent.Slug));
                if (Parent.ParentId >= 0)
                {
                    GetParent(Parent.Id);
                }
            }
            return parents.OrderBy(x => x.Id).ToList();

        }

        public List<ProductCategoryQueryModel> GetChildren(long id)
        {
            return shopContext.ProductCategories.Where(x => x.ParentId == id && !x.IsRemoved).Include(x => x.Parent).Select(x => new ProductCategoryQueryModel
            {
                Id = x.Id,
                Name = x.Name,
                ParentId = x.ParentId,
                Parent = x.Parent.Name,
                Children = MappChildren(x.Children)
            }).ToList();
        }

        public ProductCategoryQueryModel GetCategory(long id)
        {
            return shopContext.ProductCategories.Include(x => x.Parent).Select(x => new ProductCategoryQueryModel
            {
                Id = x.Id,
                Name = x.Name,
                ParentId = x.ParentId,
                Parent = x.Parent.Name,
            }).FirstOrDefault(x => x.Id == id);
        }

        public ProductCategoryQueryModel GetCategoryName(long? id)
        {
            return shopContext.ProductCategories.Select(x => new ProductCategoryQueryModel
            {
                Id = x.Id,
                Name = x.Name,
            }).FirstOrDefault(x => x.Id == id);
        }
    }
}
