using webapi.Domain.Repositories;
using webapi.Domain.Repositories.Abstract;
using webapi.Infrastructure.Database;
using webapi.Infrastructure.Database.Models;

namespace webapi.Infrastructure.Repositories
{
    public class TrainComponentTypesRepository : 
        SearchRepository<TrainComponentType, TrainComponentType>,
        ITrainComponentTypesRepository
    {
        protected new TrainComponentsDbContext _context => (TrainComponentsDbContext)base._context;
        public TrainComponentTypesRepository(TrainComponentsDbContext context) : base(context)
        {

        }

        public IEnumerable<TrainComponentType> GetComponentTypes() {
            return base.GetPageByConditions(null, new OrderByElement<TrainComponentType>[] {
                new OrderByElement<TrainComponentType> { isAscending = true, exp = _ => _.Id }
            }, _ => _);
        }
    }
}