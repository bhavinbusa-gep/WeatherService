using System;
using System.Collections.Generic;
using System.Text;

namespace WeatherService.BusinessEntities
{
    public class Weather
    {
        #region Properties

        public int id { get; set; }
        public string main { get; set; }
        public string description { get; set; }
        public string icon { get; set; }

        #endregion
    }
}
