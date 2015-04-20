
using Sample.iOS.Settings;
using Sample.Service;
using System;
using System.IO;
using Xamarin.Forms;

[assembly: Dependency(typeof(Global))]
namespace Sample.iOS.Settings
{
    public class Global : IPathPlatform
    {
        public string PlatformDefaultPath
        {
            get 
            {
                var personal = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
                return Path.Combine(personal, "..", "Library");
            }
        }
    }
}
