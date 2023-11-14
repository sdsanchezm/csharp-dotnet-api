using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using webapi.Data;
using webapi.Services;

namespace webapi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class HelloWorldController : ControllerBase
    {

        IHelloWorldService helloWorldService;

        ToDoContext _todoContext;

        private readonly ILogger<HelloWorldController> _logger;

        public HelloWorldController(IHelloWorldService helloWorld, ILogger<HelloWorldController> logger, ToDoContext todoContext)
        {
            _logger = logger;
            helloWorldService = helloWorld;
            _todoContext = todoContext;
        }

        [HttpGet]
        public IActionResult Get()
        {
            _logger.LogInformation("returning the list, from the HelloWorldController, using get method...");
            return Ok(helloWorldService.GetHelloWorld());
        }

        [HttpGet("test/{x}")]
        public IActionResult Get(string x)
        {
            return Ok($"result: {x}");
        }

        [HttpGet]
        [Route("dbsetup")]
        public IActionResult DatabaseConnect(string x)
        {
            _todoContext.Database.EnsureCreated();
            return Ok($"Done!");
        }
    }
}
