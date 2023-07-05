namespace webapi.Infrastructure.Database.Models
{
    public class TrainComponent
    {
        public int Id { get; set; }
        public int TrainId { get; set; }
        public virtual Train Train { get; set; } = new Train();
        public int? ParentElementId { get; set; }
        public virtual TrainComponent? Parent { get; set; }
        public int ModelElementId { get; set; }
        public virtual TrainModelElement ModelElement { get; set; } = new TrainModelElement();
        public InventoryPart InventoryElement { get; set; } = new InventoryPart();
        public virtual ICollection<TrainComponent> Children { get; set; } = new List<TrainComponent>();
        public virtual ICollection<Train>? TrainsWhereRootComponentIs { get; set; }
        public string SerialNumber => InventoryElement.SerialNumber;
    }
}