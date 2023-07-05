namespace webapi.Infrastructure.Database.Models {
    public class TrainComponentBrand {
        public int Id { get; set; }
        public string Name { get; set; } = String.Empty;
        public string UniqueNumMask { get; set; } = String.Empty;
        public int TypeId { get; set; }
        public virtual TrainComponentType? Type { get; set; }
        public virtual ICollection<TrainModelElement>? ModelElements { get; set; }
        public virtual ICollection<InventoryPart>? Inventory { get; set; }
        public bool IsRoot => Type?.IsRoot ?? false;
        public bool CanAssignQuantity => Type?.CanAssignQuantity ?? false;
        public string TypeName => Type?.Name ?? "";
    }
}
