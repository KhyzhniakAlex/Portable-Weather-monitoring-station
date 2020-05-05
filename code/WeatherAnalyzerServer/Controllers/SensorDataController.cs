using System.Net.Http;
using System.Web.Http;
using System.Net;
using WeatherAnalyzerServer.Models;
using System;

namespace WeatherAnalyzerServer.Controllers
{
    [RoutePrefix("api/[controller]")]
    public class SensorDataController : ApiController
    {
        public static double? Temperature { get; set; }
        public static double? Humidity { get; set; }
        public static double? HeatIndex { get; set; }
        public static double? Pressure { get; set; }

        [HttpPost]
        public HttpResponseMessage GetSensorData(SensorsData data)
        {
            try
            {
                if (data != null)
                {
                    Temperature = Math.Round((data.TemperatureDHT + data.TemperatureBMP) / 2.0, 2);
                    Humidity = Math.Round(data.Humidity, 2);
                    HeatIndex = Math.Round(data.HeatIndex, 2);
                    Pressure = Math.Round(data.Pressure, 2);
                }
                return Request.CreateResponse(HttpStatusCode.OK);
            } 
            catch(Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, ex.Message);
            }
        }
    }
}