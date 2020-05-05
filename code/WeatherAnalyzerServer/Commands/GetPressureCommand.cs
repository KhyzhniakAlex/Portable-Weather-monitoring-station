using System.Threading.Tasks;
using Telegram.Bot;
using Telegram.Bot.Types;
using WeatherAnalyzerServer.Controllers;

namespace WeatherAnalyzerServer.Commands
{
    public class GetPressureCommand : Command
    {
        public override string Name => "get_pressure";

        public override async Task<Message> Execute(Message message, TelegramBotClient client)
        {
            double? pressure = SensorDataController.Pressure;
            string returnMsg = pressure != null
                ? string.Format("Current pressure = {0}mm Hg", pressure)
                : "Error. Some problems with sensor";

            return await client.SendTextMessageAsync(message.Chat.Id, returnMsg);
        }
    }
}