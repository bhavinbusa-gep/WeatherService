using System;
using System.Collections.Generic;
using System.Text;

namespace WeatherService.BusinessEntities
{
    public class Sys
    {
        #region Properties

        public int type { get; set; }
        public int id { get; set; }
        public string country { get; set; }
        public int sunrise { get; set; }
        public int sunset { get; set; }

        #endregion
    }
}
