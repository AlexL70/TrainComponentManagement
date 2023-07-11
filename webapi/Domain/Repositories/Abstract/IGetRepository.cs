namespace webapi.Domain.Repositories.Abstract
{
    public interface IGetRepository<TKey, TEntity>
        where TEntity : class
    {
        TEntity? Get(TKey key);
    }
}