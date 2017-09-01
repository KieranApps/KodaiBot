using KodaiBot.Common.DataModel;
using KodaiBot.RepositoryLayer.Interfaces;

namespace KodaiBot.RepositoryLayer.Repositories
{
    public class UserRepository : BaseRepository<User>, IUserRepository
    {
        public UserRepository(DbEntities context) : base(context)
        {
        }
    }
}
