

using System.Diagnostics.CodeAnalysis;
using System.Text.Json.Serialization;

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
        //[JsonIgnore]
        [AllowNull]
        public virtual Category Category { get; set; } = null;
        public string Summary { get; set; } = "";

    }

    public enum Priority
    {
        High,
        Medium,
        Low
    }
}