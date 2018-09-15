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
	public partial class UserUpdate : ContentPage
	{
		public UserUpdate ()
		{
			InitializeComponent ();
            
        }

        async void OnUpdateButtonClicked(object sender, EventArgs e)
        {

            var UserItem = (User)BindingContext;
            await App.Database2.SaveUserAsync(UserItem);
            await Navigation.PopAsync();

        }

    }
}