using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using MyWeatherApp.Repository;

namespace MyWeatherApp
{
    public partial class MainPage : ContentPage
    {
        IWeatherService weatherService;
        public MainPage()
        {            
            InitializeComponent();

            if (weatherService == null)
                weatherService = new WeatherService(); 
        }

        private async void getWeather_Clicked(object sender, EventArgs e)
        {
            //await DisplayAlert("MyWeatherApp" , "Looking up for weather for: " + cityName.Text, "Ok");

            var weather = await weatherService.GetCurrentWeatherAsync(cityName.Text);

            if (weather == null)
            {
                await DisplayAlert("MyWeatherApp", "Could not get weather, please try again!", "Ok");
                return;
            }
            if (weather.main == null)
            {
                await DisplayAlert("MyWeatherApp", "Could not get weather, please try again!", "Ok");
                return;
            }
            cityTemp.Text = weather.main.temp.ToString();
        }
    }
}
