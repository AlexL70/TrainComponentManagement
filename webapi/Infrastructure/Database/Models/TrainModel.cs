using System.ComponentModel.DataAnnotations.Schema;

namespace webapi.Infrastructure.Database.Models
{
    public class TrainModel
    {
        public int Id { get; set; }
        public string Name { get; set; } = "";
        public bool ReadyForUsing { get; set; }
        [ForeignKey(nameof(ParentElement))]
        public int ParentElementId { get; set; }
        public virtual TrainModelElement ParentElement { get; set; } = new TrainModelElement();
    }
}