using MvvmHelpers;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using SQLite;
using System.IO;

namespace NavigatorDiaries.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class Search : ContentPage
	{
        // public ObservableCollection<SearchVM> EnViews { get; set; }

        public JournaEntrylItems test1 = new JournaEntrylItems ();
        public string TestEmo { get; set; }
        
        public Search ()
		{
           
            InitializeComponent ();

            SearchDate.Date = DateTime.Today;
            string date = "";
            date = SearchDate.ToString();
            





        }

        

        protected override async void OnAppearing()
        {
            base.OnAppearing();

                                 
            ((App)Application.Current).ResumeAtEntryId = -1;
            RecentList.ItemsSource =await App.Database1.GetItemsAsync();

           
            ///Loading Pickers
            WeatherPicker.ItemsSource = await App.Database1.PickWeatherAsync();
            LocationPicker.ItemsSource = await App.Database1.PickLocationAsync();
            EmotionPicker.ItemsSource = await App.Database1.PickEmotionAsync();
            

        }
       
         async void SearchClicked(object sender, EventArgs e)
        {

            RecentList.ItemsSource = await App.Database1.SearchTestAsync();
            //  BindingContext = test1.Emotion;

            // App.Database1.TestEntryAsync(testEmo);
            //EmotionPicker.ItemsSource = await App.Database1.TestEntryAsync(test1.Emotion);
            // TestL.Text = LocationPicker.SelectedItem.ToString();
            //TestL.Text = TestEmo;
            // TestEmo = test1.Emotion;
            // TestL.SetBinding(Label.TextProperty, new Binding("City", stringFormat: "{0}"));
            // RecentList.ItemsSource = await App.Database1.GetItemsAsync();
            

        }



        async void OnItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            if (e.SelectedItem != null)
            {
                await Navigation.PushAsync(new EntryView
                {
                    BindingContext = e.SelectedItem as JournaEntrylItems
                });
            }

        }

    }
}