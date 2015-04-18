

using System.Collections.Generic;
using Xamarin.Forms;
using Sample.Page;

namespace Xamarin.HighCharts.Page.MenuRootPage
{
    public class MenuListData  : List<MenuRootIem>
    {
        #region Constructor
        public MenuListData()
        {
            this.Add(new MenuRootIem()
            {
                Title = "Profile",
                //   IconSource = "contacts.png",
                TargetType = typeof(GitPage)
            });
			
			
            
        #endregion


        }
    }
}
