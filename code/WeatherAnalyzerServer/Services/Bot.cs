using System.Collections.Generic;
using System.Threading.Tasks;
using Telegram.Bot;
using WeatherAnalyzerServer.Commands;
using WeatherAnalyzerServer.Models;

namespace WeatherAnalyzerServer.Services
{
    public static class Bot
    {
        private static TelegramBotClient client;
        private static List<Command> commandList;

        public static IReadOnlyList<Command> Commands => commandList.AsReadOnly();

        public static async Task<TelegramBotClient> GetClient()
        {
            if (client != null)
            {
                return client;
            }

            commandList = new List<Command>
            {
                new HelloCommand(),
                new GetTemperatureCommand(),
                new GetHumidityCommand(),
                new GetPressureCommand(),
                new GetHeatIndexCommand(),
                new TemperatureChartForDaysCommand(),
                new HumidityChartForDaysCommand(),
                new PressureChartForDaysCommand(),
                new HeatIndexChartForDaysCommand(),
                new HeatIndexHelperChartCommand(),
                new RainfallChanceFor12HoursChartCommand(),
                new HeatIndexFor12HoursChartCommand()
            };

            client = new TelegramBotClient(AppSettings.Key);
            var hook = AppSettings.Url + "/api/message/update";
            await client.SetWebhookAsync(hook);

            return client;
        }
    }
}