

using Sample.Page.Interface;
using System;
using System.Windows.Input;
using Xamarin.Forms;

namespace Sample.ViewModel
{
    public class PhotoViewModel : ViewModelBase, IPhotoViewModel
    {

        #region Fields

        private ICommand _selectCommand;
        private ICommand _sendCommand;
        private string _email;

        #endregion

        #region Properties

        public IMediaBehavior MediaBehavior { get; set; }

        #endregion

        #region Constructor

        public PhotoViewModel(INavigation navigation, string email)
            : base(navigation)
        {
            _email = email;
        }

        #endregion

        #region Commands

        public ICommand SelectCommand 
        {
            get 
            {
                return _selectCommand ?? (_selectCommand = new Command(() =>
                    { 
                        MediaBehavior.Select(); 
                    }));
            }
        
        }

        public ICommand SendCommand
        {
            get 
            {
                return _sendCommand ?? (_sendCommand = new Command(() => 
                {
                    MediaBehavior.Send(_email); 
                }));
            }
        }

        #endregion


       
    }
}
