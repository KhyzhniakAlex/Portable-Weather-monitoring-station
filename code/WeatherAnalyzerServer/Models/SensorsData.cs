namespace WeatherAnalyzerServer.Models
{
    public class SensorsData
    {
        public double TemperatureDHT { get; set; }
        public double Humidity { get; set; }
        public double HeatIndex { get; set; }
        public double Pressure { get; set; }
        public double TemperatureBMP { get; set; }
    }
}