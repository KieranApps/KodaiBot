using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Discord;
using Discord.Commands;
using KodaiBot.BusinessLayer.Commands;
using KodaiBot.Common.ConfigurationModel;

namespace KodaiBot.Host.Controllers
{
    public class AudioOutputController : BaseController
    {
        public AudioOutputController(IServiceProvider serviceProvider, Logger logger) : base(serviceProvider, logger)
        {
        }

        [Group("play")]
        public class PlayController : BaseController
        {
            public PlayController(IServiceProvider serviceProvider, Logger logger) : base(serviceProvider, logger)
            {
            }

            [Command("", RunMode = RunMode.Async)]
            public async Task FindAudioSource(
                [Summary("Try to dynamically find out what the source is and await that command.")] string path)
            {
                
            }

            [Command("mp3", RunMode = RunMode.Async)]
            public async Task PlayRelativePath(
                [Summary("Relative path to the file on the server")] string path)
            {
                var command = GetCommand<SummonAudioClient>();
                command.User = Context.User;

                command.Execute();

                using (var client = await command.Result)
                {
                    await Task.Delay(5000);
                }
            }

            [Command("youtube", RunMode = RunMode.Async)]
            public async Task PlayYoutube(
                [Summary("Url to the youtube video")] string url)
            {
                var command = GetCommand<SummonAudioClient>();
                command.User = Context.User;

                command.Execute();

                using (var client = await command.Result)
                {
                    await Task.Delay(5000);
                }
            }
        }

        
    }
}
