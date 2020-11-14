using System.Threading.Tasks;
using WeatherService.BusinessEntities;

namespace WeatherService.BusinessObjects.Interface
{
    public interface IGetWeatherDetailManager
    {
        Task<WeatherData> GetWeatherDetailByCityId(long cityId);
    }
}
