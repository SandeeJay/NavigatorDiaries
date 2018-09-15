using System;
using System.Threading.Tasks;

namespace NavigatorDiaries.Views
{
    public class Core
    {
        public static async Task<Weather> GetWeather(string lat,string lon)
        {
            
            string key = "a1d65beade3fdd146d3c799bbea41df2";
            string queryString = "http://api.openweathermap.org/data/2.5/weather?lat="+lat+"&lon="+lon+"&appid=" + key + "&units=metric";

            dynamic results = await DataService.GetDataFromService(queryString).ConfigureAwait(false);

            if (results["weather"] != null)
            {
                Weather weather = new Weather();
                weather.Title = (string)results["name"];
                weather.Temperature = (string)results["main"]["temp"] + " C";
                weather.Wind = (string)results["wind"]["speed"] + " mph";
               // weather.Rain = (string)results["rain"]["3h"];
                weather.Humidity = (string)results["main"]["humidity"] + " %";
                weather.Visibility = (string)results["weather"][0]["main"];
                

                DateTime time = new DateTime(1970, 1, 1, 0, 0, 0, 0);
                DateTime sunrise = time.AddSeconds((double)results["sys"]["sunrise"]);
                DateTime sunset = time.AddSeconds((double)results["sys"]["sunset"]);
                weather.Sunrise = sunrise.ToString() + " UTC";
                weather.Sunset = sunset.ToString() + " UTC";
                return weather;
            }
            else
            {
                return null;
            }
        }
    }
}
