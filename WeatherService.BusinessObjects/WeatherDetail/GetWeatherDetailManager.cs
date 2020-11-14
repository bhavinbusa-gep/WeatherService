using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Threading.Tasks;
using WeatherService.BusinessEntities;
using WeatherService.BusinessObjects.Interface;

namespace WeatherService.BusinessObjects
{
    public class GetWeatherDetailManager : IGetWeatherDetailManager
    {
        #region Members

        private const string URL = "http://api.openweathermap.org/data/2.5/";
        private const string APIKEY = "&appid=aa69195559bd4f88d79f9aadeb77a8f6";
        private const string MetricUnits = "&units=metric";
        private WeatherData weatherData = new WeatherData();
        private HttpClient _client;

        #endregion

        #region Constructor

        public GetWeatherDetailManager(HttpClient httpClinet)
        {
            _client = httpClinet;
        }

        #endregion

        #region GetWeatherDetailByCityId

        public async Task<WeatherData> GetWeatherDetailByCityId(long cityId)
        {
            string weatherForCity = $"weather?id={cityId}";
            string path = URL + weatherForCity + MetricUnits + APIKEY;
            weatherData = await ConnectToClient(path);
            return weatherData;
        }

        #endregion

        #region ConnectToClient

        private async Task<WeatherData> ConnectToClient(string path)
        {
            using (HttpResponseMessage res = await _client.GetAsync(path))
            {
                using (HttpContent content = res.Content)
                {
                    var response = await content.ReadAsStringAsync();
                    if (response.Contains("404").Equals(true))
                    {
                        throw new Exception("No data found, wrong input ?");
                    }
                    else
                    {
                        weatherData = JsonConvert.DeserializeObject<WeatherData>(response);
                    }
                }
            }

            return weatherData;
        }

        #endregion
    }
}
