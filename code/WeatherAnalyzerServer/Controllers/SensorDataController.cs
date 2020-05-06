using System.Net.Http;
using System.Web.Http;
using System.Net;
using WeatherAnalyzerServer.Models;
using System;
using System.Configuration;
using StackExchange.Redis;

namespace WeatherAnalyzerServer.Controllers
{
    [RoutePrefix("api/[controller]")]
    public class SensorDataController : ApiController
    {
        private static Lazy<ConnectionMultiplexer> lazyConnection = new Lazy<ConnectionMultiplexer>(() =>
        {
            string cacheConnection = ConfigurationManager.AppSettings["CacheConnection"].ToString();
            return ConnectionMultiplexer.Connect(cacheConnection);
        });

        [HttpPost]
        public HttpResponseMessage GetSensorData(SensorsData data)
        {
            try
            {
                IDatabase cache = lazyConnection.Value.GetDatabase();

                if (data != null)
                {
                    cache.StringSet("Temperature", Math.Round((data.TemperatureDHT + data.TemperatureBMP) / 2.0, 2));
                    cache.StringSet("Humidity", Math.Round(data.Humidity, 2));
                    cache.StringSet("Pressure", Math.Round(data.Pressure, 2));
                    cache.StringSet("HeatIndex", Math.Round(data.HeatIndex, 2));

                    //cache.KeyExpire("Temperature", new TimeSpan(24, 0, 0));
                    //cache.KeyExpire("Humidity", new TimeSpan(24, 0, 0));
                    //cache.KeyExpire("Pressure", new TimeSpan(24, 0, 0));
                    //cache.KeyExpire("HeatIndex", new TimeSpan(24, 0, 0));
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