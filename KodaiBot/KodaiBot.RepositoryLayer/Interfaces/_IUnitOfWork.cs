using System;

namespace KodaiBot.RepositoryLayer.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        void BeginTransaction();
        void SaveChanges();
        void Commit();
        void RollBack();
    }
}
