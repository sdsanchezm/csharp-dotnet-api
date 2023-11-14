using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace webapi.Models
{
    public class Category
    {
        public Guid CategoryId { get; set; }
        public string CategoryName { get; set; }
        public string CategoryDescription { get; set; }
        public int CategoryLevel { get; set; }

        //[JsonIgnore]
        public virtual ICollection<ToDo> ToDos { get; set; }
    }
}
