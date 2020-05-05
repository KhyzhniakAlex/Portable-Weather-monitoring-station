using System.Threading.Tasks;
using Telegram.Bot;
using Telegram.Bot.Types;

namespace WeatherAnalyzerServer.Commands
{
    public class HelloCommand : Command
    {
        public override string Name => "hello";

        public override async Task<Message> Execute(Message message, TelegramBotClient client)
        {
            //TODO: Command logic
            return await client.SendTextMessageAsync(message.Chat.Id, "Hello from Server!");
        }
    }
}