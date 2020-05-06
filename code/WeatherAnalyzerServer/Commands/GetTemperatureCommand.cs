using System;
using System.Threading.Tasks;
using System.Configuration;
using StackExchange.Redis;
using Telegram.Bot;
using Telegram.Bot.Types;

namespace WeatherAnalyzerServer.Commands
{
    public class GetTemperatureCommand : Command
    {
        public override string Name => "get_temperature";

        private static Lazy<ConnectionMultiplexer> lazyConnection = new Lazy<ConnectionMultiplexer>(() =>
        {
            string cacheConnection = ConfigurationManager.AppSettings["CacheConnection"].ToString();
            return ConnectionMultiplexer.Connect(cacheConnection);
        });

        public override async Task<Message> Execute(Message message, TelegramBotClient client)
        {
            IDatabase cache = lazyConnection.Value.GetDatabase();

            string temperature = cache.StringGet("Temperature").ToString();
            string returnMsg = temperature != "(nil)" && temperature != null
                ? string.Format("Current temperature = {0}℃", temperature) 
                : "Error. Some problems with sensor";

            return await client.SendTextMessageAsync(message.Chat.Id, returnMsg);
        }
    }
}