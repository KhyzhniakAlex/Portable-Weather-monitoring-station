namespace WeatherAnalyzerServer.Models
{
    public class TemperatureForDays
    {
        public string Hour { get; set; }

        public double TemperatureValueForDay { get; set; }

        public double TemperatureValueForNight { get; set; }
    }
}