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


namespace NavigatorDiaries.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class GpsPage : ContentPage
	{
		public GpsPage ()
		{
			InitializeComponent ();

            

        }

        /* private async void Button_OnClicked(object sender, EventArgs e)
         {
             var Locator = CrossGeolocator.Current;
             Locator.DesiredAccuracy = 50;

             var Position = await Locator.GetPositionAsync(TimeSpan.FromSeconds(500000), null, true);

             LonLabel.Text = Position.Longitude.ToString();
             LatLabel.Text = Position.Latitude.ToString();
         }*/


        private async void Button_OnClicked(object sender, EventArgs e)
        {

            try { 
                    var hasPermission = await CheckPermissions();
                    if (!hasPermission)
                        return;

                    var position = await Geolocation.GetLastKnownLocationAsync();

                    if (position == null)
                    {
                        // get full location if not cached.
                        position = await Geolocation.GetLocationAsync(new GeolocationRequest
                        {
                            DesiredAccuracy = GeolocationAccuracy.Best,
                            Timeout = TimeSpan.FromSeconds(50)
                        });
                    }

                LonLabel.Text = position.Longitude.ToString();
                LatLabel.Text  = position.Latitude.ToString();
                }
                         
            catch (Exception ex)
            {
                
                System.Diagnostics.Debug.WriteLine(ex.Message);
            }

           
        }

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

    }
}