using System;
using AutoMapper;
using KodaiBot.Common.ConfigurationModel;
using KodaiBot.RepositoryLayer.Interfaces;

namespace KodaiBot.BusinessLayer.Commands
{
    public class GetCurrentTimeCommand : CommandBase
    {
        private int _determinedTimeZone;

        public string TimeZoneString { get; set; }
        public string Result { get; private set; }

        public GetCurrentTimeCommand(Logger logger, IUnitOfWork unitOfWork, IMapper mapper) : base(logger, unitOfWork, mapper)
        {
        }

        internal override bool CanExecute()
        {
            return CheckPrerequisite(TimeZoneString.Equals(string.Empty) 
                || int.TryParse(TimeZoneString, out _determinedTimeZone), "Timezone couldn't be parsed into a number");
        }

        internal override void OnExecute()
        {
            var date = DateTime.UtcNow.AddHours(_determinedTimeZone);
            Result = $"{date.ToLongDateString()} {date.ToLongTimeString()}";
        }
    }
}
