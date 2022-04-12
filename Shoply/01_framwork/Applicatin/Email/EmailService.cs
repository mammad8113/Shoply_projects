using MimeKit;
using System.Net.Mail;
using System.Net;

namespace _01_framwork.Applicatin.Email
{
    public class EmailService : IEmailService
    {
        public void SendEmail(string title, string messageBody, string destination)
        {
            var message = new MailMessage();

            var from = new MailboxAddress("Shoply", "mhmdhsynnzry7@gmail.com");


            var to = new MailboxAddress("User", destination);
            message.To.Add(destination);

            message.Subject = title;
            var bodyBuilder = new BodyBuilder
            {
                HtmlBody = $"<h1>{messageBody}</h1>",
            };
            message.Subject = messageBody;

            SmtpClient Client = new SmtpClient();
            Client.Host = "smtp.gmail.com"; //host name 
            Client.Port = 5001;
            Client.EnableSsl = true;
            Client.Credentials = new NetworkCredential("mhmdhsynnzry7@gmail.com", "mammad8113");
            Client.Send(message);

            Client.Dispose();
        }
    }
}