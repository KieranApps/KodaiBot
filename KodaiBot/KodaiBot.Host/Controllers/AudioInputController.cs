using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Discord;
using Discord.Audio;
using Discord.Commands;
using KodaiBot.BusinessLayer.Commands;
using KodaiBot.Common.ConfigurationModel;

namespace KodaiBot.Host.Controllers
{
    public class AudioInputController : BaseController
    {

        public AudioInputController(IServiceProvider serviceProvider, Logger logger) : base(serviceProvider, logger)
        {
        }

        [Command("summon", RunMode = RunMode.Async),
            Alias("listen", "."),
            Summary("Joins your channel")]
        public async Task Summon()
        {
            var command = GetCommand<SummonAudioClient>();
            command.User = Context.User;

            command.Execute();

            using (var client = await command.Result)
            {
                await Task.Delay(-1);
            }
        }
    }
}
