using System;
using System.ComponentModel.DataAnnotations;

namespace WeatherAnalyzerServer.Models
{
    public abstract class Base
    {
        [Key]
        public int Id { get; set; }

        public Guid ControllerId { get; set; }
    }
}