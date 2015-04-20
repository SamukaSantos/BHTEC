

using Sample.Page.Interface;
using Sample.Service;
using Sample.Service.Creator;
using Sample.ViewModel;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Labs.Services.Media;

namespace Sample.Page
{
    public class PhotoPage : ContentBasePage, IMessage, IMediaBehavior
    {
        #region Fields

        private readonly TaskScheduler _scheduler = TaskScheduler.FromCurrentSynchronizationContext();
        private Image _imageProfile;
        private string _mediaPath;
        private Button _sendButton;

        #endregion

        #region Constructor

        public PhotoPage(string email)
        {
            InitializeComponents();

            var context = ServiceCreator.Get<PhotoViewModel>(this.Navigation, email);
            context.Message       = this;
            context.MediaBehavior = this;

            BindingContext = context;
        }

        #endregion

        #region Methods

        public override void InitializeComponents()
        {
            NavigationPage.SetHasNavigationBar(this, false);
            this.Title = "PHOTO .:";

            _imageProfile = new Image()
            {
                Source = ImageSource.FromFile("camera.png"),
                Aspect            = Aspect.AspectFill,
                HorizontalOptions = LayoutOptions.Center,
                VerticalOptions   = LayoutOptions.Center,
                WidthRequest      = 300,
                HeightRequest     = 300
            };

            var pictureButton = new Button() { Text= "Image Action" };
            pictureButton.SetBinding(Button.CommandProperty, "SelectCommand");

            _sendButton = new Button { Text = "Send by Email", IsVisible = false };
            _sendButton.SetBinding(Button.CommandProperty, "SendCommand");
            

            Content = new StackLayout
            {
                Padding = new Thickness(20, 10, 20, 10),
                Children =
                    { 
                        _imageProfile, 
                        pictureButton,
                        _sendButton
                    }
            };

        }

        private async Task<MediaFile> OpenGallery()
        {
            var mediaPicker = DependencyService.Get<IMediaPicker>();
            return await mediaPicker.SelectPhotoAsync(new CameraMediaStorageOptions { MaxPixelDimension = 1024 }).ContinueWith(t =>
            {
                if (t.IsFaulted)
                {
                    DisplayAlert("Error !", t.Exception.InnerException.ToString(), "OK");
                }
                else if (t.IsCanceled)
                {

                }
                else
                {
                    var mediaFile        = t.Result;
                    _mediaPath           = mediaFile.Path;
                    _imageProfile.Source = ImageSource.FromStream(() => mediaFile.Source);
                    return mediaFile;
                }
                return null;
            }, _scheduler);
        }

        public async Task<MediaFile> TakePicture() 
        {
            if (Device.OS == TargetPlatform.WinPhone)
            {
                var mediaPicker = DependencyService.Get<IWP8MediaPicker>();
                mediaPicker.Show();
                mediaPicker.Result = (c, d) =>
                {
                    _mediaPath = d;
                    _imageProfile.Source = ImageSource.FromStream(() => c);
                    _sendButton.IsVisible = true;
                };


                return null;
            }

            else
            {
                var mediaPicker = DependencyService.Get<IMediaPicker>();
                return await mediaPicker.TakePhotoAsync(new CameraMediaStorageOptions { DefaultCamera = CameraDevice.Rear, MaxPixelDimension = 400 }).ContinueWith(t =>
                {
                    if (t.IsFaulted)
                    {
                        DisplayAlert("Error !", t.Exception.InnerException.ToString(), "OK");
                    }
                    else if (t.IsCanceled)
                    {

                    }
                    else
                    {
                        var mediaFile = t.Result;
                        _mediaPath = mediaFile.Path;
                        _imageProfile.Source = ImageSource.FromStream(() => mediaFile.Source);
                        _sendButton.IsVisible = true;
                        return mediaFile;
                    }
                    return null;
                }, _scheduler);
            }
        }

        public async void Select()
        {
            //var action = await DisplayActionSheet("Image Action", "Cancel", null, "Photo Library", "Take Picture");
            var action = await DisplayActionSheet("Image Action", "Cancel", null, "Take Picture");
            if (action != null)
            {
                switch (action)
                {
                    case "Take Picture":
                        await TakePicture();
                        break;
                    //case "Photo Library":
                    //    await OpenGallery();
                    //    break;
                    case "Cancel":
                        break;
                }
            }
        }

        public void Send(string email)
        {
            try
            {
                var iEmail = DependencyService.Get<IEmail>();
                iEmail.Send(email, _mediaPath);

                DisplayAlert("Success", "Email has sent successfully.", "Ok");
                Navigation.PopToRootAsync();
            }
            catch (System.Exception er)
            {
                DisplayAlert("Success", er.Message , "Ok");
            }
            
        }

        #endregion

    }
}
