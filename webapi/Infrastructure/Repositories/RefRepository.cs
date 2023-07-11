using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using webapi.Domain.Repositories.Abstract;

namespace webapi.Infrastructure.Repositories
{
    public class RefRepository<TKey, TListDto, TEntity> : IRefRepository<TKey, TListDto, TEntity>
        where TEntity : class
    {
        private DbContext _context;
        private Expression<Func<TEntity, TListDto>> _mapping;
        private GetRepository<TKey, TEntity> _get;

        public RefRepository(DbContext context, Expression<Func<TEntity, TListDto>> mapping)
        {
            _context = context;
            _mapping = mapping;
            _get = new GetRepository<TKey, TEntity>(context);
        }

        public TEntity? Get(TKey Id)
        {
            return _get.Get(Id);
        }

        public IEnumerable<TListDto> GetAll(Expression<Func<TEntity, object>>? orderBy = null)
        {
            IQueryable<TEntity> result = _context.Set<TEntity>();
            if (orderBy != null)
                result = result.OrderBy(orderBy);
            return result.Select(_mapping).ToList();
        }
    }
}