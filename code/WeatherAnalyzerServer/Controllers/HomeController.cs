using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WeatherAnalyzerServer.Controllers
{
    public class HomeController : Controller
    {
        public string Index()
        {
            return "It's a Weather Analyzer Server";
        }
    }
}