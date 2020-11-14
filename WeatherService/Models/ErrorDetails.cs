using Newtonsoft.Json;

namespace WeatherService.API.Models
{
    public class ErrorDetails
    {
        #region Properties

        public int StatusCode { get; set; }
        public string Message { get; set; }
        public string Stacktrace { get; set; }
        public string Source { get; set; }

        #endregion

        public override string ToString()
        {
            return JsonConvert.SerializeObject(this);
        }
    }
}
