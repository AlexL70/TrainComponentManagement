using webapi.Domain.Models.Abstract;

namespace webapi.Domain.Services.Abstract
{
    public interface ICrudService<TKey, TDto> : IGetService<TKey, TDto>
        where TDto : class, IModelWithId<TKey>
    {
        void Add(TDto dto);
        void Remove(TDto dto);
        void Remove(TKey key);
        void Update(TDto dto);
    }
}