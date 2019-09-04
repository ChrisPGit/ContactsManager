using ContactsManager.Core.Entities;
using ContactsManager.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ContactsManager.Data
{
    public class Repository<T> : IRepository<T> where T : EntityBase
    {
        private ContactsManagerContext _context;
        public Repository(ContactsManagerContext context)
        {
            _context = context;
        }

        public async Task Create(T item)
        {
            await _context.Set<T>().AddAsync(item);
        }

        public async Task<T> Get(int id)
        {
            return await _context.Set<T>().FindAsync(id);
        }

        public IQueryable<T> List()
        {
            return _context.Set<T>();
        }

        public IQueryable<T> List(Expression<Func<T, bool>> predicate)
        {
            return _context.Set<T>()
               .Where(predicate);
        }

        public void Update(T item)
        {
            _context.Set<T>().Update(item);
        }

        public async Task Delete(int id)
        {
            var item = await _context.Set<T>()
                .FindAsync(id);
            _context.Set<T>().Remove(item);
        }

        public async Task<bool> Save()
        {
            return await _context.SaveChangesAsync() >= 0 ;
        }
    }
}
