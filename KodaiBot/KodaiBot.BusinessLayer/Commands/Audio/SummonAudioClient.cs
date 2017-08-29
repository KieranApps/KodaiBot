using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Discord;
using Discord.Audio;
using KodaiBot.Common.ConfigurationModel;
using KodaiBot.RepositoryLayer.Interfaces;

namespace KodaiBot.BusinessLayer.Commands
{
    public class SummonAudioClient : CommandBase
    {
        private IGuildUser _guildUser;

        public IUser User { get; set; }
        public IVoiceChannel Channel { get; set; }
        public Task<IAudioClient> Result { get; private set; }

        public SummonAudioClient(Logger logger, IUnitOfWork unitOfWork, IMapper mapper) : base(logger, unitOfWork, mapper)
        {
        }

        internal override void CanExecute()
        {
            _guildUser = User as IGuildUser;
            CheckPrerequisite(_guildUser != null || Channel != null, 
                $"A user or a channel has to be provided before { Constants.Bot.Name } can be summoned.");
        }

        internal override void OnExecute()
        {
            Result = (Channel ?? _guildUser.VoiceChannel).ConnectAsync();
        }
    }
}
