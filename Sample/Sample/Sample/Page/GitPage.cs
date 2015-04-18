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

            var btn = new Button{ Text = "Search" };
            entry.SetBinding(Button.CommandProperty, "SubmitCommand");

            Content = new StackLayout
            {
                Children = { entry, btn }
            };
        }
    }
}
