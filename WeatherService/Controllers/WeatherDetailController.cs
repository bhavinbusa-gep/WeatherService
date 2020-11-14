using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using WeatherService.BusinessObjects.Interface;

namespace WeatherService.API.Controllers
{
    [ApiController]
    [Route("/api/forecast")]
    public class WeatherDetailController : Controller
    {
        #region Members

        private readonly IGetWeatherDetailManager _getWeatherDetailManager;
        private readonly IFileManager _fileManager;

        #endregion

        #region Constructor

        public WeatherDetailController(
            IGetWeatherDetailManager getWeatherDetailManager,
            IFileManager fileManager
            )
        {
            _getWeatherDetailManager = getWeatherDetailManager;
            _fileManager = fileManager;
        }

        #endregion

        #region ReadWeatherDetails

        [HttpPost]
        [Route("ReadWeatherDetails")]
        public async Task<IActionResult> ReadWeatherDetails()
        {
            var lstfileDetails = _fileManager.ReadWeatherDetails();

            if (lstfileDetails.Count > 0)
            {
                foreach (var filedetail in lstfileDetails)
                {
                    var weatherData = await _getWeatherDetailManager.GetWeatherDetailByCityId(filedetail.cityID);
                    _fileManager.SaveWeatherDetails(weatherData, filedetail.cityName);
                }
            }

            return Ok();
        }

        #endregion
    }
}
