using webapi.Domain.Repositories.Abstract;
using webapi.Domain.Models.Abstract;

namespace webapi.Domain.Services.Abstract
{
    public class GetService<TKey, TDto, TEntity> : IGetService<TKey, TDto>
        where TDto : class, IModelWithId<TKey> 
        where TEntity : class
    {
        protected readonly IGetRepository<TKey, TEntity> _repository;
        protected readonly IEntityDtoMapping<TEntity, TDto> _mapping;

        public GetService(IGetRepository<TKey, TEntity> repository, 
            IEntityDtoMapping<TEntity, TDto> mapping)
        {
            _repository = repository;
            _mapping = mapping;
        }

        public TDto? Get(TKey key)
        {
            var entity = _repository.Get(key);
            if (entity == null)
                return null;
            return _mapping.from(entity);
        }

       
    }
}