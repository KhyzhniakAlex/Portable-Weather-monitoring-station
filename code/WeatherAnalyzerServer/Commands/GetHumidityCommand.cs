using System.Threading.Tasks;
using Telegram.Bot;
using Telegram.Bot.Types;

namespace WeatherAnalyzerServer.Commands
{
    public class GetHumidityCommand : Command
    {
        public override string Name => "get_humidity";

        public override async Task<Message> Execute(Message message, TelegramBotClient client)
        {
            var chatId = message.Chat.Id;
            var messageId = message.MessageId;

            //TODO: Command logic
            return null;
        }
    }
}