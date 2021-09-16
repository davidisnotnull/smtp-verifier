using System;
using System.Net;
using System.Net.Mail;
using System.Text;

namespace SMTPVerifier
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("--SendGrid SMTP Verifier--");

            var basicAuthInfo = new NetworkCredential("apikey", "YOUR API KEY GOES HERE");

            var smtpClient = new SmtpClient("smtp.sendgrid.net")
            {
                UseDefaultCredentials = false,
                Credentials = basicAuthInfo
            };

            var sender = new MailAddress("nicolasecage@ragecage.com.com", "Nick Cage");
            var recipient = new MailAddress("johnsmith@email.com", "John Smith");

            var email = new MailMessage(sender, recipient)
            {
                Subject = "SendGrid SMTP Verification Email",
                SubjectEncoding = Encoding.UTF8,
                Body = "<b>Test email using HTML</br>",
                BodyEncoding = Encoding.UTF8,
                IsBodyHtml = true
            };

            var replyTo = new MailAddress("reply@ragecage.com");
            email.ReplyToList.Add(replyTo);

            try
            {
                smtpClient.Send(email);
                Console.WriteLine("Message sent.");
            }
            catch (SmtpException ex)
            {
                Console.WriteLine($"SmtpException has occured: {ex.Message}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"The application failed with error: {ex.Message}");
            }
        }
    }
}
