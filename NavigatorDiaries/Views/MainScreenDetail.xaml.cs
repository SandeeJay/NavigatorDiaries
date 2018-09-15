using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using NavigatorDiaries;

namespace NavigatorDiaries.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MainScreenDetail : TabbedPage
    {

        public MainScreenDetail()
        {
            Children.Add(new TripPlanner());  
            Children.Add(new CreateFAB());
            Children.Add(new Search());
            InitializeComponent();
           
        }
    }

    
}

