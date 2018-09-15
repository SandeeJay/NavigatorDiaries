using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using NavigatorDiaries.Views;

namespace NavigatorDiaries.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MainScreenMaster : ContentPage
    {
        public ListView ListView;

        public MainScreenMaster()
        {
            InitializeComponent();

            BindingContext = new MainScreenMasterViewModel();
            
            ListView = NavItemsListView;
            
            

        }




        class MainScreenMasterViewModel : INotifyPropertyChanged
        {
            public ObservableCollection<MainScreenMenuItem> MenuItems { get; set; }
            public ObservableCollection<MainScreenMenuItem> NavItems { get; set; }



            public MainScreenMasterViewModel()
            {

                NavItems = new ObservableCollection<MainScreenMenuItem>(new[]
                {
                    new MainScreenMenuItem { Id = 0, Icon="@drawable/home",Title = "Home" },
                    new MainScreenMenuItem { Id = 1, Icon="@drawable/person",Title = "Profile", TargetType=typeof(Profile)},
                    new MainScreenMenuItem { Id = 2, Icon="@drawable/feedback",Title = "Help & Feedback", TargetType=typeof(Help)},
                    new MainScreenMenuItem { Id = 3, Icon="@drawable/logout",Title = "Logout" },
                   
                });


        
            }
            
            #region INotifyPropertyChanged Implementation
            public event PropertyChangedEventHandler PropertyChanged;
            void OnPropertyChanged([CallerMemberName] string propertyName = "")
            {
                if (PropertyChanged == null)
                    return;

                PropertyChanged.Invoke(this, new PropertyChangedEventArgs(propertyName));
            }
            #endregion
        }
    }
}