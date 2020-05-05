using System.Threading.Tasks;
using Telegram.Bot;
using Telegram.Bot.Types;
using WeatherAnalyzerServer.Controllers;

namespace WeatherAnalyzerServer.Commands
{
    public class GetTemperatureCommand : Command
    {
        public override string Name => "get_temperature";

        public override async Task<Message> Execute(Message message, TelegramBotClient client)
        {
            double? temperature = SensorDataController.Temperature;
            string returnMsg = temperature != null 
                ? string.Format("Current temperature = {0}℃", temperature) 
                : "Error. Some problems with sensor";

            return await client.SendTextMessageAsync(message.Chat.Id, returnMsg);
        }
    }
}