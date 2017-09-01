using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Discord;
using Discord.Audio;
using KodaiBot.Common.ConfigurationModel;
using KodaiBot.RepositoryLayer.Interfaces;

namespace KodaiBot.BusinessLayer.Helpers
{
    public class AudioHelper : HelperBase
    {
        private readonly ConcurrentDictionary<ulong, IAudioClient> _connectedChannels;

        public AudioHelper(Logger logger, IMapper mapper, IUnitOfWork unitOfWork) : base(logger, mapper, unitOfWork)
        {
            _connectedChannels = new ConcurrentDictionary<ulong, IAudioClient>();
        }

        public async Task Connect(IGuild guild, IVoiceChannel channel)
        {
            if (channel?.Guild.Id != guild.Id) return;

            if (_connectedChannels.TryGetValue(guild.Id, out IAudioClient client))
            {
                await Disconnect(guild);
            }

            var audioClient = await channel.ConnectAsync();
            audioClient.StreamCreated += OnStreamCreated;
            audioClient.StreamDestroyed += OnStreamDestroyed;

            if (_connectedChannels.TryAdd(guild.Id, audioClient))
            {
                await Logger.Log($"Connected to voice on {guild.Name}.", GetType().Name);
            }
        }

        public async Task Disconnect(IGuild guild)
        {
            if (!_connectedChannels.TryRemove(guild.Id, out IAudioClient client)) return;

            await client.StopAsync();
            await Logger.Log($"Disconnected from voice on {guild.Name}.", GetType().Name);
        }

        public async Task SendAsync(IGuild guild, string path)
        {
            if (!File.Exists(path)) throw new FileNotFoundException("File does not exist.");

            if (!_connectedChannels.TryGetValue(guild.Id, out IAudioClient client)) return;
            
            await Logger.Log($"Starting playback of {path} in {guild.Name}", GetType().Name);

            var output = CreateStream(path).StandardOutput.BaseStream;
            var stream = client.CreatePCMStream(AudioApplication.Mixed);

            await output.CopyToAsync(stream);
            await stream.FlushAsync().ConfigureAwait(false);
        }

        private static Process CreateStream(string path)
        {
            return Process.Start(new ProcessStartInfo
            {
                FileName = "ffmpeg.exe",
                Arguments = $"-hide_banner -loglevel panic -i \"{path}\" -ac 2 -f s16le -ar 48000 pipe:1",
                UseShellExecute = false,
                RedirectStandardOutput = true
            });
        }

        private async Task OnStreamCreated(ulong id, AudioInStream stream)
        {
            //ToDo: KB-006 Need to add incoming voice processing.
        }

        private async Task OnStreamDestroyed(ulong id)
        {
            //ToDo: KB-006 Need to add incoming voice processing.
        }
    }
}
