using Microsoft.EntityFrameworkCore;
using webapi.Models;

namespace webapi.Data
{
    public class ToDoContext : DbContext
    {
        public DbSet<Category> Categories { get; set; }
        public DbSet<ToDo> ToDos { get; set; }

        public ToDoContext(DbContextOptions<ToDoContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            List<Category> listCategoryInitial = new List<Category>();
            listCategoryInitial.Add(new Category() { CategoryId = Guid.Parse("5735e94e-8d36-4e9c-882c-295a16597947"), CategoryName = "Important Tasks", CategoryDescription = "just important tasks", CategoryLevel = 90 });

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

            listTodoInitial.Add(new ToDo() { ToDoId = Guid.Parse("5735e94e-8d36-4e9c-882c-295a16597920"), CategoryId = Guid.Parse("5735e94e-8d36-4e9c-882c-295a16597947"), ToDoName = "Watch movie", ToDoDescription = "watch movie in the afternoon", ToDoCreationDate = DateTime.Now, ToDoPriority = Priority.High, });

            modelBuilder.Entity<ToDo>(todo =>
            {
                todo.ToTable("ToDo");
                todo.HasKey(p => p.ToDoId);
                todo.HasOne(p => p.Category).WithMany(p => p.ToDos).HasForeignKey(p => p.CategoryId);
                todo.Property(p => p.ToDoName).IsRequired().HasMaxLength(200);
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
