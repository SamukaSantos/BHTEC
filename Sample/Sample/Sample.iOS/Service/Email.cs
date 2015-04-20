
using Sample.iOS.Service;
using Sample.Service;
using System.Net;
using System.Net.Mail;
using Xamarin.Forms;

[assembly: Dependency(typeof(Email))]
namespace Sample.iOS.Service
{
    public class Email : IEmail
    {
        public void Send(string email, string file)
        {
            try
            {
                var smtp = new SmtpClient
                {
                    Host = "smtp.gmail.com",
                    Port = 587,
                    EnableSsl = true,
                    DeliveryMethod = SmtpDeliveryMethod.Network,
                    UseDefaultCredentials = false,
                    Credentials = new NetworkCredential("challengemake@gmail.com", "h4ck3r##")
                };


                var mail = new MailMessage();
                mail.From = new MailAddress("challengemake@gmail.com");
                mail.To.Add(email);
                mail.Subject = "BHTEC";
                mail.Body = "My picture...";

                var attachment = new System.Net.Mail.Attachment(file);
                mail.Attachments.Add(attachment);

                smtp.Send(mail);
            }
            catch (System.Exception)
            {
                throw;
            }

        }
    }
}
