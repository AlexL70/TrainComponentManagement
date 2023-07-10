using System.Linq.Expressions;

namespace webapi.Domain.Repositories.Abstract
{
    public struct OrderByElement<TEntity>
    {
        public Expression<Func<TEntity, object>> exp;
        public bool isAscending;
    }

    public interface ISearchRepository<TEntity, TListDto>
        where TEntity : class
    {
        long GetCount(Expression<Func<TEntity, bool>> predicate);
        IEnumerable<TListDto> GetPageByConditions(Expression<Func<TEntity, bool>>? predicate,
            IEnumerable<OrderByElement<TEntity>>? orderBy,
            Expression<Func<TEntity, TListDto>> mapping, 
            int pageSize = int.MaxValue, int PageNo = 1);
    }
}