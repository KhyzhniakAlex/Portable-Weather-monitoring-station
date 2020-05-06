using System.Threading.Tasks;
using System.Configuration;
using StackExchange.Redis;
using Telegram.Bot;
using Telegram.Bot.Types;
using System;

namespace WeatherAnalyzerServer.Commands
{
    public class GetHeatIndexCommand : Command
    {
        public override string Name => "get_heat_index";

        private static Lazy<ConnectionMultiplexer> lazyConnection = new Lazy<ConnectionMultiplexer>(() =>
        {
            string cacheConnection = ConfigurationManager.AppSettings["CacheConnection"].ToString();
            return ConnectionMultiplexer.Connect(cacheConnection);
        });

        public override async Task<Message> Execute(Message message, TelegramBotClient client)
        {
            IDatabase cache = lazyConnection.Value.GetDatabase();

            string heatIndex = cache.StringGet("HeatIndex").ToString();
            string returnMsg = heatIndex != null && heatIndex != "(nil)"
                ? string.Format("Current heatIndex = {0}℃", heatIndex)
                : "Error. Some problems with sensor";

            return await client.SendTextMessageAsync(message.Chat.Id, returnMsg);
        }
    }
}