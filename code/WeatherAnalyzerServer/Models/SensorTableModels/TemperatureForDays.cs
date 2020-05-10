using System;

namespace WeatherAnalyzerServer.Models
{
    public class TemperatureForDays : Base
    {
        public DateTime Date { get; set; }

        public double TemperatureValueForDay { get; set; }

        public double TemperatureValueForNight { get; set; }
    }
}