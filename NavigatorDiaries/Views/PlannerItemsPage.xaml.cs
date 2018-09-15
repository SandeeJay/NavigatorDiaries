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
	public partial class PlannerItemsPage : ContentPage
	{
		public PlannerItemsPage ()
		{
			InitializeComponent ();
            
		}



        async void OnSaveClicked(object sender, EventArgs e)
        {
            var todoItem = (TripPlannerItems)BindingContext;
            await App.Database.SaveItemAsync(todoItem);
            await Navigation.PopAsync();
        }

        async void OnUpdateClicked(object sender, EventArgs e)
        {
            //var todoItem = BindingContext = trip;
            //await App.Database.UpdateItemAsync(todoItem);
            await Navigation.PopAsync();
        }

        void Onselectdate(object sender, EventArgs e)
        {
            DateLable.Text = TripDate.Date.ToString("dd MMMM yyyy");

            // DateLable.Text = trip.TripDate = TripDate.Date.ToString("dd MMMM yyyy");
        }

        async void OnDeleteClicked(object sender, EventArgs e)
        {
            var todoItem = (TripPlannerItems)BindingContext;
            await App.Database.DeleteItemAsync(todoItem);
            await Navigation.PopAsync();
        }

        async void OnCancelClicked(object sender, EventArgs e)
        {
            await Navigation.PopAsync();
        }

        
    }
}