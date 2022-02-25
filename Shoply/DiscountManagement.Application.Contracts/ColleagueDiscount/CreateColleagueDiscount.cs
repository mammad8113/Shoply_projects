using _01_framwork.Applicatin;
using ShopManagement.Application.Contracts.Product;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiscountManagement.Application.Contracts.ColleagueDiscount
{
    public class CreateColleagueDiscount
    {
        [Range(1, 1000, ErrorMessage = VallidationMessage.Message)]
        public long ProductId { get; set; }
        [Range(1, 100, ErrorMessage = "مقدار تخفیف بین 1 تا 100 است")]
        public int Discount { get; set; }
        public List<ProductViewModel> Products { get; set; }
    }
}
