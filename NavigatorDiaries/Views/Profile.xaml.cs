using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using NavigatorDiaries.Views;


namespace NavigatorDiaries.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class Profile : ContentPage
	{

        public Profile ()
		{
			InitializeComponent ();
            BindingContext = new User();
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();


            ((App)Application.Current).ResumeAtUserId = -1;

             ProData.ItemsSource = await App.Database2.SelectUserAsync();



        }


        async void OnUserSelected(object sender, SelectedItemChangedEventArgs e)
        {

           // ((App)Application.Current).ResumeAtUserId = (e.SelectedItem as User).UserID;  //ItemSelected="OnListItemSelected
            if (e.SelectedItem != null)
            {
                await Navigation.PushAsync(new UserUpdate
                {
                    BindingContext = e.SelectedItem as User
                });
            }
           
        }

        

    }
}