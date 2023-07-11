namespace webapi.Domain.Services.Abstract
{
    public interface IEntityDtoMapping<TEntity, TDto>
        where TEntity: class
        where TDto: class
    {
        Func<TEntity, TDto> from { get; }
        Func<TDto, TEntity> to { get; }
    }
}