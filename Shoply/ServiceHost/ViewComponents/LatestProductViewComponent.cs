using _01_Shoplyquery.Contracts.Product;
using Microsoft.AspNetCore.Mvc;

namespace ServiceHost.ViewComponents
{
    public class LatestProductViewComponent:ViewComponent
    {
        private readonly IProductQuery productQuery;

        public LatestProductViewComponent(IProductQuery productQuery)
        {
            this.productQuery = productQuery;
        }

        public IViewComponentResult Invoke()
        {
            var products = productQuery.GetLatest();
            return View(products);
        }
    }
}
