namespace webapi.Domain.Repositories.Abstract
{
    public interface ICrudRepository<TKey, TEntity> : IGetRepository<TKey, TEntity>
        where TKey : IComparable<TKey>
        where TEntity: class
    {
        void Add(TEntity entity);
        void AddRange(IEnumerable<TEntity> entities);
        void Remove(TEntity entity);
        void Remove(TKey key);
        void RemoveRange(IEnumerable<TEntity> entities);
    }
}