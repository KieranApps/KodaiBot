using System.Threading.Tasks;
using AutoMapper;
using Discord;
using Discord.Audio;
using KodaiBot.BusinessLayer.Helpers;
using KodaiBot.Common.ConfigurationModel;
using KodaiBot.RepositoryLayer.Interfaces;

namespace KodaiBot.BusinessLayer.Commands
{
    public class SummonAudioClientCommand : CommandBase
    {
        private IGuildUser _guildUser;
        private readonly AudioHelper _helper;

        public IGuild Guild { get; set; }
        public IUser User { get; set; }
        public IVoiceChannel Channel { get; set; }
        public Task Result { get; private set; }

        public SummonAudioClientCommand(Logger logger, IUnitOfWork unitOfWork, IMapper mapper, AudioHelper helper) : base(logger, unitOfWork, mapper)
        {
            _helper = helper;
        }

        internal override void CanExecute()
        {
            _guildUser = User as IGuildUser;
            CheckPrerequisite(Guild != null,
                $"A guild has to be provided before { Constants.Bot.Name } can be summoned.");
            CheckPrerequisite(_guildUser != null || Channel != null, 
                $"A user or voice channel ID has to be provided before { Constants.Bot.Name } can be summoned.");
        }

        internal override void OnExecute()
        {
            Result = _helper.Connect(Guild, Channel ?? _guildUser.VoiceChannel);
        }
    }
}
