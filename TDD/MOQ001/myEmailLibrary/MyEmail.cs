using System.Net;
using System.Net.Mail;

namespace myEmailLibrary
{
    public class MyEmail:IMyEmail
    {
        public bool sendEmail()
        {
            MailAddress fromAddress = new MailAddress("shibuthannikkunnath@gmail.com", "Shibu Thannikkunnath");
            MailAddress toAddress = new MailAddress("shibu.t@aol.com", "Shibu on Aol");
            const string password = "h24m3op2";
            const string subject = "Test email from .Net";
            const string body = "test message test message";

            SmtpClient smtp = new SmtpClient
            {
                Host = "smtp.gmail.com",
                Port = 857,
                EnableSsl = true,
                DeliveryMethod = SmtpDeliveryMethod.Network,
                UseDefaultCredentials = false,
                Credentials = new NetworkCredential(fromAddress.Address, password)
            };

            using(var message = new MailMessage(fromAddress, toAddress) {
                Subject = subject,
                Body = body
            })
            {
                smtp.Send(message);

            }

            return true;
        }
    }
}
