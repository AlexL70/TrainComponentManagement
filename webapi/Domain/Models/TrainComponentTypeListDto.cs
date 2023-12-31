using webapi.Domain.Models.Abstract;

namespace webapi.Domain.Models
{
    public class TrainComponentTypeListDto : IModelWithId<int>
    {
        public int Id { get; set; }
        public string Name { get; set; } = "";
        public bool IsRoot { get; set; }
        public bool CanAssignQuantity { get; set; }
    }
}