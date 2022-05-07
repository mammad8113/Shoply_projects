using _01_framwork.Applicatin;
using BlogManagement.Application.Contracts.ArticleCategory;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using ShopManagement.Application.Contracts.Product;
using ShopManagement.Application.Contracts.ProductCategory;
using ShopManagement.Application.ProductCategorys;
using System.Collections.Generic;

namespace ServiceHost.Areas.administration.Pages.Blog.ArticleCategory
{
    public class IndexModel : PageModel
    {
        private readonly IArticleCategoryApplication articleCategoryApplication;

        public IndexModel(IArticleCategoryApplication articleCategoryApplication)
        {
            this.articleCategoryApplication = articleCategoryApplication;
        }
        public List<ArticleCategoryViewModel> ArticleCategories { get; set; }
        public ArticleCategorySearchModel SearchModel { get; set; }



        public void OnGet(ArticleCategorySearchModel searchModel)
        {
            ArticleCategories = articleCategoryApplication.Search(searchModel);
        }
        public IActionResult OnGetCreate()
        {
            var command = new CreateArticleCategory();
            return Partial("./Create", command);
        }
        public JsonResult OnPostCreate(CreateArticleCategory command)
        {
            if (ModelState.IsValid)
            {
                var result = articleCategoryApplication.Create(command);
                return new JsonResult(result);
            }
            var operation = new OperationResult();
            operation = operation.Faild("لطفا مقادیر را به درستی وارد نمایید");
            return new JsonResult(operation);
        }
        public IActionResult OnGetEdit(int id)
        {
            var articleCategory = articleCategoryApplication.GetDetals(id);
            return Partial("./Edit", articleCategory);
        }

        public JsonResult OnPostEdit(EditArticleCategory command)
        {
            var result = articleCategoryApplication.Edit(command);
            return new JsonResult(result);
        }
        public IActionResult OnGetRemove(long id)
        {
            var result = articleCategoryApplication.Remove(id);
            return RedirectToPage("./Index");
        }
        public IActionResult OnGetActivate(long id)
        {
            var result = articleCategoryApplication.Activate(id);
            return RedirectToPage("./Index");

        }
    }
}
