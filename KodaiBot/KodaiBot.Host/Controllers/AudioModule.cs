using System;
using System.Threading;
using System.Threading.Tasks;
using Discord;
using Discord.Commands;
using KodaiBot.BusinessLayer.Commands;
using KodaiBot.Common.ConfigurationModel;

namespace KodaiBot.Host.Controllers
{
    public class AudioModule : ModuleBase
    {
        public AudioModule(IServiceProvider serviceProvider, Logger logger) : base(serviceProvider, logger)
        {
        }

        [Command("connect", RunMode = RunMode.Async),
            Alias("listen", "summon", "join", "."),
            Summary("Joins your channel or the channel you specify")]
        public async Task Connect(
            [Summary("The channel you would like the bot to enter")]IVoiceChannel channel = null)
        {
            var command = GetCommand<SummonAudioClientCommand>();

            command.Guild = Context.Guild;
            command.Channel = channel;
            command.User = Context.User;
            command.Execute();

            await command.Result;
        }

        [Command("disconnect", RunMode = RunMode.Async),
            Alias("leave", "quit", "bye", "q", "dc"),
            Summary("Leaves the server")]
        public async Task Disconnect()
        {
            var command = GetCommand<DisconnectAudioCientCommand>();

            command.Guild = Context.Guild;
            command.Execute();

            await command.Result;
        }


        [Group("play")]
        public class PlayController : ModuleBase
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