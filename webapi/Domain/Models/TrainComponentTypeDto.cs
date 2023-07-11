using webapi.Domain.Models.Abstract;

namespace webapi.Domain.Models
{
    public class TrainComponentTypeDto : IModelWithId<int>
    {
        public int Id { get; set; }
        public string Name { get; set; } = "";
        public bool IsRoot { get; set; }
        public bool CanAssignQuantity { get; set; }
        public List<TrainComponentBrandDto> Brands { get; set; } = new List<TrainComponentBrandDto>();
        public List<TrainComponentTypeListDto> CanHaveParents { get; set; } = new List<TrainComponentTypeListDto>();
        public List<TrainComponentTypeListDto> CanHaveChildren { get; set; } = new List<TrainComponentTypeListDto>();
    }
}