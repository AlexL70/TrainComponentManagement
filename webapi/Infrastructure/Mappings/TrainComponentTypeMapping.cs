using webapi.Domain.Models;
using webapi.Domain.Services.Abstract;
using webapi.Infrastructure.Database.Models;

namespace webapi.Infrastructure.Mappings
{
    public class TrainComponentTypeMapping : IEntityDtoMapping<TrainComponentType, TrainComponentTypeDto>
    {
        public Func<TrainComponentType, TrainComponentTypeDto> from =>
            _ => new TrainComponentTypeDto
            {
                Id = _.Id,
                Name = _.Name,
                IsRoot = _.IsRoot,
                CanAssignQuantity = _.CanAssignQuantity,
                Brands = _.BrandsAvailable.Select(_ => new TrainComponentBrandDto
                {
                    Id = _.Id,
                    Name = _.Name,
                    UniqueNumMask = _.UniqueNumMask,
                    TypeId = _.TypeId,
                    IsRoot = _.IsRoot,
                    TypeName = _.TypeName,
                    CanAssignQuantity = _.CanAssignQuantity,
                }).ToList(),
                CanHaveParents = _.CanHaveParents.Select(_ => _.ParentType).Select(_ => new TrainComponentTypeListDto
                {
                    Id = _.Id,
                    Name = _.Name,
                    IsRoot = _.IsRoot,
                    CanAssignQuantity = _.CanAssignQuantity
                }).ToList(),
                CanHaveChildren = _.CanHaveChildren.Select(_ => _.ChildType).Select(_ => new TrainComponentTypeListDto
                {
                    Id = _.Id,
                    Name = _.Name,
                    IsRoot = _.IsRoot,
                    CanAssignQuantity = _.CanAssignQuantity
                }).ToList(),
            };

        public Func<TrainComponentTypeDto, TrainComponentType> to =>
            _ => new TrainComponentType
            {
                Id = _.Id,
                Name = _.Name,
                IsRoot = _.IsRoot,
                CanAssignQuantity = _.CanAssignQuantity,
            };
    }
}