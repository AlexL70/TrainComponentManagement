namespace webapi.Infrastructure.Database.Models
{ 
    public class TrainComponentTypeRelation
    {
        public int ParentTypeId { get; set; }
        public int ChildTypeId { get; set; }
    }
}