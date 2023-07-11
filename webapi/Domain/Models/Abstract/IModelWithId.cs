namespace webapi.Domain.Models.Abstract
{
    public interface IModelWithId<TKey>
    {
        public TKey Id { get; }
    }
}