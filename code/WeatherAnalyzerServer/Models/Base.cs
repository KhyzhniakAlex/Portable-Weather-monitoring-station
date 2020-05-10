using System;

namespace WeatherAnalyzerServer.Models
{
    public abstract class Base
    {
        public Guid ControllerId { get; set; }
    }
}