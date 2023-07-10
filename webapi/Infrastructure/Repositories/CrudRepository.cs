using Microsoft.EntityFrameworkCore;
using webapi.Domain.Repositories.Abstract;

namespace webapi.Infrastructure.Repositories
{
    public class CrudRepository<TKey, TEntity> : ICrudRepository<TKey, TEntity>
        where TKey : IComparable<TKey>
        where TEntity : class
    {
        private DbContext _context;
        private GetRepository<TKey, TEntity> _get;

        public CrudRepository(DbContext context)
        {
            _context = context;
            _get = new GetRepository<TKey, TEntity>(context);
        }
        public void Add(TEntity entity)
        {
            _context.Set<TEntity>().Add(entity);
        }

        public void AddRange(IEnumerable<TEntity> entities)
        {
            _context.Set<TEntity>().AddRange(entities);
        }

        public TEntity? Get(TKey key)
        {
            return _get.Get(key);
        }

        public void Remove(TEntity entity)
        {
            _context.Set<TEntity>().Remove(entity);
        }

        public void Remove(TKey key)
        {
            var entity = _get.Get(key);
            if (entity != null)
                Remove(entity);
        }

        public void RemoveRange(IEnumerable<TEntity> entities)
        {
            _context.RemoveRange(entities);
        }
    }
}