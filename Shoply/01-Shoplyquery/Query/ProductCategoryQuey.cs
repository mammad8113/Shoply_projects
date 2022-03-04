using _0_Framework.Application;
using _01_Shoplyquery.Contracts.Product;
using _01_Shoplyquery.Contracts.ProductCategory;
using DiscountManagement.Infrastructure;
using InventoryManagement.Infrastructure;
using Microsoft.EntityFrameworkCore;
using ShopManagement.Domain.Product.Agg;
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

        public ProductCategoryQuey(ShopContext shopContext, InventoryContext inventoryContext, DiscountContext discountContext)
        {
            this.shopContext = shopContext;
            this.inventoryContext = inventoryContext;
            this.discountContext = discountContext;
        }

        public List<ProductCategoryQueryModel> GetAll()
        {
            return shopContext.ProductCategories.Where(x => x.IsRemoved == false).Select(x => new ProductCategoryQueryModel
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
            }).OrderByDescending(x => x.Id).ToList();
        }

        public List<ProductCategoryQueryModel> GetProductCategoryWithProducts()
        {
            var inventory = inventoryContext.Inventories.Select(x => new { x.ProductId, x.UnitPrice }).ToList();
            var discount = discountContext.CustomerDiscounts.Where(x => x.StartDiscount < DateTime.Now && x.EndDiscount > DateTime.Now)
                .Select(x => new { x.ProductId, x.Discount }).ToList();
            var categories = shopContext.ProductCategories.Where(x => x.IsRemoved == false)
                .Include(x => x.Products).ThenInclude(x => x.ProductCategory).Select(x => new ProductCategoryQueryModel
                {
                    Id = x.Id,
                    Name = x.Name,
                    Products = MapProduct(x.Products)

                }).OrderByDescending(x => x.Id).ToList();

            foreach (var category in categories)
            {
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

            return products.Select(x => new ProductQueryModel
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

        public ProductCategoryQueryModel GetProductCategoryWithProductsForPagationBy(string slug, int page, int number = 1)
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

                    Products = MapProduct(x.Products)
                }).FirstOrDefault(x => x.Slug == slug);


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

            if (page != 0 && page != 1)
            {
                category.Products = category.Products.Skip((page - 1) * number).Take(number).ToList();
            }
            else
            {
                category.Products = category.Products.Take(number).ToList();
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
    }
}
