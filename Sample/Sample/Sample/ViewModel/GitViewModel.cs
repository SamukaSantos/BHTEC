using Sample.Page;
using Sample.Service;
using Sample.Service.Creator;
using Sample.ViewModel.Interface;
using System.Windows.Input;
using Xamarin.Forms;

namespace Sample.ViewModel
{
    public class GitViewModel : ViewModelBase, IGitViewModel
    {

        #region Fields

        private string _userName;
        private Command _searchCommand;

        #endregion

        #region Properties

        public IGitService Service { get; set; }

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

        public ICommand SearchCommand
        {
            get 
            {
                return _searchCommand ?? (_searchCommand = new Command<string>( c => SearchCommandAction(UserName)));
            }
        }

        #endregion

        #region Constructor

        public GitViewModel(INavigation navigation)
            : base(navigation)
        {
            Service = ServiceCreator.Get<GitService>();
        }

        #endregion

        #region Methods

        public virtual async void SearchCommandAction(string userName) 
        {
            if (string.IsNullOrEmpty(userName)) 
            {
                await Message.DisplayAlert("Error", "Username is required.", "Ok");
                return;
            }

            try
            {
                var user = await Service.GetUserAsync(UserName);
                await Navigation.PushAsync(ServiceCreator.Get<DetailPage>(user));
            }
            catch (System.Exception)
            {
              Message.DisplayAlert("Error", "Service error. Try again !", "Ok");
            } 
        }

        #endregion

    }
}
