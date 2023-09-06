

namespace webapi_project_functional.Models
{
    public class ToDo
    {
        public Guid ToDoId { get; set; }
        public Guid CategoryId { get; set; }
        public string ToDoName { get; set; }
        public string ToDoDescription { get; set; }
        public Priority ToDoPriority { get; set; }
        public DateTime ToDoCreationDate { get; set; }
        public virtual Category Category { get; set; }
        public string Summary { get; set; }

    }

    public enum Priority
    {
        High,
        Medium,
        Low
    }
}