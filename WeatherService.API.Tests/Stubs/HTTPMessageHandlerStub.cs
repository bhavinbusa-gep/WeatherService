using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using WeatherService.BusinessEntities;

namespace WeatherService.API.Tests
{
    public class HTTPMessageHandlerStub : HttpMessageHandler
    {
        protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            string path = "http://api.openweathermap.org/data/2.5/weather?id=1275339&units=metric&appid=aa69195559bd4f88d79f9aadeb77a8f6";
            var outputObject = "";

            if (path.Equals(request.RequestUri.AbsoluteUri))
            {
                outputObject = "{\"coord\":{\"lon\":72.85,\"lat\":19.01},\"weather\":[{\"id\":721,\"main\":\"Haze\",\"description\":\"haze\",\"icon\":\"50d\"}],\"base\":\"stations\",\"main\":{\"temp\":33.51,\"feels_like\":33.77,\"temp_min\":33,\"temp_max\":34,\"pressure\":1008,\"humidity\":46},\"visibility\":5000,\"wind\":{\"speed\":5.1,\"deg\":280},\"clouds\":{\"all\":40},\"dt\":1605346247,\"sys\":{\"type\":1,\"id\":9052,\"country\":\"IN\",\"sunrise\":1605316536,\"sunset\":1605357044},\"timezone\":19800,\"id\":1275339,\"name\":\"Mumbai\",\"cod\":200}";
            }

            var responseMessage = new HttpResponseMessage(HttpStatusCode.OK)
            {
                Content = new StringContent(outputObject)
            };

            return await Task.FromResult(responseMessage);
        }
    }
}
