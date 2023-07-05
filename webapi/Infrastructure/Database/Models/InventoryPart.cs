namespace webapi.Infrastructure.Database.Models
{
    public class InventoryPart
    {
        public int Id { get; set; }
        public int BrandId { get; set; }
        public string SerialNumber { get; set; } = "";
        public virtual TrainComponentBrand Brand { get; set; } = new TrainComponentBrand();
        public virtual TrainComponent? TrainComponent { get; set; }
    }
}