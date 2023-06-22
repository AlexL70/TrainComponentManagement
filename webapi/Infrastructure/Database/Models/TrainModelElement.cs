using System.ComponentModel.DataAnnotations.Schema;

namespace webapi.Infrastructure.Database.Models
{ 
    public class TrainModelElement
    {
        public int Id { get; set; }
        [ForeignKey(nameof(Model))]
        public int ModelId { get; set; }
        public virtual TrainModel Model { get; set; } = new TrainModel();
        [ForeignKey(nameof(Brand))]
        public int BrandId { get; set; }
        public virtual TrainComponentBrand Brand { get; set; } = new TrainComponentBrand();
        [ForeignKey(nameof(Parent))]
        public int? ParentId { get; set; }
        public virtual TrainModelElement? Parent { get; set; }
        public int Quantity { get; set; } = 1;
        public virtual ICollection<TrainModelElement> Children { get; set; } = new List<TrainModelElement>();
        [NotMapped]
        public bool IsRoot => Brand.IsRoot;
        [NotMapped]
        public bool CanAssignQuantity => Brand.CanAssignQuantity;
    }
}
