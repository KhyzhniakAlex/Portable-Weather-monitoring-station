﻿using System.Web.Http;
using System.Web.Http.Results;
using WeatherAnalyzerServer.Services;
using Telegram.Bot.Types;
using System.Threading.Tasks;

namespace WeatherAnalyzerServer.Controllers
{
    public class MessageController : ApiController
    {
        [Route(@"api/message/update")] //webhook uri part
        public async Task<OkResult> Update([FromBody] Update update)
        {
            var commands = Bot.Commands;
            var message = update.Message;
            var client = await Bot.GetClient();

            foreach (var command in commands)
            {
                if (command.Contains(message.Text))
                {
                    await command.Execute(message, client);
                    break;
                }
            }
            return Ok();
        }
    }
}
