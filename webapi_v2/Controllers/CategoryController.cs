using Microsoft.AspNetCore.Mvc;
using webapi.Services;
using webapi.Models;

namespace webapi.Controllers
{
    [Route("api/[controller]")]
    public class CategoryController : ControllerBase
    {
        ICategoryService categoryServiceLocal;
        public CategoryController(ICategoryService service)
        {
            categoryServiceLocal = service;
        }

        [HttpGet]
        public IActionResult Get()
        {
            // it has to return here
            return Ok(categoryServiceLocal.Get());
        }

        [HttpPost]
        public IActionResult Post([FromBody] Category c)
        {
            // here, no returning anything
            categoryServiceLocal.Save(c);
            return Ok();
        }

        [HttpPut("{id}")]
        public IActionResult Put([FromBody] Category c, Guid id)
        {
            categoryServiceLocal.Update(id, c);
            return Ok();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(Guid id)
        {
            categoryServiceLocal.Delete(id);
            return Ok();
        }


    }
}
