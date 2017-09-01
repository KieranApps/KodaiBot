using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Discord;
using Discord.Audio;
using KodaiBot.Common.ConfigurationModel;

namespace KodaiBot.BusinessLayer.Helpers
{
    public class AudioHelper
    {
        private readonly Logger _logger;
        private readonly ConcurrentDictionary<ulong, IAudioClient> _connectedChannels;

        public AudioHelper(Logger logger)
        {
            _logger = logger;
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

            if (_connectedChannels.TryAdd(guild.Id, audioClient))
            {
                await _logger.Log($"Connected to voice on {guild.Name}.", GetType().Name);
            }
        }

        public async Task Disconnect(IGuild guild)
        {
            if (!_connectedChannels.TryRemove(guild.Id, out IAudioClient client)) return;

            await client.StopAsync();
            await _logger.Log($"Disconnected from voice on {guild.Name}.", GetType().Name);
        }

        public async Task SendAsync(IGuild guild, string path, IVoiceChannel channel = null)
        {
            if (!File.Exists(path)) throw new FileNotFoundException("File does not exist.");

            if (!_connectedChannels.TryGetValue(guild.Id, out IAudioClient client)) return;
            
            await _logger.Log($"Starting playback of {path} in {guild.Name}", GetType().Name);

            var output = CreateStream(path).StandardOutput.BaseStream;
            var stream = client.CreatePCMStream(AudioApplication.Music);

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
    }
}
