using System.Data.Entity;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Routing;
using WeatherAnalyzerServer.Services;
using System.Web;

namespace WeatherAnalyzerServer
{
    public class MvcApplication : HttpApplication
    {
        protected async void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            GlobalConfiguration.Configure(WebApiConfig.Register);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            await Bot.GetClient();
        }
    }
}
