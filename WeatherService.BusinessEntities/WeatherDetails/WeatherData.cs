using System;
using System.Collections.Generic;
using System.Text;

namespace WeatherService.BusinessEntities
{
    public class WeatherData
    {
        #region Properties

        public string Title { get; set; }
        public Coord Coord { get; set; }
        public List<Weather> Weather { get; set; }
        public string Base { get; set; }
        public Main Main { get; set; }
        public long Visibility { get; set; }
        public Wind Wind { get; set; }
        public Clouds Clouds { get; set; }
        public long Dt { get; set; }
        public Sys Sys { get; set; }
        public long Id { get; set; }
        public long Cod { get; set; }

        #endregion
    }
}
