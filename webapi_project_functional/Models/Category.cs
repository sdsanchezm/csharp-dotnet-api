namespace webapi_project_functional.Models
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