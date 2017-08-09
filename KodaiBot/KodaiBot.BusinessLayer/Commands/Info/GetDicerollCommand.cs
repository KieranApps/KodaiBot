using System;
using AutoMapper;
using KodaiBot.Common.ConfigurationModel;
using KodaiBot.RepositoryLayer.Interfaces;

namespace KodaiBot.BusinessLayer.Commands
{
    public class GetDicerollCommand : CommandBase
    {
        private int _maxEyes;

        public string MaxEyes { get; set; }
        public string Result { get; private set; }

        public GetDicerollCommand(Logger logger, IUnitOfWork unitOfWork, IMapper mapper) : base(logger, unitOfWork, mapper)
        {
        }

        internal override bool CanExecute()
        {
            return CheckPrerequisite(MaxEyes.Equals(string.Empty) 
                || int.TryParse(MaxEyes, out _maxEyes), "Timezone couldn't be parsed into a number");
        }

        internal override void OnExecute()
        {
            var maxRoll = _maxEyes > 0 ? _maxEyes : 6;
            var number = new Random().Next(0, maxRoll);
            Result = $"You threw {number} out of {maxRoll}";
        }
    }
}
