namespace webapi.Domain.Repositories.Abstract
{
    public interface IGetRepository<TKey, TEntity>
        where TKey : IComparable<TKey>
        where TEntity : class
    {
        TEntity? Get(TKey key);
    }
}