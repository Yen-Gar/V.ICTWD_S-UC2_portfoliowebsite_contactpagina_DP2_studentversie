using System.Net;
using System.Net.Mail;

namespace Portfoliowebsite.Services
{
    public class SmtpEmailSender : IEmailSender
    {
        public async Task SendAsync(string Name, string Email, string Subject, string Message)
        {
            using (var smtp = new SmtpClient("smtp.gmail.com"))
            {
                smtp.Port = 587; // Usually 587 for SSL/TLS
                smtp.UseDefaultCredentials = false; // Must be false to use the line below
                smtp.Credentials = new NetworkCredential("YOUR_EMAIL", "YOUR_APP_PASSWORD");
                smtp.EnableSsl = true;

                var mail = new MailMessage();
                mail.From = new MailAddress("noreply@example.com", "Website");

                mail.To.Add("contact@example.com");

                mail.Subject = $"Contact: {Subject}";
                mail.Body = $"Naam: {Name}\nEmail: {Email}\nBericht:\n{Message}";


                await smtp.SendMailAsync(mail);
            }
   
           
        }
    }
}
