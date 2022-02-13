using _01_framwork.Applicatin;
using ShopManagement.Application.Contracts.ProductPicture;
using ShopManagement.Domain.ProductPicture.Agg;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopManagement.Application.ProductPictures
{
    public class ProductPictureApplication : IProductPictureApplication
    {
        private readonly IProductPictureRepository productPictureRepository;

        public ProductPictureApplication(IProductPictureRepository productPictureRepository)
        {
            this.productPictureRepository = productPictureRepository;
        }

        public OperationResult Activate(long id)
        {
            var result = new OperationResult();
            var picture = productPictureRepository.Get(id);
            if (picture == null)
                return result.Faild(ApplicationMessage.NullMessage);

            picture.Activate();
            productPictureRepository.Save();
            return result.Success();
        }

        public OperationResult Create(CreateProductPicture command)
        {
            var result = new OperationResult();
            if (productPictureRepository.Exist(x => x.Picture == command.Picture && x.ProductId == command.ProductId))
                return result.Faild(ApplicationMessage.DoblicatedMessage);

            var productPicture = new ProductPicture(command.Picture, command.PictureAlt, command.PictureTitle, command.ProductId);

            productPictureRepository.Create(productPicture);
            productPictureRepository.Save();
            return result.Success();
        }

        public OperationResult Edit(EditProductPicture command)
        {
            var result = new OperationResult();
            var picture = productPictureRepository.Get(command.Id);
            if (picture == null)
                result.Faild(ApplicationMessage.NullMessage);

            if (productPictureRepository.Exist(x => x.Picture == command.Picture && x.ProductId == command.ProductId))
                return result.Faild(ApplicationMessage.DoblicatedMessage);

            picture.Edit(command.Picture, command.PictureAlt, command.PictureTitle, command.ProductId);
            productPictureRepository.Save();
            return result.Success();
        }

        public EditProductPicture GetDetals(long id)
        {
            return productPictureRepository.GetDetals(id);
        }

        public OperationResult Remove(long id)
        {
            var result = new OperationResult();
            var picture = productPictureRepository.Get(id);
            if (picture == null)
                return result.Faild(ApplicationMessage.NullMessage);

            picture.Remove();
            productPictureRepository.Save();
            return result.Success();
        }

        public List<ProductPictureViewModel> Search(ProductPictureSearchModel searchModel)
        {
           return productPictureRepository.Search(searchModel);
        }
    }
}
