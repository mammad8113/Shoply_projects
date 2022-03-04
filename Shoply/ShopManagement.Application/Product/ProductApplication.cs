using _0_Framework.Application;
using _01_framwork.Applicatin;
using ShopManagement.Application.Contracts.Product;
using ShopManagement.Domain.Product.Agg;
using ShopManagement.Domain.ProductCategory.Agg;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopManagement.Application.Producta
{
    public class ProductApplication : IProductApplication
    {
        private readonly IProductCategoryRepository productCategoryRepository;
        private readonly IProductRepository productRepository;
        private readonly IFileUploader fileUploader;

        public ProductApplication(IProductRepository productRepository, IProductCategoryRepository productCategoryRepository, IFileUploader fileUploader)
        {
            this.productRepository = productRepository;
            this.productCategoryRepository = productCategoryRepository;
            this.fileUploader = fileUploader;
        }

        public OperationResult Activate(long id)
        {
            OperationResult result = new OperationResult();
            var product = productRepository.Get(id);
            if (product == null)
                return result.Faild(ApplicationMessage.NullMessage);

            product.Activate();
            productRepository.Save();
            return result.Success();
        }

        public OperationResult Create(CreateProduct command)
        {
            OperationResult result = new OperationResult();

            if (productRepository.Exist(x => x.Name == command.Name))
                return result.Faild(ApplicationMessage.DoblicatedMessage);

            var slug = command.Slug.Slugify();
            var category = productCategoryRepository.GetSlug(command.ProductCategoryId);
            var path = $"{category}/{command.Slug}";
            var picture = fileUploader.Upload(command.Picture, path);
            var product = new Product(command.Name, command.Code, command.Description, command.ShortDescription, picture, command.PictureAlt,
                command.PictureTitle, slug, command.MetaDescription, command.KeyWords, command.ProductCategoryId);
            productRepository.Create(product);
            productRepository.Save();
            return result.Success();
        }

        public OperationResult Edit(EditProduct command)
        {
            OperationResult result = new OperationResult();
            var product = productRepository.GetProductWithCategory(command.Id);
            if (product == null)
                return result.Faild(ApplicationMessage.NullMessage);

            if (productRepository.Exist(x => x.Name == command.Name && x.Id != command.Id))
                return result.Faild(ApplicationMessage.DoblicatedMessage);


            var slug = command.Slug.Slugify();
         
            var path = $"{product.ProductCategory.Slug}/{command.Slug}";
            var picture = fileUploader.Upload(command.Picture, path);

            product.Edit(command.Name, command.Code, command.Description, command.ShortDescription, picture, command.PictureAlt,
               command.PictureTitle, slug, command.MetaDescription, command.KeyWords, command.ProductCategoryId);

            productRepository.Save();
            return result.Success();
        }

        public EditProduct GetDetals(long id)
        {
            return productRepository.GetDetals(id);
        }

        public List<ProductViewModel> GetProducts()
        {
            return productRepository.GetProducts();
        }


        public OperationResult Remove(long id)
        {
            OperationResult result = new OperationResult();
            var product = productRepository.Get(id);
            if (product == null)
                return result.Faild(ApplicationMessage.NullMessage);

            product.Remove();
            productRepository.Save();
            return result.Success();
        }

        public List<ProductViewModel> Search(ProductSearchModel searchModel)
        {
            return productRepository.Search(searchModel);
        }
    }
}
