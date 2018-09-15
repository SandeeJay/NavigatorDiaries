using System;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using System.Diagnostics;

namespace NavigatorDiaries.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class TripPlanner : ContentPage
	{

        public TripPlanner()
        {
            InitializeComponent();
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();

            // Reset the 'resume' id, since we just want to re-start here
            ((App)Application.Current).ResumeAtTodoId = -1;
            listView.ItemsSource = await App.Database.GetItemsAsync();
        }

        async void OnItemAdded(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new PlannerItemsPage
            {
                BindingContext = new TripPlannerItems()
            });
        }

        async void OnListItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            
            if (e.SelectedItem != null)
            {
                await Navigation.PushAsync(new PlannerItemsPage
                {
                    BindingContext = e.SelectedItem as TripPlannerItems
                });
            }
        }

    }
}