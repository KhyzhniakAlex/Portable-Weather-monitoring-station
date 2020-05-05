using System.Threading.Tasks;
using Telegram.Bot;
using Telegram.Bot.Types;
using WeatherAnalyzerServer.Controllers;

namespace WeatherAnalyzerServer.Commands
{
    public class GetHeatIndexCommand : Command
    {
        public override string Name => "get_heat_index";

        public override async Task<Message> Execute(Message message, TelegramBotClient client)
        {
            double ? heatIndex = SensorDataController.HeatIndex;
            string returnMsg = heatIndex != null
                ? string.Format("Current heatIndex = {0}℃", heatIndex)
                : "Error. Some problems with sensor";

            return await client.SendTextMessageAsync(message.Chat.Id, returnMsg);
        }
    }
}