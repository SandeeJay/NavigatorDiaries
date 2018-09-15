using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using NavigatorDiaries.Views;
using NavigatorDiaries;
using static Android.Provider.ContactsContract.CommonDataKinds;

namespace NavigatorDiaries.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class LoginPage : ContentPage
	{
		public LoginPage ()
		{
            InitializeComponent();
        }

        async void OnSignUpButtonClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new SignUp());
        }

        async void OnLoginClicked(object sender, EventArgs e)
        {
            var user = new User
            {
                UserName = UserName.Text,
                Password = Password.Text
            };

            var isValid = AreCredentialsCorrect(user);
            if (isValid)
            {
                App.IsUserLoggedIn = true;
                await Navigation.PushModalAsync(new MainScreen());
                await Navigation.PopAsync();
            }
            else
            {
                messageLabel.Text = "Login failed";
                Password.Text = string.Empty;
            }
        }

        bool AreCredentialsCorrect(User user)
        {
            return user.UserName == LoginVM.Username && user.Password == LoginVM.Password;
        }
    }
}