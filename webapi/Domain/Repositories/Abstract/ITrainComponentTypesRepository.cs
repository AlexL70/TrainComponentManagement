using webapi.Domain.Models;
using webapi.Domain.Repositories.Abstract;
using webapi.Infrastructure.Database.Models;

namespace webapi.Domain.Repositories
{
    public interface ITrainComponentTypesRepository : ISearchRepository<TrainComponentType, TrainComponentTypeListDto>
    {
        public IEnumerable<TrainComponentTypeListDto> GetComponentTypes();
    }
}