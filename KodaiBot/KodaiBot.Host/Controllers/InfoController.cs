using System;
using System.Threading.Tasks;
using Discord.Commands;
using KodaiBot.BusinessLayer.Commands;
using KodaiBot.Common.ConfigurationModel;

namespace KodaiBot.Host.Controllers
{
    public class InfoController : BaseController
    {
        public InfoController(IServiceProvider serviceProvider, Logger logger) : base(serviceProvider, logger)
        {

        }

        [Command("time"), 
            Summary("Returns the time in a current timezone")]
        public async Task Say(
            [Remainder, 
                Summary("The timezone you want to return")] string timezone
        )
        {
            var command = GetCommand<GetCurrentTimeCommand>();
            command.TimeZoneString = timezone;

            command.Execute();

            await ReplyAsync(command.Result);
        }
    }
}
