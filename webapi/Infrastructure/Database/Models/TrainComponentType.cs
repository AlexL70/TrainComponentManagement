namespace webapi.Infrastructure.Database.Models
{
    public class TrainComponentType
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public bool CanAssignQuantity { get; set; }
    }
}
