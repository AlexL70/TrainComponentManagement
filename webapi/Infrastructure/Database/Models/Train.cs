namespace webapi.Infrastructure.Database.Models
{
    public class Train
    {
        public int Id { get; set; }
        public int RootComponentId { get; set; }
        public virtual TrainComponent RootComponent { get; set; } = new TrainComponent();
        public int ModelId { get; set; }
        public virtual TrainModel Model { get; set; } = new TrainModel();
        public virtual ICollection<TrainComponent>? Components { get; set; }
        public string SerialNumber => RootComponent.SerialNumber;
    }
}