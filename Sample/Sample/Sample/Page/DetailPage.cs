
using Sample.Page.Interface;
using Sample.Service.Creator;
using Sample.ViewModel;
using Xamarin.Forms;

namespace Sample.Page
{
    public class DetailPage : ContentBasePage, IMessage
    {
        #region Constructor

        public DetailPage(Octokit.User gitUser)
        {   
            InitializeComponents();

            var context = ServiceCreator.Get<DetailViewModel>(this.Navigation, gitUser);
            context.Message = this;

            BindingContext = context;
        }

        #endregion

        #region Methods
        public override void InitializeComponents()
        {
            Title = "DETAILS .:";

            var labelId = new Label { Text = "Id.:", TextColor = Color.Blue, FontSize = 15 };
            var id      = new Label();
            id.SetBinding(Label.TextProperty, "User.Id");
            
            var labelLogin = new Label { Text = "Login.:", TextColor = Color.Blue, FontSize = 15 };
            var login = new Label();
            login.SetBinding(Label.TextProperty, "User.Login");
            
            var labelName = new Label { Text = "Name.:", TextColor = Color.Blue, FontSize = 15 };
            var name = new Label();
            name.SetBinding(Label.TextProperty, "User.Name");
            
            var labelEmail = new Label { Text = "Email.:", TextColor = Color.Blue, FontSize = 15 };
            var email = new Label();
            email.SetBinding(Label.TextProperty, "User.Email");

            var labelAvatar = new Label { Text = "Avatar.:", TextColor = Color.Blue, FontSize = 15 };
            var avatar = new Image();
            avatar.SetBinding(Image.SourceProperty, "User.AvatarUrl");

            var takePhotoButton = new Button { Text = "Photo page" };
            takePhotoButton.SetBinding(Button.CommandProperty, "TakePhotoCommand");

            var backButton = new Button { Text = "Back" };
            backButton.SetBinding(Button.CommandProperty, "BackCommand");

            Content = new ScrollView
            {
                Content = new StackLayout
                {
                     Children = 
                     { 
                        labelId, id,
                        labelLogin, login,
                        labelName, name,
                        labelEmail, email,
                        labelAvatar, avatar,
                        takePhotoButton,
                        backButton
                    }
                }
            };
        } 

        
        #endregion
       
    }
}
