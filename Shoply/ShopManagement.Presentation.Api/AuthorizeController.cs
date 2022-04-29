using _01_framwork.Applicatin.TokenAuthorize;
using _01_Shoplyquery.Contracts.Product;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace ShopManagement.Presentation.Api
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthorizeController : ControllerBase
    {
        private readonly IProductQuery productQuery;

        private readonly ITokenManagement tokenManagement;

        public AuthorizeController(ITokenManagement tokenManagement, IProductQuery productQuery)
        {
            this.tokenManagement = tokenManagement;
            this.productQuery = productQuery;
        }


        [HttpGet("{id}")]
        public List<ProductQueryModel> GetChildren(long id)
        {
            return productQuery.GetLatest();
        }

        [HttpGet()]
        public IActionResult Authorize(string pwd)
        {
            if (tokenManagement.Authorize(pwd))
            {
                return Ok(new { token = tokenManagement.NewToken() });
            }

            ModelState.AddModelError("Unathorized", "product key is not valid");
            return Unauthorized(ModelState);
        }
    }
}
