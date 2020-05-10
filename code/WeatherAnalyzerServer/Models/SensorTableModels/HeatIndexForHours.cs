namespace WeatherAnalyzerServer.Models
{
    public class HeatIndexForHours : Base
    {
        public string Hour { get; set; }

        public double HeatIndexValue { get; set; }
    }
}