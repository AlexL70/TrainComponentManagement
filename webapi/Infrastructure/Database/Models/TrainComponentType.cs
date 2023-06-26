namespace webapi.Infrastructure.Database.Models
{
    public class TrainComponentType
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public bool IsRoot { get; set; }
        public bool CanAssignQuantity { get; set; }
        public virtual ICollection<TrainComponentBrand> BrandsAvailable { get; set; } = new List<TrainComponentBrand>();
        public virtual ICollection<TrainComponentTypeRelation> CanHaveParents { get; set; } = new List<TrainComponentTypeRelation>();
        public virtual ICollection<TrainComponentTypeRelation> CanHaveChildren { get; set; } = new List<TrainComponentTypeRelation>();
    }
}
