using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using WeatherService.BusinessEntities;
using WeatherService.BusinessObjects.Interface;

namespace WeatherService.BusinessObjects
{
    public class FileManager : IFileManager
    {
        #region Members

        private string FilePath = AppDomain.CurrentDomain.BaseDirectory + @"OutputFolder\";
        private string FileName = DateTime.Now.ToString("yyyyMMddHHmmss").Replace("/", "") + "_" + Guid.NewGuid().ToString().Replace("-", "") + ".json";
        private string InputFilePath = AppDomain.CurrentDomain.BaseDirectory + @"InputFolder\";

        #endregion

        #region SaveWeatherDetails

        public void SaveWeatherDetails(WeatherData WeatherData , string cityName)
        {
            WeatherData objWeatherData = new WeatherData();

            if (WeatherData != null)
            {
                Directory.CreateDirectory(FilePath);
                AddWeatherData(WeatherData, cityName);
            }
        }

        #endregion

        #region AddWeatherData

        public void AddWeatherData(WeatherData weatherDetail, string cityName)
        {
            string path = FilePath + cityName + "_" + FileName;
            using (StreamWriter file = File.CreateText(path))
            {
                JsonSerializer serializer = new JsonSerializer();
                serializer.Serialize(file, weatherDetail);
            }
        }

        #endregion

        #region ReadWeatherDetails

        public List<WeatherDetail> ReadWeatherDetails()
        {
            string jsonFilePath = InputFilePath + @"\myFile.json";
            string json = File.ReadAllText(jsonFilePath);
            List<WeatherDetail> lstweatherDetail = JsonConvert.DeserializeObject<List<WeatherDetail>>(json);

            return lstweatherDetail;
        }

        #endregion
    }
}
