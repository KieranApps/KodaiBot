using System;
using System.Threading;
using System.Threading.Tasks;
using Discord;
using Discord.Commands;
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
            using (var client = await GetAudioClient())
            { 
                await Task.Delay(-1);
            }
        }
    }
}