using System.Web.Mvc;

namespace WeatherAnalyzerServer.Controllers
{
    public class HomeController : Controller
    {
        public string Index()
        {
            double? temperature = SensorDataController.Temperature;
            double? humidity = SensorDataController.Humidity;
            double? pressure = SensorDataController.Pressure;
            double? heatIndex = SensorDataController.HeatIndex;
            return temperature != null && humidity != null && pressure != null && heatIndex != null
                ? string.Format("temperature = {0}\n\n humidity = {1}\n\n pressure = {2}\n\n heatIndex = {3}", 
                    temperature.ToString(),
                    humidity.ToString(),
                    pressure.ToString(),
                    heatIndex.ToString())
                : "It's a Weather Analyzer Server";
        }
    }
}