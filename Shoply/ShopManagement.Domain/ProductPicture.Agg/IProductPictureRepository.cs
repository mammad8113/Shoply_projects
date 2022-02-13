using _01_framwork.Domain;
using ShopManagement.Application.Contracts.ProductPicture;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopManagement.Domain.ProductPicture.Agg
{
    public interface IProductPictureRepository:IRepository<long, ProductPicture>
    {
        EditProductPicture GetDetals(long id);
        List<ProductPictureViewModel> Search(ProductPictureSearchModel searchModel);
    }
}
