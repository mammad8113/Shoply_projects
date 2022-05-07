using _01_framwork.Applicatin;
using ShopManagement.Application.Contracts.ProductPicture;
using ShopManagement.Domain.Product.Agg;
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
        private readonly IProductRepository productRepository;
        private readonly IFileUploader fileUploader;
        public ProductPictureApplication(IProductPictureRepository productPictureRepository, IFileUploader fileUploader, IProductRepository productRepository)
        {
            this.productPictureRepository = productPictureRepository;
            this.productRepository = productRepository;
            this.fileUploader = fileUploader;
        }

        public OperationResult Activate(long id)
        {
            var result = new OperationResult();
            var picture = productPictureRepository.Get(id);
            if (picture == null)
                return result.Faild(ApplicationMessage.NullMessage);

            picture.Activate();
            try
            {
                productPictureRepository.Save();

            }
            catch
            {
                return result.Faild(ApplicationMessage.UnspecifiedError);
            }
            return result.Success();
        }

        public OperationResult Create(CreateProductPicture command)
        {
            var result = new OperationResult();

            var product = productRepository.GetProductWithCategory(command.ProductId);
            var path = $"{product.ProductCategory.Slug}/{product.Slug}";
            var picture = fileUploader.Upload(command.Picture, path);

            var productPicture = new ProductPicture(picture, command.PictureAlt, command.PictureTitle, command.ProductId);

            productPictureRepository.Create(productPicture);
            productPictureRepository.Save();
            return result.Success();
        }

        public OperationResult Edit(EditProductPicture command)
        {
            var result = new OperationResult();
            var productPicture = productPictureRepository.Get(command.Id);
            var product = productRepository.GetProductWithCategory(command.ProductId);
            var path = $"{product.ProductCategory.Slug}/{product.Slug}";
            var picture = fileUploader.Upload(command.Picture, path);

            productPicture.Edit(picture, command.PictureAlt, command.PictureTitle, command.ProductId);
            try
            {
                productPictureRepository.Save();
            }
            catch
            {
                return result.Faild(ApplicationMessage.NullFildMessage);
            }
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
            try
            {
                productPictureRepository.Save();
            }
            catch
            {
                return result.Faild(ApplicationMessage.UnspecifiedError);
            }
            return result.Success();
        }

        public List<ProductPictureViewModel> Search(ProductPictureSearchModel searchModel)
        {
            return productPictureRepository.Search(searchModel);
        }
    }
}
