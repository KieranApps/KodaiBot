using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using KodaiBot.Common.ConfigurationModel;
using KodaiBot.RepositoryLayer.Interfaces;

namespace KodaiBot.BusinessLayer.Commands
{
    public class GetPingCommand : CommandBase
    {
        public string Result { get; private set; }

        public GetPingCommand(Logger logger, IUnitOfWork unitOfWork, IMapper mapper) : base(logger, unitOfWork, mapper)
        {
        }

        internal override void OnExecute()
        {
            Result = "pong";
        }
    }
}
