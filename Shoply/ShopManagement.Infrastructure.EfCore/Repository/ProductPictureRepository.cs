using _0_Framework.Application;
using _01_framwork.Infrastructure;
using Microsoft.EntityFrameworkCore;
using ShopManagement.Application.Contracts.ProductPicture;
using ShopManagement.Domain.ProductPicture.Agg;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopManagement.Infrastructure.EfCore.Repository
{
    public class ProductPictureRepository : BaseRepository<long, ProductPicture>, IProductPictureRepository
    {
        private readonly ShopContext _shopContext;

        public ProductPictureRepository(ShopContext shopContext) : base(shopContext)
        {
            _shopContext = shopContext;
        }

        public EditProductPicture GetDetals(long id)
        {
            return _shopContext.ProductPictures.Include(x => x.Product).Select(x => new EditProductPicture
            {
                Id = id,
                //Picture = x.Picture,
                PictureAlt = x.PictureAlt,
                PictureTitle =x.PictureTitle,
                ProductId = x.ProductId,
               
            }).FirstOrDefault(x => x.Id == id);
        }

        public List<ProductPictureViewModel> Search(ProductPictureSearchModel searchModel)
        {
            var query = _shopContext.ProductPictures.Include(x=>x.Product).Select(x => new ProductPictureViewModel
            {
                Id=x.Id,
                Picture=x.Picture,
                IsRemoved=x.IsRemoved,
                Product=x.Product.Name,
                ProductId=x.ProductId,
               CreationDate=x.CreationDate.ToFarsi()
            });

            if(searchModel.ProductId != 0)
               query=query.Where(x=>x.ProductId==searchModel.ProductId);

            return query.OrderByDescending(x => x.Id).ToList(); 

        }
    }
}
