using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using System.IO;
using System.Diagnostics;
using NavigatorDiaries.Views;
using Microsoft.AppCenter;
using Microsoft.AppCenter.Analytics;
using Microsoft.AppCenter.Crashes;



[assembly: XamlCompilation (XamlCompilationOptions.Compile)]
namespace NavigatorDiaries
{
	public partial class App : Application
	{

        static JournaEntrylItemsDatabase database1;
        static TripPlannerDatabase database;
        static UserDatabase database2;
        public static bool IsUserLoggedIn { get; set; }

        public App ()
		{
			InitializeComponent();

			//MainPage = new NavigatorDiaries.Views.LoginPage();
            //  MainPage = new NavigatorDiaries.Views.MainScreen();
            //MainPage=new NavigationPage(new Views.MainScreenDetail());

            if (!IsUserLoggedIn)
            {
                MainPage = new NavigationPage(new LoginPage());
            }
            else
            {
                MainPage =  new MainScreen();
            }

        }

        /// <Summary> 
        /// Define Journal Entry Database 
        /// Define journal Entry Database path
        /// @return databse1
        /// <Summary>
        public static JournaEntrylItemsDatabase  Database1
        {
            get
            {
                if (database1 == null)
                {
                    database1 = new JournaEntrylItemsDatabase(
                      Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "TodoSQLite.db3"));
                }
                return database1;
            }
        }
        public int ResumeAtEntryId { get; set; }



        /// <Summary> 
        /// Define Trip Planner Database 
        /// Define journal Entry Database path
        /// <Summary>
        public static TripPlannerDatabase Database
        {
            get
            {
                if (database == null)
                {
                    database = new TripPlannerDatabase(
                      Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "TodoSQLite.db3"));
                }
                return database;
            }
        }
        public int ResumeAtTodoId { get; set; }

        /// <summary>
        /// Define User
        /// </summary>
        public static UserDatabase Database2
        {
            get
            {
                if (database2 == null)
                {
                    database2 = new UserDatabase(
                      Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "TodoSQLite.db3"));
                }
                return database2;
            }
        }
        public int ResumeAtUserId { get; set; }



        protected override void OnStart ()
		{
            AppCenter.Start("android=c1fa0a42-f05c-4576-9927-6514bfa11613;" + "uwp={Your UWP App secret here};" + "ios={Your iOS App secret here}", typeof(Analytics), typeof(Crashes));
        }

		protected override void OnSleep ()
		{
			// Handle when your app sleeps
		}

		protected override void OnResume ()
		{
			// Handle when your app resumes
		}

        
    }
}
