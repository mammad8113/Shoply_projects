using ShopManagement.Application.Contracts.Order;
using ShopManagement.Domain.Order;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01_Shoplyquery.Contracts.Product
{
    public interface IProductQuery
    {
        List<ProductQueryModel> Search(string search);
        List<ProductQueryModel> GetLatest();
        ProductQueryModel GetDetals(string slug);
        List<CartItem> CheckInstock(List<CartItem> cartItems);
    }
}
