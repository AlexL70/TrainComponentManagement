using System.ComponentModel.DataAnnotations.Schema;

namespace webapi.Infrastructure.Database.Models
{
    public class TrainComponent
    {
        public int Id { get; set; }
        [ForeignKey(nameof(Train))]
        public int TrainId { get; set; }
        public virtual Train Train { get; set; } = new Train();
        [ForeignKey(nameof(Parent))]
        public int? ParentElementId { get; set; }
        public virtual TrainComponent? Parent { get; set; }
        [ForeignKey(nameof(ModelElement))]
        public int ModelElementId { get; set; }
        public virtual TrainModelElement ModelElement { get; set; } = new TrainModelElement();
        [ForeignKey(nameof(InventoryElement))]
        public int InventoryId { get; set; }
        public InventoryPart InventoryElement { get; set; } = new InventoryPart();
        public virtual ICollection<TrainComponent> Children { get; set; } = new List<TrainComponent>();
        public string SerialNumber => InventoryElement.SerialNumber;
    }
}