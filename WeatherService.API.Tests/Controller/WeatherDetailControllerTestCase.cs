using Moq;
using Newtonsoft.Json;
using NUnit.Framework;
using System.Collections.Generic;
using WeatherService.API.Controllers;
using WeatherService.BusinessEntities;
using WeatherService.BusinessObjects.Interface;

namespace WeatherService.API.Tests
{
    public class WeatherDetailControllerTestCase
    {
        #region Members

        private readonly Mock<IGetWeatherDetailManager> _mockIGetWeatherDetailManager = null;
        private readonly Mock<IFileManager> _mockFileManager = null;
        private WeatherDetailController _weatherDetailController;

        #endregion

        #region Constructor

        public WeatherDetailControllerTestCase()
        {
            _mockIGetWeatherDetailManager = new Mock<IGetWeatherDetailManager>();
            _mockFileManager = new Mock<IFileManager>();
        }

        #endregion

        #region ReadWeatherDetails

        [Test]
        public void ReadWeatherDetails()
        {
            WeatherData objWeatherData = new WeatherData();
            List<WeatherDetail> lstWeatherDetail = new List<WeatherDetail>
            {
                new WeatherDetail { cityID = 1275339, cityName="Mumbai" },
                new WeatherDetail { cityID = 1259229, cityName="Pune"}
            };

            var outputObject = "{\"coord\":{\"lon\":72.85,\"lat\":19.01},\"weather\":[{\"id\":721,\"main\":\"Haze\",\"description\":\"haze\",\"icon\":\"50d\"}],\"base\":\"stations\",\"main\":{\"temp\":33.51,\"feels_like\":33.77,\"temp_min\":33,\"temp_max\":34,\"pressure\":1008,\"humidity\":46},\"visibility\":5000,\"wind\":{\"speed\":5.1,\"deg\":280},\"clouds\":{\"all\":40},\"dt\":1605346247,\"sys\":{\"type\":1,\"id\":9052,\"country\":\"IN\",\"sunrise\":1605316536,\"sunset\":1605357044},\"timezone\":19800,\"id\":1275339,\"name\":\"Mumbai\",\"cod\":200}";
            objWeatherData = JsonConvert.DeserializeObject<WeatherData>(outputObject);

            _mockFileManager.Setup(s => s.ReadWeatherDetails()).Returns(lstWeatherDetail);
            _mockIGetWeatherDetailManager.Setup(s => s.GetWeatherDetailByCityId(It.IsAny<long>())).ReturnsAsync(objWeatherData);
            _mockFileManager.Setup(s => s.SaveWeatherDetails(It.IsAny<WeatherData>(), It.IsAny<string>()));

            _weatherDetailController = new WeatherDetailController(_mockIGetWeatherDetailManager.Object, _mockFileManager.Object);
            var result = _weatherDetailController.ReadWeatherDetails();
            Assert.NotNull(result);
        }

        #endregion
    }
}