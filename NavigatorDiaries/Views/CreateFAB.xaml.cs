using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Plugin.Geolocator;
using Plugin.Permissions.Abstractions;
using Plugin.Permissions;
using System.Windows.Input;
using Xamarin.Essentials;
using System.Runtime.InteropServices;

namespace NavigatorDiaries.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class CreateFAB : ContentPage
	{
        string longatude1 = "";
        string lattitude1 = "";
      
        public CreateFAB()
        {
            InitializeComponent();

           BindingContext = new Weather();
          /*  CreateButton.Clicked += async (sender, args) =>
            {
                await Navigation.PushAsync(new Create());
            };*/

        }


        public string Longatude1 { get => longatude1; set => longatude1 = value; }
        public string Lattitude1 { get => lattitude1; set => lattitude1 = value; }

       



         private async void Create_Clicked(object sender, EventArgs e)
          {

              try
              {
                  var hasPermission = await CheckPermissions();
                  if (!hasPermission)
                  {
                      return;
                  }

                  var position = await Geolocation.GetLastKnownLocationAsync();

                  if (position == null)
                  {
                      // get full location if not cached.
                      position = await Geolocation.GetLocationAsync(new GeolocationRequest
                      {
                          DesiredAccuracy = GeolocationAccuracy.Best,
                          Timeout = TimeSpan.FromSeconds(150)
                      });
                  }

                  Longatude1 = position.Longitude.ToString();
                  Lattitude1 = position.Latitude.ToString();
                  //flat.Text = position.Longitude.ToString();


              }

              catch (Exception ex)
              {

                  System.Diagnostics.Debug.WriteLine(ex.Message);
              }

              // Permission
              async Task<bool> CheckPermissions()
              {
                  var permissionStatus = await CrossPermissions.Current.CheckPermissionStatusAsync(Permission.Location);
                  bool request = false;
                  if (permissionStatus == PermissionStatus.Denied)
                  {
                      if (Device.RuntimePlatform == Device.Android)
                      {

                          var title = "Location Permission";
                          var question = "To get your current city the location permission is required. Please go into Settings and turn on Location for the app.";
                          var positive = "Settings";
                          var negative = "Maybe Later";
                          var task = Application.Current?.MainPage?.DisplayAlert(title, question, positive, negative);
                          if (task == null)
                              return false;

                          var result = await task;
                          if (result)
                          {
                              CrossPermissions.Current.OpenAppSettings();
                          }

                          return false;
                      }

                      request = true;
                  }

                  if (request || permissionStatus != PermissionStatus.Granted)
                  {
                      var newStatus = await CrossPermissions.Current.RequestPermissionsAsync(Permission.Location);
                      if (newStatus.ContainsKey(Permission.Location) && newStatus[Permission.Location] != PermissionStatus.Granted)
                      {
                          var title = "Location Permission";
                          var question = "To get your current city the location permission is required.";
                          var positive = "Settings";
                          var negative = "Maybe Later";
                          var task = Application.Current?.MainPage?.DisplayAlert(title, question, positive, negative);
                          if (task == null)
                              return false;

                          var result = await task;
                          if (result)
                          {
                              CrossPermissions.Current.OpenAppSettings();
                          }
                          return false;
                      }
                  }

                  return true;
              }
            // Permission


            try
            {
                Weather weather = await Core.GetWeather(Lattitude1, Longatude1);
                BindingContext = weather;
                await Navigation.PushAsync(new Create(weather.Title, weather.Visibility));
            }

            catch (Exception ex)
            {

                if (ex is SystemException)
                {

                   await DisplayAlert("System Error", "Unsucessfull Attampt,Try again", "OK");
                }
                else if (ex is ExternalException)
                {
                   await DisplayAlert("Connection Error", "Entry creation was unsuccessful due to connection error", "OK");
                }
                else
                {
                    throw;
                }
            }


          }

    }
}


