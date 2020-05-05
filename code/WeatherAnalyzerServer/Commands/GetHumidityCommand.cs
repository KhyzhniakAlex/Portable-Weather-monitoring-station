using System.Threading.Tasks;
using Telegram.Bot;
using Telegram.Bot.Types;
using WeatherAnalyzerServer.Controllers;

namespace WeatherAnalyzerServer.Commands
{
    public class GetHumidityCommand : Command
    {
        public override string Name => "get_humidity";

        public override async Task<Message> Execute(Message message, TelegramBotClient client)
        {
            double? humidity = SensorDataController.Humidity;
            string returnMsg = humidity != null
                ? string.Format("Current humidity = {0}%", humidity)
                : "Error. Some problems with sensor";

            return await client.SendTextMessageAsync(message.Chat.Id, returnMsg);
        }
    }
}