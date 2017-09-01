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
