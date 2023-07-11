using Microsoft.EntityFrameworkCore;
using webapi.Domain.Repositories.Abstract;

namespace webapi.Infrastructure.Repositories
{
    public class GetRepository<TKey, TEntity> : IGetRepository<TKey, TEntity>
        where TEntity : class
    {
        protected DbContext _context;

        public GetRepository(DbContext context)
        {
            _context = context;
        }
        public TEntity? Get(TKey key)
        {
            return _context.Set<TEntity>().Find(key);
        }
    }
}