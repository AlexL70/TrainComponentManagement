using Microsoft.EntityFrameworkCore;
using webapi.Domain.Models;
using webapi.Domain.Repositories;
using webapi.Domain.Repositories.Abstract;
using webapi.Infrastructure.Database;
using webapi.Infrastructure.Database.Models;

namespace webapi.Infrastructure.Repositories
{
    public class TrainComponentTypesRepository :
        SearchRepository<TrainComponentType, TrainComponentTypeListDto>,
        ITrainComponentTypesRepository
    {
        protected new TrainComponentsDbContext _context => (TrainComponentsDbContext)base._context;
        public TrainComponentTypesRepository(TrainComponentsDbContext context) : base(context) { }

        public IEnumerable<TrainComponentTypeListDto> GetComponentTypes()
        {
            return base.GetPageByConditions(null, new OrderByElement<TrainComponentType>[] {
                new OrderByElement<TrainComponentType> { isAscending = true, exp = _ => _.Id }
            }, mapping: _ => new TrainComponentTypeListDto
            {
                Id = _.Id,
                Name = _.Name,
                IsRoot = _.IsRoot,
                CanAssignQuantity = _.CanAssignQuantity,
            });
        }

        public TrainComponentType? Get(int key)
        {
            return _context.TrainComponentTypes
                .Include(_ => _.BrandsAvailable)
                .Include(_ => _.CanHaveChildren).ThenInclude(_ => _.ChildType)
                .Include(_ => _.CanHaveParents).ThenInclude(_ => _.ParentType)
                .Single(_ => _.Id == key);
        }
    }
}