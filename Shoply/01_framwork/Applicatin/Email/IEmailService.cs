namespace _01_framwork.Applicatin.Email
{
    public interface IEmailService
    {
        void SendEmail(string title, string messageBody, string destination);
    }
}