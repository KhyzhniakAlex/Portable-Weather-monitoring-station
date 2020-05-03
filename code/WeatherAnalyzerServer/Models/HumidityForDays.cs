namespace WeatherAnalyzerServer.Models
{
    public class HumidityForDays
    {
        public string Hour { get; set; }

        public double HumidityValueForDay { get; set; }

        public double HumidityValueForNight { get; set; }
    }
}