using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Discord;
using KodaiBot.BusinessLayer.Helpers;
using KodaiBot.Common.ConfigurationModel;
using KodaiBot.RepositoryLayer.Interfaces;

namespace KodaiBot.BusinessLayer.Commands
{
    public class DisconnectAudioCientCommand : CommandBase
    {
        private readonly AudioHelper _helper;

        public IGuild Guild { get; set; }
        public Task Result { get; private set; }

        public DisconnectAudioCientCommand(Logger logger, IUnitOfWork unitOfWork, IMapper mapper, AudioHelper helper) : base(logger, unitOfWork, mapper)
        {
            _helper = helper;
        }

        internal override void CanExecute()
        {
            CheckPrerequisite(Guild != null,
                $"A guild has to be provided before { Constants.Bot.Name } can be summoned.");
        }

        internal override void OnExecute()
        {
            Result = _helper.Disconnect(Guild);
        }
    }
}
