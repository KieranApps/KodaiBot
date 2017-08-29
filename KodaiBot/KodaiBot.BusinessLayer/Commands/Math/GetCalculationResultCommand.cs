using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using KodaiBot.Common.ConfigurationModel;
using KodaiBot.RepositoryLayer.Interfaces;
using NCalc;

namespace KodaiBot.BusinessLayer.Commands
{
    public class GetCalculationResultCommand : CommandBase
    {
        public string Expression { get; set; }
        public string Result { get; private set; }

        public GetCalculationResultCommand(Logger logger, IUnitOfWork unitOfWork, IMapper mapper) : base(logger, unitOfWork, mapper)
        {
        }

        internal override void CanExecute()
        {
            CheckPrerequisite(!string.IsNullOrWhiteSpace(Expression),
                "Expression can not be empty");
        }

        internal override void OnExecute()
        {
            Result = new Expression(Expression).Evaluate().ToString();
        }
    }
}
