using System;
using System.Threading.Tasks;
using Android.App;
using Android.Content;
using Android.Content.PM;
using Android.OS;
using Android.Util;
using Plugin.Permissions;
//using Plugin.Permissions.Abstractions;
using Xamarin.Forms.Platform.Android;
using Plugin.CurrentActivity;
using Plugin.Geolocator;


namespace NavigatorDiaries.Droid
{
    [Activity(Label = "NavigatorDiaries", Icon = "@mipmap/icon", Theme = "@style/MainTheme", MainLauncher = false, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
    public class MainActivity : FormsAppCompatActivity
    {
        internal static MainActivity Instance { get; private set; }

        protected override void OnCreate(Bundle bundle)
        {
            TabLayoutResource = Resource.Layout.Tabbar;
            ToolbarResource = Resource.Layout.Toolbar;
            base.OnCreate(bundle);
            Xamarin.Essentials.Platform.Init(this, bundle);
            Xamarin.Forms.Forms.Init(this, bundle);
            LoadApplication(new App());
            //CrossCurrentActivity.Current.Activity = this;
            CrossCurrentActivity.Current.Init(this, bundle);

        }
        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, Permission[] grantResults)
        {
            PermissionsImplementation.Current.OnRequestPermissionsResult(requestCode, permissions, grantResults);
            Xamarin.Essentials.Platform.OnRequestPermissionsResult(requestCode, permissions, grantResults);
            base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        }
    }


    [Activity(Label = "NavigatorDiaries", Icon = "@mipmap/icon", Theme = "@style/MyTheme.Splash", MainLauncher = true, NoHistory = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
    public class SplashActivity : FormsAppCompatActivity
    {
        static readonly string TAG = "SplashActivity:" + typeof(SplashActivity).Name;

        public override void OnCreate(Bundle savedInstanceState, PersistableBundle persistentState)
        {
            base.OnCreate(savedInstanceState, persistentState);
            Log.Debug(TAG, "SplashActivity.OnCreate");
        }


        // Launches the startup task
        protected override void OnResume()
        {
            base.OnResume();
            Task startupWork = new Task(() => { SimulateStartup(); });
            startupWork.Start();
        }

        // Simulates background work that happens behind the splash screen
        async void SimulateStartup()
        {
            Log.Debug(TAG, "Performing startup work");
            await Task.Delay(1500); // Simulate a bit of startup work.
            Log.Debug(TAG, "Startup work is finished:starting MainActivity");
            StartActivity(new Intent(Application.Context, typeof(MainActivity)));
            
        }


    }

}


