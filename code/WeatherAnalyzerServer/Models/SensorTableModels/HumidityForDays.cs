using System;

namespace WeatherAnalyzerServer.Models
{
    public class HumidityForDays : Base
    {
        public DateTime Date { get; set; }

        public double HumidityValueForDay { get; set; }

        public double HumidityValueForNight { get; set; }
    }
}