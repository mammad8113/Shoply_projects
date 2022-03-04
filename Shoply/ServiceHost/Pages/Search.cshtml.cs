using _01_Shoplyquery.Contracts.Product;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Collections.Generic;

namespace ServiceHost.Pages
{
    public class SearchModel : PageModel
    {
        public List<ProductQueryModel> Products { get; set; }
        public string Value { get; set; }
        private readonly IProductQuery productQuery;

        public SearchModel(IProductQuery productQuery)
        {
            this.productQuery = productQuery;
        }

        public void OnGet(string value)
        {
            Value = value;
            Products = productQuery.Search(value);
        }
    }
}
