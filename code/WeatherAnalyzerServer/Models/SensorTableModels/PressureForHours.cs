namespace WeatherAnalyzerServer.Models
{
    public class PressureForHours : Base
    {
        public string Hour { get; set; }

        public double PressureValue { get; set; }
    }
}