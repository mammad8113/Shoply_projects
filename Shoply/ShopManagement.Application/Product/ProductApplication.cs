using _0_Framework.Application;
using _01_framwork.Applicatin;
using ShopManagement.Application.Contracts.Product;
using ShopManagement.Domain.Product.Agg;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopManagement.Application.Producta
{
    public class ProductApplication : IProductApplication
    {
        private readonly IProductRepository productRepository;

        public ProductApplication(IProductRepository productRepository)
        {
            this.productRepository = productRepository;
        }

        public OperationResult Create(CreateProduct command)
        {
            OperationResult result = new OperationResult();

            if (productRepository.Exist(x => x.Name == command.Name))
                return result.Faild(ApplicationMessage.DoblicatedMessage);

            var slug = command.Slug.Slugify();
            var product = new Product(command.Name, command.Code, command.Description, command.ShortDescription, command.Picture, command.PictureAlt,
                command.PictureTitle, command.Price, slug, command.MetaDescription, command.KeyWords, command.ProductCategoryId);
            productRepository.Create(product);
            productRepository.Save();
            return result.Success();
        }

        public OperationResult Edit(EditProduct command)
        {
            OperationResult result = new OperationResult();
            var product = productRepository.Get(command.Id);
            if (product == null)
                return result.Faild(ApplicationMessage.NullMessage);

            if (productRepository.Exist(x => x.Name == command.Name && x.Id != command.Id))
                return result.Faild(ApplicationMessage.DoblicatedMessage);


            var slug = command.Slug.Slugify();
            product.Edit(command.Name, command.Code, command.Description, command.ShortDescription, command.Picture, command.PictureAlt,
               command.PictureTitle, command.Price, slug, command.MetaDescription, command.KeyWords, command.ProductCategoryId);

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

        public OperationResult InStock(long id)
        {
            OperationResult result = new OperationResult();
            var product = productRepository.Get(id);
            if (product == null)
                return result.Faild(ApplicationMessage.NullMessage);

            product.InStock();
            productRepository.Save();
            return result.Success();
        }

        public OperationResult NotInStock(long id)
        {
            OperationResult result = new OperationResult();
            var product = productRepository.Get(id);
            if (product == null)
                return result.Faild(ApplicationMessage.NullMessage);

            product.NotInStock();
            productRepository.Save();
            return result.Success();
        }

        public List<ProductViewModel> Search(ProductSearchModel searchModel)
        {
           return productRepository.Search(searchModel);
        }
    }
}
