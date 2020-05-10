namespace WeatherAnalyzerServer.Models
{
    public class TemperatureForHours : Base
    {
        public string Hour { get; set; }

        public double TemperatureValue { get; set; }
    }
}