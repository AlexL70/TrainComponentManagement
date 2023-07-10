namespace webapi.Domain.Models
{
    public class TrainComponentTypeListDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = "";
        public bool IsRoot { get; set; }
        public bool CanAssignQuantity { get; set; }
    }
}