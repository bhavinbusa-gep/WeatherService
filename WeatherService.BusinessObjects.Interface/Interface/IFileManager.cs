using System.Collections.Generic;
using System.Threading.Tasks;
using WeatherService.BusinessEntities;

namespace WeatherService.BusinessObjects.Interface
{
    public interface IFileManager
    {
        void SaveWeatherDetails(WeatherData WeatherData , string cityName);

        List<WeatherDetail> ReadWeatherDetails();
    }
}
