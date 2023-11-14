using Microsoft.AspNetCore.Mvc;
using webapi.Services;

namespace webapi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class HelloWorldController : ControllerBase
    {

        IHelloWorldService helloWorldService;
        private readonly ILogger<HelloWorldController> _logger;

        public HelloWorldController(IHelloWorldService helloWorld, ILogger<HelloWorldController> logger)
        {
            _logger = logger;
            helloWorldService = helloWorld;
        }

        [HttpGet]
        public IActionResult Get()
        {
            _logger.LogInformation("returning the list, from the HelloWorldController, using get method...");
            return Ok(helloWorldService.GetHelloWorld());
        }
    }
}
