using Microsoft.EntityFrameworkCore.Update.Internal;
using webapi_project_functional.Models;

namespace webapi_project_functional.Services
{
    public class CategoryService : ICategoryService
    {
        ToDoContext _dbContext;

        public CategoryService(ToDoContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IEnumerable<Category> Get()
        {
            return _dbContext.Categories;
        }

        public void Save(Category c)
        {
            _dbContext.Add(c);
            _dbContext.SaveChanges();
        }

        public async Task Update(Guid id, Category c)
        {
            var actualCategory = _dbContext.Categories.Find(id);

            if (actualCategory != null)
            {
                actualCategory.CategoryName = c.CategoryName;
                actualCategory.CategoryDescription = c.CategoryDescription;
                actualCategory.CategoryLevel = c.CategoryLevel;

                await _dbContext.SaveChangesAsync();
            }
        }

        public void Delete(Guid id)
        {
            var actualCategory = _dbContext.Categories.Find(id);
            if (actualCategory != null)
            {
                _dbContext.Remove(actualCategory);
                _dbContext.SaveChanges();
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
