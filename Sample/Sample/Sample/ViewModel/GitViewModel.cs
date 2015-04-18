using Sample.Service;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace Sample.ViewModel
{
    public class GitViewModel : INotifyPropertyChanged
    {

        #region Fields

        private string _userName;

        #endregion

        #region Properties

        public GitService Service { get; set; }

        public string UserName 
        {
            get { return _userName;  }
            set 
            {
                _userName = value;
                RaisedPropertyChanged(() => UserName);
            }
        }

        #endregion

        #region Command

        public ICommand SubmitCommand
        {
            get 
            { 
                return new Command(() => 
                            {
						GetUser();
                            }); 
            }
        }


		public void GetUser()
		{
			Service = new GitService ();

			Octokit.User user = Service.GetUserAsync (UserName);

			UserName = user.Name;
		}

        #endregion

        #region Constructor

        public GitViewModel()
        {
            Service = new GitService();
        }

        #endregion

        #region Events
        public event PropertyChangedEventHandler PropertyChanged;
        #endregion


        #region Methods

        protected void RaisedPropertyChanged<PropertyType>(Expression<Func<PropertyType>> property)
        {
            var memberExpression = property.Body as MemberExpression;
            var propertyInfo = memberExpression.Member as PropertyInfo;

            if (propertyInfo != null)
            {
                if (PropertyChanged != null)
                    PropertyChanged(this, new PropertyChangedEventArgs(propertyInfo.Name));
            }
        }

        #endregion
    }
}
