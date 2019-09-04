using ContactsManager.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace ContactsManager.Core.Interfaces
{
    public interface IRepository<T> where T : EntityBase
    {
        Task Create(T item);
        IQueryable<T> List();
        IQueryable<T> List(Expression<Func<T, bool>> predicate);
        Task<T> Get(int id);
        void Update(T item);
        Task Delete(int id);
        Task<bool> Save();
    }
}
