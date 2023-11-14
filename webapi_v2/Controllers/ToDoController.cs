using Microsoft.AspNetCore.Mvc;
using webapi.Models;
using webapi.Services;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace webapi.Controllers
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
