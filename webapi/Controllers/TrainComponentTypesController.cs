using Microsoft.AspNetCore.Mvc;
using webapi.Domain.Models;
using webapi.Domain.Services.Interfaces;
namespace webapi.Controllers
{
    [ApiController]
    [Route("api/component-types")]
    public class TrainComponentTypesController
    {
        private ITrainComponentTypeService _service;

        public TrainComponentTypesController(ITrainComponentTypeService service)
        {
            _service = service;
        }

        [HttpGet("get-list")] 
        public IEnumerable<TrainComponentTypeListDto> GetTypes()
        {
            return _service.GetComponentTypes();
        }

        [HttpGet("get-one/{Id}")]
        public TrainComponentTypeDto GetType(int Id)
        {
            return _service.Get(Id) ?? new TrainComponentTypeDto();
        }
    }
}