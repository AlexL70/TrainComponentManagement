namespace webapi.Domain.Services.Abstract
{
    public interface IGetService<TKey, TDto>
        where TDto : class
    {
        TDto? Get(TKey key);
    }
}