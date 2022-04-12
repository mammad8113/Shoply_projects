using _01_framwork.Applicatin;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ServiceHost.Pages
{
    public class PaymentResultModel : PageModel
    {
        public PayResult Result { get; set; }
        public void OnGet(PayResult paymentResult)
        {
            Result = paymentResult;
        }
    }
}
