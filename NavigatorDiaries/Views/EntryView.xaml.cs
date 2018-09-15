using Plugin.TextToSpeech;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;


namespace NavigatorDiaries.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class EntryView : ContentPage
    {
        public EntryView()
        {
            InitializeComponent();

        }

        async void DeleteEntry(object sender, EventArgs e)
        {
            var EntryItem = (JournaEntrylItems)BindingContext;
            await App.Database1.DeleteItemAsync(EntryItem);
            await Navigation.PopAsync();
        }

        
        public void  StoryOnClicked(object sender, EventArgs e)
        {
            try
            {

                CrossTextToSpeech.Current.Speak("Once upon a time" + Title, null, 1.25f, 0.80f, 1.0f, default(CancellationToken));                
                CrossTextToSpeech.Current.Speak(DateL.Text+TimeL.Text,null,1.25f,0.80f,1.0f, default(CancellationToken));
                CrossTextToSpeech.Current.Speak(EmotionL.Text+"Day And" + WeatherL.Text+"Weather", null, 1.25f, 0.80f, 1.0f, default(CancellationToken));
                CrossTextToSpeech.Current.Speak(EntryDes.Text, null, 1.25f, 0.80f, 1.0f, default(CancellationToken));
            }

            catch (Exception q)
            {
                Console.WriteLine(q);

            }

        }


    }
}