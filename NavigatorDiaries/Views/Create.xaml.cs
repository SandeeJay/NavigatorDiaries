using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Xamarin.Essentials;
using System.Runtime.InteropServices;

namespace NavigatorDiaries.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class Create : ContentPage
    {
        JournaEntrylItems Entry = new JournaEntrylItems();
        public Create(string city, string CityWeather)
        {
            InitializeComponent();

            
              JournalEntry.Keyboard = Keyboard.Create(flags: KeyboardFlags.All);
              CDate.Text = Entry.Date = DateTime.Now.ToString("dddd, dd MMMM yyyy"); 
              CTime.Text = Entry.Time= DateTime.Now.ToString("@HH:mm");
              location.Text= Entry.City = city;
              weatherLabel.Text = Entry.Weather = CityWeather;
              BindingContext = Entry; 
              
        }
        

        async void OnCreateClicked(object sender, EventArgs e)
        {
            try
            {

                var JournalntryItem = BindingContext = Entry;
                await App.Database1.SaveItemAsync(JournalntryItem);
                await Navigation.PopAsync();
            }

            catch (Exception )
            {                
                   
                   await DisplayAlert("System Error", "Journal Creation unsuccessful", "OK");
                               
               
            }
        }



    }
}