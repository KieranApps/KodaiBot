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
    public class AliasHelper : HelperBase
    {
        public AliasHelper(Logger logger, IMapper mapper, IUnitOfWork unitOfWork) : base(logger, mapper,unitOfWork)
        {
                
        }
    }
}
