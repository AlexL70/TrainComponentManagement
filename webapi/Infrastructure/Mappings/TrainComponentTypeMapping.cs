using webapi.Domain.Models;
using webapi.Domain.Services.Abstract;
using webapi.Infrastructure.Database.Models;

namespace webapi.Infrastructure.Mappings
{
    public class TrainComponentTypeMapping : IEntityDtoMapping<TrainComponentType, TrainComponentTypeDto>
    {
        public Func<TrainComponentType, TrainComponentTypeDto> from =>
            _ => new TrainComponentTypeDto {
                Id = _.Id,
                Name = _.Name,
                IsRoot = _.IsRoot,
                CanAssignQuantity = _.CanAssignQuantity,
            };

        public Func<TrainComponentTypeDto, TrainComponentType> to =>
            _ => new TrainComponentType {
                Id = _.Id,
                Name = _.Name,
                IsRoot = _.IsRoot,
                CanAssignQuantity = _.CanAssignQuantity,
            };
    }
}