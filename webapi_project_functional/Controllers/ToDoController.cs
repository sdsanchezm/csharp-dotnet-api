using Microsoft.AspNetCore.Mvc;
using webapi_project_functional.Models;
using webapi_project_functional.Services;

namespace webapi_project_functional.Controllers
{
    [Route("api/[controller]")]
    public class ToDoController : ControllerBase
    {

        IToDoService _todoServiceLocal;

        public ToDoController(IToDoService todoServiceLocal)
        {
            _todoServiceLocal = todoServiceLocal;
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_todoServiceLocal.Get());
        }

        [HttpPost]
        public IActionResult Post([FromBody] ToDo t)
        {
            if (ModelState.IsValid)
            {
                _todoServiceLocal.Save(t);
                return Ok();
            }
            return BadRequest();
        }

        [HttpPut("{id}")]
        public IActionResult Put(Guid id, [FromBody] ToDo t)
        {
            _todoServiceLocal.Update(id, t);
            return Ok();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(Guid id)
        {
            _todoServiceLocal.Delete(id);
            return Ok();
        }
    }
}