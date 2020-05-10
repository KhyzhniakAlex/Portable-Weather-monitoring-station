using System;

namespace WeatherAnalyzerServer.Models
{
    public class PressureForDays : Base
    {
        public DateTime Date { get; set; }

        public double PressureValueForDay { get; set; }

        public double PressureValueForNight { get; set; }
    }
}