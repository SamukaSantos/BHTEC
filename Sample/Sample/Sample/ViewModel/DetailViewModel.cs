
using Octokit;
using Sample.Page;
using Sample.Service.Creator;
using Sample.ViewModel.Interface;
using System.Windows.Input;
using Xamarin.Forms;

namespace Sample.ViewModel
{
    public class DetailViewModel : ViewModelBase, IDetailViewModel
    {
        #region Fields

        private User _user;
        private Command _takePhotoCommand;

        #endregion

        #region Properties

        public User User 
        {
            get 
            {
                return _user; 
            }
            set 
            {
                _user = value;
                RaisedPropertyChanged(() => User);
            }
        }

        #endregion

        #region Constructor

        public DetailViewModel(INavigation navigation, User gitUser)
            : base(navigation)
        {
            User = gitUser;
        }

        #endregion

        #region Commands

        public ICommand TakePhotoCommand 
        {
            get 
            {
                return _takePhotoCommand ?? (_takePhotoCommand = new Command(async()=>
                {
                    if (string.IsNullOrEmpty(User.Email)) 
                    {
                        await Message.DisplayAlert("Warning", "Email is required.", "Ok");
                        return;
                    }
                    await Navigation.PushAsync(ServiceCreator.Get<PhotoPage>(User.Email));
                }));
            }
        }

        public ICommand BackCommand
        {
            get 
            {
                return new Command(() => { Navigation.PopAsync(); });
            }
        }

        #endregion
      
    }
}
