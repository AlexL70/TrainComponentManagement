using System.Linq.Expressions;

namespace webapi.Domain.Repositories.Abstract
{
    public interface IRefRepository<TKey, TListDto, TEntity> : IGetRepository<TKey, TEntity>
        where TEntity : class
    {
        IEnumerable<TListDto> GetAll(Expression<Func<TEntity, object>>? orderBy = null);
    }
}