using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace webapi.Models
{
    public class ToDo
    {
        public int Id { get; set; }
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

