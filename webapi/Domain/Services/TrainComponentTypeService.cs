using webapi.Domain.Models;
using webapi.Domain.Repositories;
using webapi.Domain.Services.Abstract;
using webapi.Domain.Services.Interfaces;
using webapi.Infrastructure.Database.Models;

namespace webapi.Domain.Services
{
    public class TrainComponentTypeService : GetService<int, TrainComponentTypeDto, TrainComponentType>, ITrainComponentTypeService
    {
        protected new ITrainComponentTypesRepository _repository => (ITrainComponentTypesRepository)base._repository;
        public TrainComponentTypeService(ITrainComponentTypesRepository repository,
            IEntityDtoMapping<TrainComponentType, TrainComponentTypeDto> mapping)
                : base(repository, mapping) { }

        public IEnumerable<TrainComponentTypeListDto> GetComponentTypes()
        {
            return _repository.GetComponentTypes();
        }
    }
}