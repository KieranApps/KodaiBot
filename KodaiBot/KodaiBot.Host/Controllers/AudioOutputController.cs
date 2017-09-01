using System;
using System.IO;
using System.Threading.Tasks;
using Discord;
using Discord.Audio;
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
                await Task.Delay(-1);
            }

            [Command("mp3", RunMode = RunMode.Async)]
            public async Task PlayRelativePath(
                [Summary("Relative path to the file on the server")] string path,
                [Summary("The channel you would like the bot to enter")]IVoiceChannel channel = null)
            {
               
            }

            [Command("youtube", RunMode = RunMode.Async)]
            public async Task PlayYoutube(
                [Summary("Url to the youtube video")] string url)
            {
                
            }

        }
    }
}
