using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NavigatorDiaries.Views
{

    public class MainScreenMenuItem
    {
        public MainScreenMenuItem()
        {
            TargetType = typeof(MainScreenDetail);
        }
        public int Id { get; set; }
        public string Title { get; set; }
        public string Icon { get; set; }
        public Type TargetType { get; set; }
    }
}