using _01_framwork.Applicatin;
using ShopManagement.Application.Contracts.Product;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiscountManagement.Application.Contracts.CustomerDiscount
{
    public class CreateCustomerDiscount
    {
        [Range(1,1000,ErrorMessage =VallidationMessage.Message)]
        public long ProductId { get; set; }
        [Range(1, 100, ErrorMessage = "مقدار تخفیف بین 1 تا 100 است")]
        public int Discount { get; set; }
        [Required(ErrorMessage =VallidationMessage.Message)]
        public string StartDiscount { get; set; }
        [Required(ErrorMessage = VallidationMessage.Message)]

        public string EndDiscount { get; set; }
        [Required(ErrorMessage = VallidationMessage.Message)]

        public string Title { get; set; }
        public List<ProductViewModel> Products { get; set; }
    }
}
