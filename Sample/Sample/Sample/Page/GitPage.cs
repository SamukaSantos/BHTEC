using Sample.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Sample.Page
{
    public class GitPage : ContentPage
    {
        public GitPage()
        {



            var entry = new Entry{ Placeholder = "Username" };
            entry.SetBinding(Entry.TextProperty, "UserName");

			var Email = new Entry{ Placeholder = "Email" };
			Email.SetBinding(Entry.TextProperty, "Email");

			var Login = new Entry{ Placeholder = "Login" };
			Login.SetBinding(Entry.TextProperty, "Login");

            var btn = new Button{ Text = "Search" };
            btn.SetBinding(Button.CommandProperty, "SubmitCommand");

            BindingContext = new GitViewModel();

            Content = new StackLayout
            {
                Children = { entry, btn,Login,Email }
            };
        }
    }
}
