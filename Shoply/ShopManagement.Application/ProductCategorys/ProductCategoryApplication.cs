using _0_Framework.Application;
using _01_framwork.Applicatin;
using ShopManagement.Application.Contracts.ProductCategory;
using ShopManagement.Domain.ProductCategory;
using ShopManagement.Domain.ProductCategory.Agg;
using ShopManagement.Domain.ProductCategory.Agg.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopManagement.Application.ProductCategorys
{
    public class ProductCategoryApplication : IProductCategoryApplication
    {
        private readonly IProductCategoryRepository productCategoryRepository;
        private readonly IValidationProducatCategory validation;
        public ProductCategoryApplication(IProductCategoryRepository productCategoryRepository, IValidationProducatCategory validation)
        {
            this.productCategoryRepository = productCategoryRepository;
            this.validation = validation;
        }

        public OperationResult Create(CreateProductCategory command)
        {
            var operation = new OperationResult();
            try
            {
                var slug = command.Slug.Slugify();
                ProductCategory productCategory = new ProductCategory(command.Name, command.Description,command.Picture,
                     command.PictureAlt, command.PictureTitle, command.Keywords, command.MetaDescription, slug, validation);
                productCategoryRepository.Create(productCategory);
                productCategoryRepository.Save();
                return operation.Success();
            }
            catch (Exception e)
            {
                return operation.Faild(e.Message);
            }

        }

        public OperationResult Edit(EditProductCategory command)
        {

            var productCategory = productCategoryRepository.Get(command.Id);
            var slug = command.Slug.Slugify();
            var operation = productCategory.Edit(command.Name, command.Description, command.Picture, command.PictureAlt,
                   command.PictureTitle, command.Keywords, command.MetaDescription, slug, validation);
            productCategoryRepository.Save();
            return operation;

        }

        public EditProductCategory GetDetals(int id)
        {
            return productCategoryRepository.GetDetals(id);
        }

        public List<ProductCategoryViewModel> Search(ProductCategorySearchModel search)
        {
            return productCategoryRepository.Search(search);
        }
    }
}
