
using Xamarin.Forms;

namespace Sample.Page.MenuRootPage
{
    public class MenuPage : ContentPage
    {
        #region Properties

        public ListView Menu { get; set; }
        
        #endregion

        #region Constructor
        public MenuPage()
        {
            Title = "Menu";
            BackgroundColor = Color.FromHex("1a1c20");

            Menu       = new MenuListView();
            var layout = new StackLayout
            {
                Spacing = 0,
                VerticalOptions = LayoutOptions.FillAndExpand
            };

            layout.Children.Add(Menu);
            Content = layout;
        }
        
        #endregion
    }
}
