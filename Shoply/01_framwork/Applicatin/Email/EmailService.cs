using MimeKit;
using MailKit.Net.Smtp;

namespace _01_framwork.Applicatin.Email
{
    public class EmailService : IEmailService
    {
        public void SendEmail(string title, string messageBody, string destination)
        {
            var message = new MimeMessage();

            var from = new MailboxAddress("Shoply", "mhmdhsynnzry7@gmail.com");
            message.From.Add(from);

            var to = new MailboxAddress("User", destination);
            message.To.Add(to);

            message.Subject = title;
            var bodyBuilder = new BodyBuilder
            {
                HtmlBody = $"<h1>{messageBody}</h1>",
            };

            message.Body = bodyBuilder.ToMessageBody();

            var client = new SmtpClient();
            client.Connect("185.88.154.174", 1430, false);
            client.Authenticate("mhmdhsynnzry7@gmail.com", "mammad8113");
            client.Send(message);
            client.Disconnect(true);
            client.Dispose();
        }
    }
}