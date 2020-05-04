using System.Threading.Tasks;
using Telegram.Bot;
using Telegram.Bot.Types;

namespace WeatherAnalyzerServer.Commands
{
    public class GetHeatIndexCommand : Command
    {
        public override string Name => "get_heat_index";

        public override async Task<Message> Execute(Message message, TelegramBotClient client)
        {
            var chatId = message.Chat.Id;
            var messageId = message.MessageId;

            //TODO: Command logic
            return null;
        }
    }
}