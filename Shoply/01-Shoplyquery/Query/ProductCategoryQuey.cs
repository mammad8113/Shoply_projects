using _0_Framework.Application;
using _01_Shoplyquery.Contracts.Product;
using _01_Shoplyquery.Contracts.ProductCategory;
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
        private readonly ShopContext shopContext;
        private readonly InventoryContext inventoryContext;
        private readonly DiscountContext discountContext;
        public static List<Breadcrumb> parents { get; set; }
        public static List<ProductQueryModel> Products { get; set; }
        public ProductCategoryQuey(ShopContext shopContext, InventoryContext inventoryContext, DiscountContext discountContext)
        {
            this.shopContext = shopContext;
            this.inventoryContext = inventoryContext;
            this.discountContext = discountContext;
            parents = new List<Breadcrumb>();
            Products = new List<ProductQueryModel>();
        }

        public List<ProductCategoryQueryModel> GetAll()
        {
            return shopContext.ProductCategories.Include(x => x.Parent).Select(x => new ProductCategoryQueryModel
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
            return shopContext.ProductCategories.Include(x => x.Parent).Where(x => x.ParentId == null).Select(x => new ProductCategoryQueryModel
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
            if (category != null && category.Children.Any())
            {
                foreach (var children in category.Children)
                {
                    var c = shopContext.ProductCategories.Include(x => x.Products).ThenInclude(x => x.ProductCategory)
                    .Select(x => new ProductCategoryQueryModel
                    {
                        Id = x.Id,
                        Slug = x.Slug,
                        Keywords = x.Keywords,
                        Children = MappChildren(x.Children),
                        Products = MapProduct(x.Products)
                    }).FirstOrDefault(x => x.Slug == children.Slug);
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
            var discount = discountContext.CustomerDiscounts.Where(x => x.StartDiscount < DateTime.Now && x.EndDiscount > DateTime.Now)
                .Select(x => new { x.ProductId, x.Discount }).ToList();
            var categories = shopContext.ProductCategories.Where(x => x.IsRemoved == false)
                .Include(x => x.Products).ThenInclude(x => x.ProductCategory).Where(x=>x.ParentId==null).Select(x => new ProductCategoryQueryModel
                {
                    Id = x.Id,
                    Name = x.Name,
                    Products = MapProduct(x.Products),
                    Children = MappChildren(x.Children)

                }).OrderByDescending(x => x.Id).ToList();


            foreach (var category in categories)
            {

                category.Products.AddRange(getProducts(category));
                foreach (var children in category.Children)
                {
                    category.Products.AddRange(children.Products);

                }

                foreach (var product in category.Products)
                {
                    var Productinventory = inventory.FirstOrDefault(x => x.ProductId == product.Id);
                    if (Productinventory != null)
                    {
                        var Price = Productinventory.UnitPrice;
                        product.Price = Price.ToMoney();
                        var productDiscount = discount.FirstOrDefault(x => x.ProductId == product.Id);
                        if (productDiscount != null)
                        {
                            int discountrate = productDiscount.Discount;
                            product.DiscountRate = discountrate;
                            product.HasDiscount = discountrate > 0;
                            var discountAmount = Math.Round((Price * discountrate) / 100);
                            product.PricewithDicount = (Price - discountAmount).ToMoney();
                        }
                    }

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
                Category = x.ProductCategory.Name,
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

        public int Count(string? slug)
        {
            var quey = shopContext.Products.Where(x => !x.IsRemoved);
            if (!string.IsNullOrWhiteSpace(slug))
                quey = quey.Include(x => x.ProductCategory).Where(x => x.ProductCategory.Slug == slug);

            return quey.Count();
        }

        public List<Breadcrumb> GetParent(long? id)
        {
            var category = shopContext.ProductCategories.Where(x => !x.IsRemoved).Include(x => x.Parent).Select(x => new { x.Id, x.Parent, x.ParentId })
            .FirstOrDefault(x => x.Id == id)?.Parent;

            if (category != null)
            {
                parents.Add(new Breadcrumb(category.Name, category.Id, category.Slug));
                if (category.ParentId >= 0)
                {
                    GetParent(category.Id);
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
    }
}
