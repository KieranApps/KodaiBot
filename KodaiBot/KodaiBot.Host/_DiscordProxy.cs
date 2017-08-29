using System;
using System.Reflection;
using System.Threading.Tasks;
using Discord;
using Discord.Commands;
using Discord.WebSocket;
using KodaiBot.Common.ConfigurationModel;

namespace KodaiBot.Host
{
    public class DiscordProxy
    {
        private readonly DiscordSocketClient _client;
        private readonly IServiceProvider _services;
        private readonly CommandService _commands;
        private readonly Logger _logger;

        public DiscordProxy(IServiceProvider services, Logger logger, CommandService commands)
        {
            _services = services;
            _logger = logger;
            _commands = commands;

            _client = new DiscordSocketClient(
                new DiscordSocketConfig
                {
                    LogLevel = LogSeverity.Info
                });        

            _client.Log += _logger.Log;
        }

        public async Task EstablishClientConnection()
        {
            await InstallCommands();
            await _client.LoginAsync(TokenType.Bot, Configurator.Bot.Token);
            await _client.StartAsync();
            await Task.Delay(-1);
        }

        private async Task InstallCommands()
        {
            _client.MessageReceived += ProcessCommand;
            await _commands.AddModulesAsync(Assembly.GetEntryAssembly());
        }

        private async Task ProcessCommand(SocketMessage message)
        {
            var commandName = message as SocketUserMessage;
            if (commandName == null) return;
            
            var argPos = 0;
            if(!(commandName.HasCharPrefix(Configurator.Bot.Prefix, ref argPos) 
                || commandName.HasMentionPrefix(_client.CurrentUser, ref argPos))) return;
            
            var context = new CommandContext(_client, commandName);
            var result = await _commands.ExecuteAsync(context, argPos, _services);

            if (!result.IsSuccess)
            {
                await context.Channel.SendMessageAsync(result.ErrorReason);
            }
        }
    }
}
