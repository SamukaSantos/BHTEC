using Sample.Page.Interface;
using Sample.Service.Creator;
using Sample.ViewModel;
using Xamarin.Forms;

namespace Sample.Page
{
    public class GitPage : ContentBasePage, IMessage
    {
        public GitPage()
        {
            InitializeComponents();
            var context = ServiceCreator.Get<GitViewModel>(this.Navigation);
            context.Message = this;

            BindingContext = context;
        }

        public override void InitializeComponents()
        {
            Title = "GIT USER .:";

            var entry = new Entry{ Placeholder = "Username" };
            entry.SetBinding(Entry.TextProperty, "UserName");

            var searchButton = new Button{ Text = "Get" };
            searchButton.SetBinding(Button.CommandProperty, "SearchCommand");

            Content = new StackLayout
            {
                Children = { entry, searchButton }
            };
        }
    }
}
