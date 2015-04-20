
using Sample.Service;
using Sample.WinPhone.Settings;
using Windows.Storage;
using Xamarin.Forms;

[assembly: Dependency(typeof(Global))]
namespace Sample.WinPhone.Settings
{
    public class Global : IPathPlatform
    {

        public string PlatformDefaultPath
        {
            get 
            {
                return ApplicationData.Current.LocalFolder.Path;
            }
        }
    }
}
