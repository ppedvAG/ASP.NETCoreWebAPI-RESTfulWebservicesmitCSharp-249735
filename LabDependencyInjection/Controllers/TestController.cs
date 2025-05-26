using Lab002_DependencyInjection.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LabDependencyInjection.Controllers
{
    [ApiController]
    public class TestController : ControllerBase
    {
        private readonly ILogger<TestController> _logger;
        private readonly IOperationScoped _scoped;
        private readonly IOperationTransient _transient;
        private readonly IOperationSingleton _singleton;

        public TestController(
            ILogger<TestController> logger, 
            IOperationScoped scoped, 
            IOperationTransient transient, 
            IOperationSingleton singleton
            )
        {
            _logger = logger;
            _scoped = scoped;
            _transient = transient;
            _singleton = singleton;
        }

        [HttpGet]
        [Route("/")]
        public IActionResult Index(
            [FromServices] IOperationScoped scoped, 
            [FromServices] IOperationTransient transient, 
            [FromServices] IOperationSingleton singleton
            )
        {
            _logger.LogInformation("Transient\t\t{Transient}", _transient.OperationId);
            _logger.LogInformation("Transient (local)\t{Transient}", transient.OperationId);
            _logger.LogInformation("Scoped\t\t{Scoped}", _scoped.OperationId);
            _logger.LogInformation("Scoped (local)\t{Scoped}", scoped.OperationId);
            _logger.LogInformation("Singleton\t\t{Singleton}", _singleton.OperationId);
            _logger.LogInformation("Singleton (local)\t{Singleton}", singleton.OperationId);

            return Content("Check logs in the console");
        }
    }
}
