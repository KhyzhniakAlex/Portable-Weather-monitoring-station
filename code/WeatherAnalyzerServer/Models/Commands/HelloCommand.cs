using System.Threading.Tasks;
using Telegram.Bot;
using Telegram.Bot.Types;

namespace WeatherAnalyzerServer.Models.Commands
{
    public class HelloCommand : Command
    {
        public override string Name => "hello";

        public override async Task<Message> Execute(Message message, TelegramBotClient client)
        {
            var chatId = message.Chat.Id;
            var messageId = message.MessageId;

            //TODO: Command logic

            return await client.SendTextMessageAsync(chatId, "Hello from Server!", replyToMessageId: messageId);
        }
    }
}