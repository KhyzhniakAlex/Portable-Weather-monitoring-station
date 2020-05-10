namespace WeatherAnalyzerServer.Models
{
    public class HumidityForHours : Base
    {
        public string Hour { get; set; }

        public double HumidityValue { get; set; }
    }
}