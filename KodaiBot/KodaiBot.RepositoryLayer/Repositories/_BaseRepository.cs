using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using KodaiBot.Common.DataModel;
using KodaiBot.RepositoryLayer.Interfaces;

namespace KodaiBot.RepositoryLayer.Repositories
{
    public class BaseRepository<T> : IBaseRepository<T> where T : class
    {
        internal readonly DbEntities Context;

        public BaseRepository(DbEntities context)
        {
            Context = context;
        }

        public T Get(Guid id)
        {
            return Context.Set<T>().Find(id);
        }

        public IEnumerable<T> List()
        {
            return Context.Set<T>();
        }

        public IQueryable<T> ListWhere(Expression<Func<T, bool>> filter)
        {
            return Context.Set<T>().Where(filter);
        }

        public void Add(T e)
        {
            Context.Set<T>().Add(e);
        }

        public void Delete(T e)
        {
            Context.Set<T>().Remove(e);
        }

        public void Update(T e)
        {
            var a = Context.Entry(e);

            if (a.State.Equals(EntityState.Detached))
            {
                Context.Set<T>().Attach(e);
                a = Context.Entry(e);
            }

            a.State = EntityState.Modified;
        }
    }
}
