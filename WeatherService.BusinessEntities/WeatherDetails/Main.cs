using System;
using System.Collections.Generic;
using System.Text;

namespace WeatherService.BusinessEntities
{
    public class Main
    {
        #region Properties

        public double temp { get; set; }
        public double feels_like { get; set; }
        public decimal temp_min { get; set; }
        public double temp_max { get; set; }
        public int pressure { get; set; }
        public int humidity { get; set; }

        #endregion
    }
}
