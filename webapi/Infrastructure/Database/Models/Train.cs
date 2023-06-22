using System.ComponentModel.DataAnnotations.Schema;

namespace webapi.Infrastructure.Database.Models
{
    public class Train
    {
        public int Id { get; set; }
        [ForeignKey(nameof(RootElement))]
        public int RootElementId { get; set; }
        public virtual TrainComponent RootElement { get; set; } = new TrainComponent();
        [ForeignKey(nameof(Model))]
        public int ModelId { get; set; }
        public virtual TrainModel Model { get; set; } = new TrainModel();
        [NotMapped]
        public string SerialNumber => RootElement.SerialNumber;
    }
}