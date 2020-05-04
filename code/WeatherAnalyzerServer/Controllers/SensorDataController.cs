using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using WeatherAnalyzerServer.Models;

namespace WeatherAnalyzerServer.Controllers
{
    public class SensorDataController
    {
        private double Temperature { get; set; }
        private double Humidity { get; set; }
        private double HeatIndex { get; set; }
        private double Pressure { get; set; }

        [HttpPost]
        [Route("getSensorData")]
        public void GetSensorData(SensorsData data)
        {
            if (data != null)
            {
                Temperature = (data.TemperatureDHT + data.TemperatureBMP) / 2.0;
                Humidity = data.Humidity;
                HeatIndex = data.HeatIndex;
                Pressure = data.Pressure;
            }
        }

        public double GetTemperature()
        {
            return Temperature;
        }
    }
}