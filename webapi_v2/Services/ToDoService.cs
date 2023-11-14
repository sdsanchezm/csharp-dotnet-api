using Microsoft.EntityFrameworkCore.Diagnostics;
using webapi.Data;
using webapi.Models;

namespace webapi.Services
{
    public class ToDoService : IToDoService
    {
        // scooped var type ToDoContext
        ToDoContext context;

        // ctor to include the context
        public ToDoService(ToDoContext dbContext)
        {
            context = dbContext;
        }

        // Get method
        public IEnumerable<ToDo> Get()
        {
            return context.ToDos;
        }

        public async Task Save(ToDo t)
        {
            context.ToDos.Add(t);
            await context.SaveChangesAsync();
        }

        public async Task Update(Guid id, ToDo t)
        {
            var actualTodo = await context.ToDos.FindAsync(id);

            if (actualTodo != null)
            {
                actualTodo.ToDoName = t.ToDoName;
                actualTodo.ToDoDescription = t.ToDoDescription;
                actualTodo.ToDoPriority = t.ToDoPriority;

                await context.SaveChangesAsync();
            }

        }

        public async Task Delete(Guid id)
        {
            var actualTodo = await context.ToDos.FindAsync(id);

            if ( actualTodo != null )
            {
                context.ToDos.Remove(actualTodo);
                await context.SaveChangesAsync();
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
