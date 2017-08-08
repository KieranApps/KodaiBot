using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace KodaiBot.RepositoryLayer.Interfaces
{
    public interface IBaseRepository<T> where T : class
    {
        T Get(Guid id);
        IEnumerable<T> List();
        IQueryable<T> ListWhere(Expression<Func<T, bool>> filter);
        void Add(T e);
        void Delete(T e);
        void Update(T e);
    }
}
