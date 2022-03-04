using _0_Framework.Application;
using _01_Shoplyquery.Contracts.Product;
using DiscountManagement.Infrastructure;
using InventoryManagement.Infrastructure;
using Microsoft.EntityFrameworkCore;
using ShopManagement.Infrastructure.EfCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01_Shoplyquery.Contracts.Slide
{
    public class ProductQuery : IProductQuery
    {
        private readonly ShopContext shopContext;
        private readonly DiscountContext discountContext;
        private readonly InventoryContext inventoryContext;

        public ProductQuery(InventoryContext inventoryContext, ShopContext shopContext, DiscountContext discountContext)
        {
            this.inventoryContext = inventoryContext;
            this.shopContext = shopContext;
            this.discountContext = discountContext;
        }

        public List<ProductQueryModel> GetLatest()
        {
            var Inventory = inventoryContext.Inventories.Select(x => new { x.ProductId, x.UnitPrice }).ToList();

            var Discount = discountContext.CustomerDiscounts.Where(x => x.StartDiscount < DateTime.Now && x.EndDiscount > DateTime.Now).
                Select(x => new { x.ProductId, x.Discount }).ToList();

            var query = shopContext.Products.Where(x => !x.IsRemoved).Include(x => x.ProductCategory).Select(x => new ProductQueryModel
            {
                Id = x.Id,
                Name = x.Name,
                Picture = x.Picture,
                PictureAlt = x.PictureAlt,
                PictureTitle = x.PictureTitle,
                Slug = x.Slug,
                Category = x.ProductCategory.Name,
            });

            var products = query.OrderByDescending(x => x.Id).Take(10).ToList();

            foreach (var product in products)
            {
                var productInventory = Inventory.FirstOrDefault(x => x.ProductId == product.Id);
                if (productInventory != null)
                {
                    var price = productInventory.UnitPrice;
                    product.Price = price.ToMoney();

                    var productDiscount = Discount.FirstOrDefault(x => x.ProductId == product.Id);
                    if (productDiscount != null)
                    {
                        var discountRate = productDiscount.Discount;
                        product.DiscountRate = discountRate;

                        product.HasDiscount = discountRate > 0;
                        var discountAmount = Math.Round((price * discountRate) / 100);
                        product.PricewithDicount = (price - discountAmount).ToMoney();
                    }
                }
            }

            return products;

        }

        public List<ProductQueryModel> Search(string search)
        {
            var Inventory = inventoryContext.Inventories.Select(x => new { x.ProductId, x.UnitPrice }).ToList();

            var Discount = discountContext.CustomerDiscounts.Where(x => x.StartDiscount < DateTime.Now && x.EndDiscount > DateTime.Now).
                Select(x => new { x.ProductId, x.Discount, x.EndDiscount }).ToList();

            var query = shopContext.Products.Where(x => !x.IsRemoved).Include(x => x.ProductCategory).Select(x => new ProductQueryModel
            {
                Id = x.Id,
                Name = x.Name,
                Picture = x.Picture,
                PictureAlt = x.PictureAlt,
                PictureTitle = x.PictureTitle,
                Slug = x.Slug,
                Category = x.ProductCategory.Name,
                CategorySlug = x.ProductCategory.Slug,
                ShortDescription = x.ShortDescription,
            }).AsNoTracking();

            if (!string.IsNullOrWhiteSpace(search))
                query = query.Where(x => x.Name.Contains(search) || x.ShortDescription.Contains(search) || x.Category.Contains(search));

            var products = query.OrderByDescending(x => x.Id).ToList();

            foreach (var product in products)
            {
                var price = Inventory.FirstOrDefault(x => x.ProductId == product.Id).UnitPrice;
                product.Price = price.ToMoney();

                var productDiscount = Discount.FirstOrDefault(x => x.ProductId == product.Id);

                if (productDiscount != null)
                {
                    product.EndDate = productDiscount.EndDiscount.ToString();
                    var discountRate = productDiscount.Discount;
                    product.DiscountRate = discountRate;

                    product.HasDiscount = discountRate > 0;
                    var discountAmount = Math.Round((price * discountRate) / 100);
                    product.PricewithDicount = (price - discountAmount).ToMoney();
                }
            }

            return products;
        }
    }
}
