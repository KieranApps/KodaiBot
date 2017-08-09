using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using KodaiBot.Common.ConfigurationModel;
using KodaiBot.RepositoryLayer.Interfaces;

namespace KodaiBot.BusinessLayer.Helpers
{
    public class HelperBase
    {
        internal readonly Logger Logger;
        internal readonly IMapper Mapper;
        internal readonly IUnitOfWork UnitOfWork;

        public HelperBase(Logger logger, IMapper mapper, IUnitOfWork unitOfWork)
        {
            Logger = logger; 
            Mapper = mapper;
            UnitOfWork = unitOfWork;
        }
    }
}
