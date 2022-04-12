using _0_Framework.Application.ZarinPal;

namespace _01_framwork.Applicatin.ZarinPal
{
    public interface IZarinPalFactory
    {
        string Prefix { get; set; }

        PaymentResponse CreatePaymentRequest(string amount, string mobile, string email, string description,
            long orderId);

        VerificationResponse CreateVerificationRequest(string authority, string price);
    }
}