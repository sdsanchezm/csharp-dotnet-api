using Microsoft.AspNetCore.Mvc;
using webapi_project_functional.Models;
using webapi_project_functional.Services;

namespace webapi_project_functional.Controllers
{
    [Route("api/[controller]")]
    public class CategoryController : ControllerBase
    {
        ICategoryService _categoryServiceLocal;
        public CategoryController(ICategoryService categoryServiceLocal)
        {
            _categoryServiceLocal = categoryServiceLocal;
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_categoryServiceLocal.Get());
        }

        [HttpPost]
        public IActionResult Post([FromBody] Category c)
        {
            _categoryServiceLocal.Save(c);
            return Ok();
        }

        [HttpPut("{id}")]
        public IActionResult Put([FromBody] Category c, Guid id)
        {
            _categoryServiceLocal.Update(id, c);
            return Ok();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(Guid id)
        {
            _categoryServiceLocal.Delete(id);
            return Ok();
        }


    }
}