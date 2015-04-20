using Sample.Page;
using Xamarin.Forms;

namespace Sample
{
    public class App : Application
    {
        public App()
        {
            MainPage = new RootPage();
        }

        ///WINDOWS PHONE HACK.
        public static Xamarin.Forms.Page GetMainPage()
        {
            return new App().MainPage;
        }
    }
}
