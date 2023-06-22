using System.ComponentModel.DataAnnotations.Schema;

namespace webapi.Infrastructure.Database.Models {
    public class TrainComponentBrand {
        public int Id { get; set; }
        public string Name { get; set; } = String.Empty;
        public string UniqueNumMask { get; set; } = String.Empty;
        [ForeignKey(nameof(Type))]
        public int TypeId { get; set; }
        public virtual TrainComponentType Type { get; set; } = new TrainComponentType();
        [NotMapped]
        public bool IsRoot => Type.IsRoot;
        [NotMapped]
        public bool CanAssignQuantity => Type.CanAssignQuantity;
        [NotMapped]
        public string TypeName => Type.Name;
    }
}
