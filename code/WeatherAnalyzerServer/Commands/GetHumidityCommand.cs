using System.Threading.Tasks;
using Telegram.Bot;
using System.Configuration;
using StackExchange.Redis;
using System;
using Telegram.Bot.Types;

namespace WeatherAnalyzerServer.Commands
{
    public class GetHumidityCommand : Command
    {
        public override string Name => "get_humidity";

        private static Lazy<ConnectionMultiplexer> lazyConnection = new Lazy<ConnectionMultiplexer>(() =>
        {
            string cacheConnection = ConfigurationManager.AppSettings["CacheConnection"].ToString();
            return ConnectionMultiplexer.Connect(cacheConnection);
        });

        public override async Task<Message> Execute(Message message, TelegramBotClient client)
        {
            IDatabase cache = lazyConnection.Value.GetDatabase();

            string humidity = cache.StringGet("Humidity").ToString();
            string returnMsg = humidity != "(nil)" && humidity != null
                ? string.Format("Current humidity = {0}%", humidity)
                : "Error. Some problems with sensor";

            return await client.SendTextMessageAsync(message.Chat.Id, returnMsg);
        }
    }
}