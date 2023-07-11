using webapi.Domain.Models;
using webapi.Domain.Services.Abstract;

namespace webapi.Domain.Services.Interfaces
{
    public interface ITrainComponentTypeService : IGetService<int, TrainComponentTypeDto>
    {
        public IEnumerable<TrainComponentTypeListDto> GetComponentTypes(); 
    }
}