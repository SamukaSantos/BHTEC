using Sample.Page.MenuRootPage;
using System;
using Xamarin.Forms;

namespace Sample.Page
{
    public class RootPage : MasterDetailPage
    {
        #region Fields

        private Color _backGroundBolor = Color.FromHex("6fc833");

        #endregion

        #region Constructor
        public RootPage()
        {
        
            var menuPage = new MenuPage();
            menuPage.Menu.ItemSelected += (sender, e) => NavigateTo(e.SelectedItem as MenuRootIem);

            Master = menuPage;
			Detail = new NavigationPage(new GitPage())
            {
                BarBackgroundColor = _backGroundBolor,
            };
        }

        #endregion

        #region Methods

        private void NavigateTo(MenuRootIem menu)
        {
            var displayPage = (Xamarin.Forms.Page)Activator.CreateInstance(menu.TargetType);
			Detail = new NavigationPage(displayPage)
            {
                BarBackgroundColor = _backGroundBolor,
                Title = displayPage.Title
            };
           
            
            IsPresented = false;
        }
        protected override void OnAppearing()
        {
            base.OnAppearing();
        }

        #endregion
    }

}
