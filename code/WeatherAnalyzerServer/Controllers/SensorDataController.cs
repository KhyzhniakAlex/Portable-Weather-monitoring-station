using System.Web.Http;
using System.Web.Http.Results;
using WeatherAnalyzerServer.Models;

namespace WeatherAnalyzerServer.Controllers
{
    public class SensorDataController : ApiController
    {
        public static double? Temperature { get; set; }
        public static double? Humidity { get; set; }
        public static double? HeatIndex { get; set; }
        public static double? Pressure { get; set; }

        [HttpPost]
        [Route("getSensorData")]
        public OkResult GetSensorData(SensorsData data)
        {
            if (data != null)
            {
                Temperature = (data.TemperatureDHT + data.TemperatureBMP) / 2.0;
                Humidity = data.Humidity;
                HeatIndex = data.HeatIndex;
                Pressure = data.Pressure;
            }
            return Ok();
        }
    }
}