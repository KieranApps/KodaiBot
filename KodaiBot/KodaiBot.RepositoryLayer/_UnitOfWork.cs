using KodaiBot.Common.DataModel;
using KodaiBot.RepositoryLayer.Interfaces;

namespace KodaiBot.RepositoryLayer
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly DbEntities _context;

        public UnitOfWork(DbEntities context)
        {
            _context = context;
            _context.Configuration.LazyLoadingEnabled = false;
        }

        public void BeginTransaction()
        {
            _context.Database.BeginTransaction();
        }

        public void Commit()
        {
            _context.Database.CurrentTransaction.Commit();
        }

        public void Dispose()
        {
            _context.Dispose();
        }

        public void RollBack()
        {
            _context.Database.CurrentTransaction.Rollback();
        }

        public void SaveChanges()
        {
            _context.SaveChanges();
        }
    }
}
