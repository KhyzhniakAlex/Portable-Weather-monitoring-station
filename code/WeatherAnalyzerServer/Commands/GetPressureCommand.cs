using System.Threading.Tasks;
using System.Configuration;
using StackExchange.Redis;
using System;
using Telegram.Bot;
using Telegram.Bot.Types;

namespace WeatherAnalyzerServer.Commands
{
    public class GetPressureCommand : Command
    {
        public override string Name => "get_pressure";

        private static Lazy<ConnectionMultiplexer> lazyConnection = new Lazy<ConnectionMultiplexer>(() =>
        {
            string cacheConnection = ConfigurationManager.AppSettings["CacheConnection"].ToString();
            return ConnectionMultiplexer.Connect(cacheConnection);
        });

        public override async Task<Message> Execute(Message message, TelegramBotClient client)
        {
            IDatabase cache = lazyConnection.Value.GetDatabase();

            string pressure = cache.StringGet("Pressure").ToString();
            string returnMsg = pressure != "(nil)" && pressure != null
                ? string.Format("Current pressure = {0}mm Hg", pressure)
                : "Error. Some problems with sensor";

            return await client.SendTextMessageAsync(message.Chat.Id, returnMsg);
        }
    }
}