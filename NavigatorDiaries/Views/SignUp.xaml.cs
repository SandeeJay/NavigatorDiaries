using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace NavigatorDiaries.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class SignUp : ContentPage
	{
        User UserData = new User();
		public SignUp ()
		{
			InitializeComponent ();
            BindingContext = new User();




        }

        async void OnSignUpButtonClicked(object sender, EventArgs e)
        {

                var UserItem = (User)BindingContext;
                await App.Database2.SaveUserAsync(UserItem);
                await Navigation.PushModalAsync(new MainScreen());
            /*var rootPage = Navigation.NavigationStack.FirstOrDefault();
                if (rootPage != null)
                {

                    
                    App.IsUserLoggedIn = true;
                    await Navigation.PushModalAsync(new MainScreen());
                    //await Navigation.PopAsync();
                }*/
            
         
        }
      
    }
}