namespace WeatherAnalyzerServer.Models
{
    public class HeatIndexForDays
    {
        public string Hour { get; set; }

        public double HeatIndexValueForDay { get; set; }

        public double HeatIndexValueForNight { get; set; }
    }
}