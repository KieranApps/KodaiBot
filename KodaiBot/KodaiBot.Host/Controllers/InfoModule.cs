using System;
using System.Threading.Tasks;
using Discord.Commands;
using KodaiBot.BusinessLayer.Commands;
using KodaiBot.Common.ConfigurationModel;

namespace KodaiBot.Host.Controllers
{
    public class InfoModule : ModuleBase
    {
        public InfoModule(IServiceProvider serviceProvider, Logger logger) : base(serviceProvider, logger)
        {
        }

        [Command("time"), 
            Alias("now", "timezone", "date", "datetime"),
            Summary("Returns the time in a current timezone")]
        public async Task GetCurrentTime(
            [Summary("The timezone you want to return")] string timezone = ""
        )
        {
            var command = GetCommand<GetCurrentTimeCommand>();
            command.TimeZoneString = timezone;

            command.Execute();

            await ReplyAsync(command.Result);
        }
    }
}
