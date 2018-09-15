using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;

using Xamarin.Forms;

namespace NavigatorDiaries.Views
{
    public class RecentTheme : ContentPage
    {
        public ObservableCollection<SearchVM> EnViews { get; set; }
        public RecentTheme()
        {

            EnViews = new ObservableCollection<SearchVM>();
            ListView lstView = new ListView
            {
                RowHeight = 60
            };
            this.Title = "Resent Journal Entities";
            lstView.ItemTemplate = new DataTemplate(typeof(CustomEntityCell));
            EnViews.Add(new SearchVM { Titel = "Tomato", Details = "Fruit", Image = "tomato.png" });
            EnViews.Add(new SearchVM { Titel = "Romaine Lettuce", Details = "Vegetable", Image = "lettuce.png" });
            EnViews.Add(new SearchVM { Titel = "Zucchini", Details = "Vegetable", Image = "zucchini.png" });
            lstView.ItemsSource = EnViews;
            Content = lstView;
        }

        public class CustomEntityCell : ViewCell
        {
            public CustomEntityCell()
            {
                //instantiate each of our views
                var image = new Image();
                var nameLabel = new Label();
                var typeLabel = new Label();
                var verticaLayout = new StackLayout();
                var horizontalLayout = new StackLayout() { BackgroundColor = Color.Olive };

                //set bindings
                nameLabel.SetBinding(Label.TextProperty, new Binding("Name"));
                typeLabel.SetBinding(Label.TextProperty, new Binding("Type"));
                image.SetBinding(Image.SourceProperty, new Binding("Image"));

                //Set properties for desired design
                horizontalLayout.Orientation = StackOrientation.Horizontal;
                horizontalLayout.HorizontalOptions = LayoutOptions.Fill;
                image.HorizontalOptions = LayoutOptions.End;
                nameLabel.FontSize = 24;

                //add views to the view hierarchy
                verticaLayout.Children.Add(nameLabel);
                verticaLayout.Children.Add(typeLabel);
                horizontalLayout.Children.Add(verticaLayout);
                horizontalLayout.Children.Add(image);

                // add to parent view
                View = horizontalLayout;
            }
        }
    }

}