

using System.Collections.Generic;
using Xamarin.Forms;
using Sample.Page;

namespace Sample.Page.MenuRootPage
{
    public class MenuListData  : List<MenuRootIem>
    {
        #region Constructor
        public MenuListData()
        {
            this.Add(new MenuRootIem()
            {
                Title = "Take Picture",
                //   IconSource = "contacts.png",
                TargetType = typeof(GitPage)
            });
            
        #endregion


        }
    }
}
