namespace webapi.Infrastructure.Database.Models
{ 
    public class TrainModelElement
    {
        public int Id { get; set; }
        public int ModelId { get; set; }
        public virtual TrainModel Model { get; set; } = new TrainModel();
        public int BrandId { get; set; }
        public virtual TrainComponentBrand Brand { get; set; } = new TrainComponentBrand();
        public int? ParentId { get; set; }
        public virtual TrainModelElement? Parent { get; set; }
        public int Quantity { get; set; } = 1;
        public virtual ICollection<TrainModelElement> Children { get; set; } = new List<TrainModelElement>();
        public virtual ICollection<TrainComponent>? TrainComponents { get; set; }
        public virtual ICollection<TrainModel>? ModelsWhereParentIs { get; set; }
        public bool IsRoot => Brand.IsRoot;
        public bool CanAssignQuantity => Brand.CanAssignQuantity;
    }
}
