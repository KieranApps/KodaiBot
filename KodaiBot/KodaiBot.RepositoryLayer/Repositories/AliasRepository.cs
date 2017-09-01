using KodaiBot.Common.DataModel;
using KodaiBot.RepositoryLayer.Interfaces;

namespace KodaiBot.RepositoryLayer.Repositories
{
    public class AliasRepository : BaseRepository<Alias>, IAliasRepository
    {
        public AliasRepository(DbEntities context) : base(context)
        {
        }
    }
}
