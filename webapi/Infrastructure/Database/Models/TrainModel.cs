namespace webapi.Infrastructure.Database.Models
{
    public class TrainModel
    {
        public int Id { get; set; }
        public string Name { get; set; } = "";
        public bool ReadyForUsing { get; set; }
        public int ParentElementId { get; set; }
        public virtual TrainModelElement ParentElement { get; set; } = new TrainModelElement();
        public virtual ICollection<TrainModelElement>? Elements { get; set; }
        public virtual ICollection<Train>? Trains { get; set; }
    }
}