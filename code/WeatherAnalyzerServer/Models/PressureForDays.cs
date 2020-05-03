namespace WeatherAnalyzerServer.Models
{
    public class PressureForDays
    {
        public string Hour { get; set; }

        public double PressureValueForDay { get; set; }

        public double PressureValueForNight { get; set; }
    }
}