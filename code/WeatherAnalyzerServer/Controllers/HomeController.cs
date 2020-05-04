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
                ? temperature.ToString() + humidity.ToString() + pressure.ToString() + heatIndex.ToString()
                : "It's a Weather Analyzer Server";
        }
    }
}