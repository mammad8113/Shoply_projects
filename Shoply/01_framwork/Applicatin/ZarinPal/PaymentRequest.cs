namespace _0_Framework.Application.ZarinPal
{
    public class PaymentRequest
    {
        public string Mobile { get; set; }
        public string Email { get; set; }
        public string CallbackURL { get; set; }
        public string Description { get; set; }
        public int Amount { get; set; }
        public string MerchantID { get; set; }
    }
    public class PayRequest
    {
        public string api { get; set; }
        public double amount { get; set; }
        public string redirect { get; set; }
        public string mobile { get; set; }
        public int factorNumber { get; set; }
        public string validCardNumber { get; set; }
    }
}
