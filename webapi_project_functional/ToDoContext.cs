using Microsoft.EntityFrameworkCore;
using webapi_project_functional.Models;

namespace webapi_project_functional
{
    public class ToDoContext : DbContext
    {
        public DbSet<Category> Categories { get; set; }
        public DbSet<ToDo> ToDos { get; set; }

        public ToDoContext(DbContextOptions<ToDoContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            List<Category> listCategoryInitial = new List<Category>();

            listCategoryInitial.Add(new Category() { CategoryId = Guid.Parse("cc24924b-7626-4ab7-b06d-d292880d30ff"), CategoryName = "Important Tasks", CategoryDescription = "just important tasks", CategoryLevel = 90 });
            listCategoryInitial.Add(new Category() { CategoryId = Guid.Parse("cc24924b-7626-4ab7-b06d-d292880d3021"), CategoryName = "Regular Tasks", CategoryDescription = "medium tasks", CategoryLevel = 40 });

            modelBuilder.Entity<Category>(category =>
            {
                category.ToTable("Category");
                category.HasKey(p => p.CategoryId);
                category.Property(p => p.CategoryName).IsRequired().HasMaxLength(100);
                category.Property(p => p.CategoryDescription);
                category.Property(p => p.CategoryLevel);
                // initial data
                category.HasData(listCategoryInitial);
            });

            List<ToDo> listTodoInitial = new List<ToDo>();

            listTodoInitial.Add(new ToDo() { ToDoId = Guid.Parse("2fd96e87-dba7-4f3f-972a-061956553d08"), CategoryId = Guid.Parse("cc24924b-7626-4ab7-b06d-d292880d30ff"), ToDoName = "Email Reminder", ToDoDescription = "Send Email to clients", ToDoCreationDate = DateTime.Now, ToDoPriority = Priority.High });

            modelBuilder.Entity<ToDo>(todo =>
            {
                todo.ToTable("ToDo");
                todo.HasKey(p => p.ToDoId);
                todo.HasOne(p => p.Category).WithMany(p => p.ToDos).HasForeignKey(p => p.CategoryId);
                todo.Property(p => p.ToDoName).IsRequired().HasMaxLength(100);
                todo.Property(p => p.ToDoDescription).IsRequired(false);
                todo.Property(p => p.ToDoPriority);
                todo.Property(p => p.ToDoCreationDate);
                todo.Ignore(p => p.Summary);
                // initial data
                todo.HasData(listTodoInitial);
            });
        }
    }
}
