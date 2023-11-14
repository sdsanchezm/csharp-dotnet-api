using Microsoft.EntityFrameworkCore.Update.Internal;
using webapi.Data;
using webapi.Models;

namespace webapi.Services
{
    public class CategoryService : ICategoryService
    {
        // everything in the base of the projhect, will be received here in context:
        ToDoContext context;

        public CategoryService(ToDoContext dbContext)
        {
            context = dbContext;
        }

        public IEnumerable<Category> Get()
        {
            return context.Categories;
        }

        public void Save(Category c)
        {
            context.Add(c);
            context.SaveChanges();

            // Async version:
            //public async void Save(Category c) // in the definition of the method
            //await context.SaveChangesAsync(); 
        }

        public async Task Update(Guid id, Category c)
        {
            var actualCategory = context.Categories.Find(id);

            if (actualCategory != null)
            {
                actualCategory.CategoryName = c.CategoryName;
                actualCategory.CategoryDescription = c.CategoryDescription;
                actualCategory.CategoryLevel = c.CategoryLevel;

                await context.SaveChangesAsync();
            }
        }

        public void Delete(Guid id)
        {
            var actualCategory = context.Categories.Find(id);
            if (actualCategory != null)
            {
                context.Remove(actualCategory);
                context.SaveChanges();
            }
        }


    }

    public interface ICategoryService
    {
        IEnumerable<Category> Get();
        void Save(Category c);
        Task Update(Guid id, Category c);
        void Delete(Guid id);
    }
}
