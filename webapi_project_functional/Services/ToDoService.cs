using Microsoft.EntityFrameworkCore.Diagnostics;
using webapi_project_functional.Models;

namespace webapi_project_functional.Services
{
    public class ToDoService : IToDoService
    {
        ToDoContext _dbContext;

        public ToDoService(ToDoContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IEnumerable<ToDo> Get()
        {
            return _dbContext.ToDos;
        }

        public async Task Save(ToDo t)
        {
            _dbContext.ToDos.Add(t);
            await _dbContext.SaveChangesAsync();
        }

        public async Task Update(Guid id, ToDo t)
        {
            var actualTodo = await _dbContext.ToDos.FindAsync(id);

            if (actualTodo != null)
            {
                actualTodo.ToDoName = t.ToDoName;
                actualTodo.ToDoDescription = t.ToDoDescription;
                actualTodo.ToDoPriority = t.ToDoPriority;

                await _dbContext.SaveChangesAsync();
            }

        }

        public async Task Delete(Guid id)
        {
            var actualTodo = await _dbContext.ToDos.FindAsync(id);

            if (actualTodo != null)
            {
                _dbContext.ToDos.Remove(actualTodo);
                await _dbContext.SaveChangesAsync();
            }
        }

    }

    public interface IToDoService
    {
        IEnumerable<ToDo> Get();
        Task Save(ToDo t);
        Task Update(Guid id, ToDo t);
        Task Delete(Guid id);
    }
}
