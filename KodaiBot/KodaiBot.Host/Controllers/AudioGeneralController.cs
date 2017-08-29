﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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

        private Task<IAudioClient> GetAudioClient(IVoiceChannel channel)
        {
            var command = GetCommand<SummonAudioClient>();
            command.User = Context.User;
            command.Channel = channel;

            command.Execute();

            return command.Result;
        }

        [Command("summon"),
            Summary("Joins your channel")]
        public async Task Summon(IVoiceChannel channel = null)
        {
            using (var client = await GetAudioClient(channel))
            {
                await Logger.Log($"Latency: {client.Latency}", "Here");
            }
        }


        [Command("test")]
        public async Task Test(IVoiceChannel channel = null)
        {
            var client = GetAudioClient(channel);
            
        }
    }
}
