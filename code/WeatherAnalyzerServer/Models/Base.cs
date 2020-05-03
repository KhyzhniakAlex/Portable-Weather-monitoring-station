using System;

namespace WeatherAnalyzerServer.Models
{
    public abstract class Base
    {
        public int Id { get; set; }

        public Guid ControllerId { get; set; }
    }
}