using webapi.Domain.Repositories.Abstract;
using webapi.Domain.Models.Abstract;

namespace webapi.Domain.Services.Abstract
{
    public class CrudService<TKey, TDto, TEntity> : GetService<TKey, TDto, TEntity>, ICrudService<TKey, TDto>
        where TDto : class, IModelWithId<TKey> 
        where TEntity : class
    {
        protected new ICrudRepository<TKey, TEntity> _repository => (ICrudRepository<TKey, TEntity>)base._repository;
        public CrudService(ICrudRepository<TKey, TEntity> repository, 
            IEntityDtoMapping<TEntity, TDto> mapping)
                : base(repository, mapping) {}

        public void Add(TDto dto)
        {
            var entity = _mapping.to(dto);
        }

        public void Remove(TDto dto)
        {
            var entity = _mapping.to(dto);
            _repository.Remove(entity);
        }

        public void Remove(TKey key)
        {
            _repository.Remove(key);
        }

        public void Update(TDto dto)
        {
            var newEnity = _mapping.to(dto);
            var oldEntity = _repository.Get(dto.Id);
            var props = typeof(TEntity).GetProperties();
            //  Update only properties that values has changed
            //  so that DB context includes only them into UPDATE statement
            foreach (var prop in props)
            {
                var oldValue = prop.GetValue(oldEntity);
                var newValue = prop.GetValue(newEnity);
                if (oldValue != newValue)
                    prop.SetValue(oldEntity, newValue);
            }
        }
    }
}