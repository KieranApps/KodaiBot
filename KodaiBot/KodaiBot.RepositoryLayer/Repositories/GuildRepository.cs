using KodaiBot.Common.DataModel;
using KodaiBot.RepositoryLayer.Interfaces;

namespace KodaiBot.RepositoryLayer.Repositories
{
    public class GuildRepository : BaseRepository<Guild>, IGuildRepository
    {
        public GuildRepository(DbEntities context) : base(context)
        {
        }
    }
}
