using System.Data.Entity;
using WeatherAnalyzerServer.Models;

namespace WeatherAnalyzerServer.Services
{
    public class WeatherContext : DbContext
    {
        public WeatherContext() : base("DbConnection")
        {
            Database.SetInitializer(new DBInitializer());
            //Database.Initialize(true);
        }


        public DbSet<ControllerLocation> ControllerLocation { get; set; }
        public DbSet<TemperatureForDays> TemperatureForDays { get; set; }
        public DbSet<TemperatureForHours> TemperatureForHours { get; set; }
        public DbSet<HumidityForDays> HumidityForDays { get; set; }
        public DbSet<HumidityForHours> HumidityForHours { get; set; }
        public DbSet<PressureForDays> PressureForDays { get; set; }
        public DbSet<PressureForHours> PressureForHours { get; set; }
        public DbSet<HeatIndexForDays> HeatIndexForDays { get; set; }
        public DbSet<HeatIndexForHours> HeatIndexForHours { get; set; }
    }
}