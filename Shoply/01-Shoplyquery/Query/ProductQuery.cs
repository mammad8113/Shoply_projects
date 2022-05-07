using _0_Framework.Application;
using _01_framwork.Applicatin;
using _01_framwork.Infrastructure;
using _01_Shoplyquery.Contracts.Product;
using _01_Shoplyquery.Contracts.ProductCategory;
using CommentManagement.Infrastructure.EfCore;
using DiscountManagement.Infrastructure;
using InventoryManagement.Infrastructure;
using Microsoft.EntityFrameworkCore;
using ShopManagement.Application.Contracts.Order;
using ShopManagement.Domain.Order;
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
        private readonly InventoryContext inventoryContext;
        private readonly DiscountContext discountContext;
        private readonly CommentContext commentContext;
        private readonly ShopContext shopContext;
        private readonly IAuthHelper authHelper;
        public ProductQuery(InventoryContext inventoryContext, ShopContext shopContext, DiscountContext discountContext
            , CommentContext commentContext, IAuthHelper authHelper)
        {
            this.inventoryContext = inventoryContext;
            this.discountContext = discountContext;
            this.commentContext = commentContext;
            this.shopContext = shopContext;
            this.authHelper = authHelper;
        }

        public ProductQueryModel GetDetals(string slug)
        {
            var Inventory = inventoryContext.Inventories.Select(x => new { x.ProductId, x.UnitPrice, x.InStock }).ToList();

            var customerDiscount = discountContext.CustomerDiscounts.Where(x => x.StartDiscount < DateTime.Now && x.EndDiscount > DateTime.Now).
                Select(x => new { x.ProductId, x.Discount, x.EndDiscount }).ToList();

            var ColleagueDiscounts = discountContext.ColleagueDiscounts.
               Select(x => new { x.ProductId, x.Discount }).ToList();

            var product = shopContext.Products.Where(x => !x.IsRemoved).Include(x => x.ProductCategory)
                .Include(x => x.ProductPictures)
                .Select(x => new ProductQueryModel
                {
                    Id = x.Id,
                    Name = x.Name,
                    Picture = x.Picture,
                    PictureAlt = x.PictureAlt,
                    PictureTitle = x.PictureTitle,
                    Slug = x.Slug,
                    Category = x.ProductCategory.Name,
                    CategoryId = x.ProductCategoryId,
                    CategorySlug = x.ProductCategory.Slug,
                    ShortDescription = x.ShortDescription,
                    Description = x.Description,
                    MetaDescription = x.MetaDescription,
                    Code = x.Code,
                    KeyWords = x.KeyWords,
                    IsRemoved = x.IsRemoved,

                    Pictures = MapPictures(x.ProductPictures),

                }).FirstOrDefault(x => x.Slug == slug);

            var productInventory = Inventory.FirstOrDefault(x => x.ProductId == product.Id);



            if (productInventory != null)
            {
                var price = productInventory.UnitPrice;
                product.Price = price.ToMoney();
                product.DoublePrice = price;
                product.InStock = productInventory.InStock;

                if (authHelper.IsAuthenticated() && authHelper.CurrentAccountRole() == Rols.Colleague)
                {
                    var productColleagueDiscounts = ColleagueDiscounts.FirstOrDefault(x => x.ProductId == product.Id);
                    if (productColleagueDiscounts != null)
                    {
                        var discountRate = productColleagueDiscounts.Discount;
                        product.DiscountRate = discountRate;
                        product.HasDiscount = discountRate > 0;
                        var discountAmount = Math.Round((price * discountRate) / 100);
                        product.PricewithDicount = (price - discountAmount).ToMoney();
                        product.DoublePricewithDicount = price - discountAmount;
                    }
                }
                else
                {
                    var productcustomerDiscount = customerDiscount.FirstOrDefault(x => x.ProductId == product.Id);
                    if (productcustomerDiscount != null)
                    {
                        product.EndDate = productcustomerDiscount.EndDiscount.ToString();
                        var discountRate = productcustomerDiscount.Discount;
                        product.DiscountRate = discountRate;

                        product.HasDiscount = discountRate > 0;
                        var discountAmount = Math.Round((price * discountRate) / 100);
                        product.PricewithDicount = (price - discountAmount).ToMoney();
                        product.DoublePricewithDicount = price - discountAmount;
                    }
                }



            }

            product.Comments = commentContext.Comments.Where(x => x.IsConfirm && !x.IsCanceld && x.Type == CommentType.Product && x.OwnerRecordId == product.Id)
                .Select(x => new CommentQueryModel
                {
                    Id = x.Id,
                    Mobile = x.Mobile,
                    Name = x.Name,
                    Message = x.Message,
                    Rating = x.Rating,
                }).OrderByDescending(x => x.Id).ToList();

            return product;
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

            var CustomerDiscounts = discountContext.CustomerDiscounts.Where(x => x.StartDiscount < DateTime.Now && x.EndDiscount > DateTime.Now).
                Select(x => new { x.ProductId, x.Discount, x.EndDiscount }).ToList();

            var ColleagueDiscounts = discountContext.ColleagueDiscounts.
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

                    if (authHelper.IsAuthenticated() && authHelper.CurrentAccountRole() == Rols.Colleague)
                    {
                        var productColleagueDiscounts = ColleagueDiscounts.FirstOrDefault(x => x.ProductId == product.Id);
                        if (productColleagueDiscounts != null)
                        {
                            var discountRate = productColleagueDiscounts.Discount;
                            product.DiscountRate = discountRate;
                            product.HasDiscount = discountRate > 0;
                            var discountAmount = Math.Round((price * discountRate) / 100);
                            product.PricewithDicount = (price - discountAmount).ToMoney();
                            product.DoublePricewithDicount = price - discountAmount;
                        }
                    }
                    else
                    {
                        var productcustomerDiscount = CustomerDiscounts.FirstOrDefault(x => x.ProductId == product.Id);
                        if (productcustomerDiscount != null)
                        {
                            product.EndDate = productcustomerDiscount.EndDiscount.ToString();
                            var discountRate = productcustomerDiscount.Discount;
                            product.DiscountRate = discountRate;

                            product.HasDiscount = discountRate > 0;
                            var discountAmount = Math.Round((price * discountRate) / 100);
                            product.PricewithDicount = (price - discountAmount).ToMoney();
                            product.DoublePricewithDicount = price - discountAmount;
                        }
                    }
                }

                product.Comments = commentContext.Comments.Where(x => x.IsConfirm && !x.IsCanceld && x.Type == CommentType.Product && x.OwnerRecordId == product.Id)
                .Select(x => new CommentQueryModel
                {
                    Id = x.Id,
                    Rating = x.Rating,
                }).OrderByDescending(x => x.Id).ToList();
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
                KeyWords = x.KeyWords,
                KeyWordsList = MappKeyWord(x.KeyWords),
                Category = x.ProductCategory.Name,
                CategorySlug = x.ProductCategory.Slug,
                ShortDescription = x.ShortDescription,
            }).AsNoTracking();



            if (!string.IsNullOrWhiteSpace(search))
                query = query.Where(x => x.Name.Contains(search) || x.ShortDescription.Contains(search) || x.Category.Contains(search) || x.KeyWordsList.Contains(search));

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

        private List<string> MappKeyWord(string keyWord)
        {
            var KeyWords = keyWord.Split(",").ToList();

            return KeyWords;
        }

        public List<CartItem> CheckInstock(List<CartItem> cartItems)
        {
            var inventory = inventoryContext.Inventories.ToList();

            foreach (var cart in cartItems.Where(cart => inventory.Any(x => x.ProductId == cart.Id && x.InStock)))
            {
                var itemInventory = inventory.FirstOrDefault(x => x.ProductId == cart.Id);

                cart.InStock = itemInventory.CalculatorCurrentCount() >= cart.Count;
            }

            return cartItems;
        }


    }
}
