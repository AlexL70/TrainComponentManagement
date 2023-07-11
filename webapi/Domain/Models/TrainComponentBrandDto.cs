using webapi.Domain.Models.Abstract;

namespace webapi.Domain.Models
{
    public class TrainComponentBrandDto : IModelWithId<int>
    {
        public int Id { get; set; }
        public string Name { get; set; } = String.Empty;
        public string UniqueNumMask { get; set; } = String.Empty;
        public int TypeId { get; set; }
        public bool IsRoot { get; set; }
        public bool CanAssignQuantity { get; set; }
        public string TypeName { get; set; } = String.Empty;
    }
}