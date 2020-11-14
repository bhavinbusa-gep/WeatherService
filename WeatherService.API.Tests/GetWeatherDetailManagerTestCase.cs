using Moq;
using NUnit.Framework;
using System.Net.Http;
using WeatherService.API.Tests;
using WeatherService.BusinessObjects;
using WeatherService.BusinessObjects.Interface;

namespace WeatherService.API
{
    public class GetWeatherDetailManagerTestCase
    {
        private HttpClient objHttpClient = new HttpClient(new HTTPMessageHandlerStub());
        private GetWeatherDetailManager objGetWeatherDetailManager = null;

        #region Constrructor

        public GetWeatherDetailManagerTestCase()
        {
            objGetWeatherDetailManager = new GetWeatherDetailManager(objHttpClient);
        }

        #endregion

        [Test]
        public void ConnectToClientUnitTest()
        {
            long cityId = 1275339;
            var result = objGetWeatherDetailManager.GetWeatherDetailByCityId(cityId);
            Assert.NotNull(result);
        }
    }
}
