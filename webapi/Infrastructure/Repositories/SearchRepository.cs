using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using webapi.Domain.Repositories.Abstract;

namespace webapi.Infrastructure.Repositories
{
    public class SearchRepository<TEntity, TListDto> : ISearchRepository<TEntity, TListDto>
        where TEntity : class
    {
        protected DbContext _context;

        public SearchRepository(DbContext context)
        {
            _context = context;
        }
        public long GetCount(Expression<Func<TEntity, bool>> predicate)
        {
            return _context.Set<TEntity>().LongCount();
        }

        public IEnumerable<TListDto> GetPageByConditions(Expression<Func<TEntity, bool>>? predicate, IEnumerable<OrderByElement<TEntity>>? orderBy, Expression<Func<TEntity, TListDto>> mapping, int pageSize = int.MaxValue, int PageNo = 1)
        {
            IQueryable<TEntity> qry = _context.Set<TEntity>();
            if (predicate != null)
                qry = qry.Where(predicate);
            var isFirst = true;
            if (orderBy != null)
                foreach (var orderItem in orderBy)
                {
                    if (isFirst)
                    {
                        qry = orderItem.isAscending
                            ? qry.OrderBy(orderItem.exp)
                            : qry.OrderByDescending(orderItem.exp);
                    } else {
                        qry = orderItem.isAscending
                            ? ((IOrderedQueryable<TEntity>)qry).ThenBy(orderItem.exp)
                            : ((IOrderedQueryable<TEntity>)qry).ThenByDescending(orderItem.exp);
                    }
                    isFirst = false;
                }
            var projected = qry.Select(mapping);
            return projected.Skip(pageSize * (PageNo - 1)).Take(pageSize);
        }
    }
}