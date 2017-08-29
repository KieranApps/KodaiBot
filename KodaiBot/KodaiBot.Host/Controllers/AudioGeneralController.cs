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
    public partial class AudioController : BaseController
    {

        public AudioController(IServiceProvider serviceProvider, Logger logger) : base(serviceProvider, logger)
        {
        }

        [Command("summon", RunMode = RunMode.Async),
            Alias("listen", "."),
            Summary("Joins your channel")]
        public async Task Summon(IVoiceChannel channel = null)
        {
            using (var client = await GetAudioClient(channel))
            {
                Thread.Sleep(1000);
            }
        }


        [Command("test", RunMode = RunMode.Async)]
        public async Task Test(IVoiceChannel channel = null)
        {
            using (var client = await GetAudioClient(channel))
            {
                Thread.Sleep(1000);
            }
        }

        private Task<IAudioClient> GetAudioClient(IVoiceChannel channel)
        {
            var command = GetCommand<SummonAudioClient>();
            command.User = Context.User;
            command.Channel = channel;

            command.Execute();

            return command.Result;
        }
    }
}
