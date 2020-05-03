using System.Data.Entity;
using WeatherAnalyzerServer.Models;

namespace WeatherAnalyzerServer.Services
{
    [DbConfigurationType(typeof(MySql.Data.Entity.MySqlEFConfiguration))]
    public class WeatherContext : DbContext
    {
        public WeatherContext() : base("conn")
        { }

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