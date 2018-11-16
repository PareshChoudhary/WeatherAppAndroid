using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace MyWeatherApp.Repository
{
    public class WeatherService : IWeatherService
    {


        string weatherURL = @"https://api.openweathermap.org/data/2.5/weather?q={0}&apikey=9a0b331b96eafbb5e30ba0bf0640960a";
        public async Task<WeatherModel> GetCurrentWeatherAsync(string cityName)
        {
            try
            {
                var client = new HttpClient();

                var response = await client.GetAsync(string.Format(weatherURL, cityName));

                var content = await response.Content.ReadAsStringAsync();

                var result = JsonConvert.DeserializeObject<WeatherModel>(content);

                return result;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
