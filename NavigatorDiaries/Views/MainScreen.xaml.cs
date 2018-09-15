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
    public partial class MainScreen : MasterDetailPage
    {
        public MainScreen()
        {
            InitializeComponent();
           MasterPage.ListView.ItemSelected += ListView_ItemSelected;
          
        }
        
        private void ListView_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            if (!(e.SelectedItem is MainScreenMenuItem item))
                return;

            item = (MainScreenMenuItem)e.SelectedItem;
            Type page = item.TargetType;
            Detail = new NavigationPage((Page)Activator.CreateInstance(typeof(MainScreenDetail)));
            Detail.Navigation.PushAsync((Page)Activator.CreateInstance(page));
            IsPresented = false;
            MasterPage.ListView.SelectedItem = null;
        }
    }
}