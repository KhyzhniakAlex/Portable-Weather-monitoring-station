using System.Collections.Generic;
using System.Threading.Tasks;
using Telegram.Bot;
using WeatherAnalyzerServer.Models.Commands;

namespace WeatherAnalyzerServer.Models
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
                new HelloCommand()
            };

            //TODO: Add more commands

            client = new TelegramBotClient(AppSettings.Key);
            var hook = AppSettings.Url + "/api/message/update";
            await client.SetWebhookAsync(hook);

            return client;
        }
    }
}