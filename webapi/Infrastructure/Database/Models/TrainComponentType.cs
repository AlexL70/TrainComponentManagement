using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace webapi.Infrastructure.Database.Models
{
    public class TrainComponentType
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public bool IsRoot { get; set; }
        public bool CanAssignQuantity { get; set; }
        public virtual ICollection<TrainComponentBrand> BrandsAvailable { get; set; } = new List<TrainComponentBrand>();
        public virtual ICollection<TrainComponentType> CanHaveParents { get; set; } = new List<TrainComponentType>();
        public virtual ICollection<TrainComponentType> CanHaveChildren { get; set; } = new List<TrainComponentType>();
    }
}
