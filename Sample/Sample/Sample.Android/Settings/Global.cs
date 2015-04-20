
using Sample.Droid.Settings;
using Sample.Service;
using Xamarin.Forms;

[assembly: Dependency(typeof(Global))]
namespace Sample.Droid.Settings
{
    public class Global : IPathPlatform
    {
        public string PlatformDefaultPath
        {
            get 
            {
               return  System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal); 
            }
        }
    }
}