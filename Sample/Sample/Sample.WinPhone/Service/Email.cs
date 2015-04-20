
using Microsoft.Phone.Tasks;
using Sample.Service;
using Sample.WinPhone.Service;
using System.IO;
using System.IO.IsolatedStorage;
using System.Net;
using System.Net.Mail;
using Xamarin.Forms;

[assembly: Dependency(typeof(Email))]
namespace Sample.WinPhone.Service
{
    public class Email : IEmail
    {
        public void Send(string email, string file) 
        {
            try
            {
                //EmailComposeTask doesn't have option to attach file.
                var imageFromFile = new Xamarin.Forms.Image();
                imageFromFile.Source = ImageSource.FromFile(file);
              
                var emailComposeTask = new EmailComposeTask();

                emailComposeTask.Subject = "BHTEC";
                emailComposeTask.Body = "My picture...";
                emailComposeTask.To = email;


                emailComposeTask.Show();
            }
            catch (System.Exception)
            {   
                throw;
            }
            
        }
    }
}