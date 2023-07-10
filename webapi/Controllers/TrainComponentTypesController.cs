using Microsoft.AspNetCore.Mvc;
using webapi.Domain.Repositories;
using webapi.Infrastructure.Database.Models;

namespace webapi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TrainComponentTypesController
    {
        private ITrainComponentTypesRepository _repository;

        public TrainComponentTypesController(ITrainComponentTypesRepository repository)
        {
            _repository = repository;
        }

        [HttpGet(Name = "GetTrainComponentTypes")] 
        public IEnumerable<TrainComponentType> GetTypes()
        {
            return _repository.GetComponentTypes();
        }
    }
}