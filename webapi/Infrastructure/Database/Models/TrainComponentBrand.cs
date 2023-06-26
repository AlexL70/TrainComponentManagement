using System.ComponentModel.DataAnnotations.Schema;

namespace webapi.Infrastructure.Database.Models {
    public class TrainComponentBrand {
        public int Id { get; set; }
        public string Name { get; set; } = String.Empty;
        public string UniqueNumMask { get; set; } = String.Empty;
        [ForeignKey(nameof(Type))]
        public int TypeId { get; set; }
        public virtual TrainComponentType? Type { get; set; }
        [NotMapped]
        public bool IsRoot => Type?.IsRoot ?? false;
        [NotMapped]
        public bool CanAssignQuantity => Type?.CanAssignQuantity ?? false;
        [NotMapped]
        public string TypeName => Type?.Name ?? "";
    }
}
