using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;
using NavigatorDiaries.Views;

namespace NavigatorDiaries.Views
{
   public class ProfileVm:Application
    {
        public ProfileVm()
        {
            var nav = new NavigationPage
            {
                BarBackgroundColor = Color.Transparent,
                BarTextColor = Color.White
            };


            var listpage = new ContentPage
            {
                Content = new ListView
                {
                    ItemsSource = new List<ContentPage> {
                    new Profile(),

                }
                }
            };
            ((ListView)listpage.Content).ItemSelected += (object sender, SelectedItemChangedEventArgs e) => {
                nav.PushAsync((ContentPage)e.SelectedItem);
            };
            nav.PushAsync(listpage);

            // The root page of your application
            //MainPage = nav;
        }

    }
}
