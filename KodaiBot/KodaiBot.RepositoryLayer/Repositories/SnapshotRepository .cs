using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KodaiBot.Common.DataModel;
using KodaiBot.RepositoryLayer.Interfaces;

namespace KodaiBot.RepositoryLayer.Repositories
{
    public class SnapshotRepository : BaseRepository<Snapshot>, ISnapshotRepository
    {
        public SnapshotRepository(DbEntities context) : base(context)
        {
        }
    }
}
