using System.ComponentModel.DataAnnotations.Schema;

namespace webapi.Infrastructure.Database.Models
{ 
    public class TrainComponentTypeRelation
    {
        public int ParentTypeId { get; set; }
        public TrainComponentType? ParentType { get; set; }
        public int ChildTypeId { get; set; }
        public TrainComponentType? ChildType { get; set; }
    }
}