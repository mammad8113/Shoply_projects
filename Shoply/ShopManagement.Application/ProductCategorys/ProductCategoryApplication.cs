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
        private readonly IFileUploader fileUploader;
        public ProductCategoryApplication(IProductCategoryRepository productCategoryRepository, IValidationProducatCategory validation, IFileUploader fileUploader)
        {
            this.productCategoryRepository = productCategoryRepository;
            this.validation = validation;
            this.fileUploader = fileUploader;
        }

        public void Activate(long id)
        {
            var category = productCategoryRepository.Get(id);
            category.Activate();
            productCategoryRepository.Save();
        }

        public OperationResult Create(CreateProductCategory command)
        {
            var operation = new OperationResult();
            try
            {
                var slug = command.Slug.Slugify();
                var picturePath = command.Slug;
                var picture = fileUploader.Upload(command.Picture, picturePath);
                ProductCategory productCategory = new ProductCategory(command.Name, command.Description, picture,
                     command.PictureAlt, command.PictureTitle, command.Keywords, command.MetaDescription, slug, validation,command.ParentId);
            
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
            string pathPicture = command.Slug;
            var picture = fileUploader.Upload(command.Picture, pathPicture);
            var operation = productCategory.Edit(command.Name, command.Description, picture, command.PictureAlt,
                   command.PictureTitle, command.Keywords, command.MetaDescription, slug, validation,command.ParentId);
            productCategoryRepository.Save();
            return operation;

        }

        public EditProductCategory GetDetals(long id)
        {
            return productCategoryRepository.GetDetals(id);
        }

        public List<ProductCategoryViewModel> GetProductCategories(long id)
        {
            return productCategoryRepository.GetProductCategories(id);
        }

        public List<ProductCategoryViewModel> GetProductCategories()
        {
            return productCategoryRepository.GetProductCategories();
        }

        public void Removed(long id)
        {
            var category = productCategoryRepository.Get(id);
            category.Remove();
            productCategoryRepository.Save();
        }

        public List<ProductCategoryViewModel> Search(ProductCategorySearchModel search)
        {
            return productCategoryRepository.Search(search);
        }
    }
}
