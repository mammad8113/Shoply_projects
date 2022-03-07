using _0_Framework.Application;
using _01_Shoplyquery.Contracts.Product;
using DiscountManagement.Infrastructure;
using InventoryManagement.Infrastructure;
using Microsoft.EntityFrameworkCore;
using ShopManagement.Domain.Comment.Agg;
using ShopManagement.Domain.ProductPicture.Agg;
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

        public ProductQueryModel GetDetals(string slug)
        {
            var Inventory = inventoryContext.Inventories.Select(x => new { x.ProductId, x.UnitPrice, x.InStock }).ToList();

            var Discount = discountContext.CustomerDiscounts.Where(x => x.StartDiscount < DateTime.Now && x.EndDiscount > DateTime.Now).
                Select(x => new { x.ProductId, x.Discount, x.EndDiscount }).ToList();

            var product = shopContext.Products.Where(x => !x.IsRemoved).Include(x => x.ProductCategory)
                .Include(x => x.ProductPictures)
                .Include(x=>x.Comments)
                .Select(x => new ProductQueryModel
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
                    Description = x.Description,
                    MetaDescription = x.MetaDescription,
                    Code = x.Code,
                    KeyWords = x.KeyWords,
                    IsRemoved = x.IsRemoved,
                    Pictures = MapPictures(x.ProductPictures),
                    Comments = MapComments(x.Comments),
                }).FirstOrDefault(x => x.Slug == slug);

            var productInventory = Inventory.FirstOrDefault(x => x.ProductId == product.Id);
            if (productInventory != null)
            {
                var price = productInventory.UnitPrice;
                product.Price = price.ToMoney();
                product.InStock = productInventory.InStock;

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
            return product;
        }

        private static List<CommentQueryModel> MapComments(List<Comment> comments)
        {
            return comments.Where(x => x.IsConfirm && !x.IsCanceld).Select(x => new CommentQueryModel
            {
                Id = x.Id,
                Name = x.Name,
                Message = x.Message,
                Email = x.Email,
            }).OrderByDescending(x=>x.Id).ToList();
        }

        private static List<ProductPictureQueryModel> MapPictures(List<ProductPicture> productPictures)
        {
            return productPictures.Where(x => !x.IsRemoved).Select(x => new ProductPictureQueryModel
            {
                Picture = x.Picture,
                ProductId = x.ProductId,
                IsRemoved = x.IsRemoved,
                PictureAlt = x.PictureAlt,
                PictureTitle = x.PictureTitle,
            }).ToList();
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
                CategorySlug = x.ProductCategory.Slug,
                ShortDescription = x.ShortDescription,
                Description = x.Description,
                MetaDescription = x.MetaDescription,
                Code = x.Code,
                KeyWords = x.KeyWords,
                IsRemoved = x.IsRemoved,
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
