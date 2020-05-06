using System.Web.Mvc;
using System.Configuration;
using StackExchange.Redis;
using System;

namespace WeatherAnalyzerServer.Controllers
{
    public class HomeController : Controller
    {
        private static Lazy<ConnectionMultiplexer> lazyConnection = new Lazy<ConnectionMultiplexer>(() =>
        {
            string cacheConnection = ConfigurationManager.AppSettings["CacheConnection"].ToString();
            return ConnectionMultiplexer.Connect(cacheConnection);
        });

        public string Index()
        {
            IDatabase cache = lazyConnection.Value.GetDatabase();

            string temperature = cache.StringGet("Temperature").ToString();
            string humidity = cache.StringGet("Humidity").ToString();
            string pressure = cache.StringGet("Pressure").ToString();
            string heatIndex = cache.StringGet("HeatIndex").ToString();

            return (temperature != "(nil)" && temperature != null)
                && (humidity != "(nil)" && humidity != null)
                && (pressure != "(nil)" && pressure != null)
                && (heatIndex != "(nil)" && heatIndex != null)
                ? string.Format("temperature = {0} humidity = {1} pressure = {2} heatIndex = {3}", 
                    temperature,
                    humidity,
                    pressure,
                    heatIndex)
                : "It's a Weather Analyzer Server";
        }
    }
}