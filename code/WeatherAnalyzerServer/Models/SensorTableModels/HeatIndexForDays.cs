using System;

namespace WeatherAnalyzerServer.Models
{
    public class HeatIndexForDays : Base
    {
        public DateTime Date { get; set; }

        public double HeatIndexValueForDay { get; set; }

        public double HeatIndexValueForNight { get; set; }
    }
}