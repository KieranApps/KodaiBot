using System;
using System.Threading;
using System.Threading.Tasks;
using Discord;
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
            Alias("listen", "join", "."),
            Summary("Joins your channel")]
        public async Task Summon(
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
    }
}