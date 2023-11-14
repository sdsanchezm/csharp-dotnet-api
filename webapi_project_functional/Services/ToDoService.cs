using Microsoft.EntityFrameworkCore.Diagnostics;
using webapi_project_functional.Data;
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

            var categ = _dbContext.Categories.Where(c => c.CategoryId  == t.CategoryId).FirstOrDefault();
            //_dbContext.Categories.Find(p => p.id == t.CategoryId.ToString());

            //t.ToDoId = Guid.NewGuid();
            t.ToDoId = Guid.Parse(t.ToDoId.ToString());
            t.CategoryId = Guid.Parse(t.CategoryId.ToString());
            t.ToDoCreationDate = DateTime.Now;
            t.Category = categ;


            _dbContext.Add(t);
            await _dbContext.SaveChangesAsync();

            //listTodoInitial.Add(new ToDo() { ToDoId =
            //    Guid.Parse("2fd96e87-dba7-4f3f-972a-061956553d08"),
            //    CategoryId = Guid.Parse("cc24924b-7626-4ab7-b06d-d292880d30ff"),
            //    ToDoName = "Email Reminder",
            //    ToDoDescription = "Send Email to clients",
            //    ToDoCreationDate = DateTime.Now,
            //    ToDoPriority = Priority.High });
        }

        public async Task Update(Guid id, ToDo t)
        {
            var actualTodo = _dbContext.ToDos.Find(id);

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
