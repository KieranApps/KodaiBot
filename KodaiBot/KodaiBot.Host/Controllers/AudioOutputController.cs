using System;
using System.IO;
using System.Threading.Tasks;
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
                [Summary("Relative path to the file on the server")] string path)
            {
                using (var client = await GetAudioClient())
                {
                    var stream = GetOutputAudioStream();
                    var outgoingStream = client.CreatePCMStream(AudioApplication.Mixed);

                    await stream.CopyToAsync(outgoingStream);
                    await outgoingStream.FlushAsync();
                }
            }

            [Command("youtube", RunMode = RunMode.Async)]
            public async Task PlayYoutube(
                [Summary("Url to the youtube video")] string url)
            {
                using (var client = await GetAudioClient())
                {
                    await Task.Delay(5000);
                }
            }

            private Stream GetOutputAudioStream()
            {
                var command = GetCommand<GetAudioStreamCommand>();

                command.Execute();

                return command.Result;
            }
        }
    }
}
