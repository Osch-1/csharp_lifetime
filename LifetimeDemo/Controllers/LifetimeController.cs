using Microsoft.AspNetCore.Mvc;
using LifetimeDemo.Services;

namespace LifetimeDemo.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class LifetimeController : ControllerBase
    {
        private readonly ISingletonService _singletonService;
        private readonly IScopedService _scopedService;
        private readonly ITransientService _transientService;

        public LifetimeController(
            ISingletonService singletonService,
            IScopedService scopedService,
            ITransientService transientService)
        {
            _singletonService = singletonService;
            _scopedService = scopedService;
            _transientService = transientService;
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(new
            {
                Singleton = _singletonService.Id,
                Scoped = _scopedService.Id,
                Transient = _transientService.Id
            });
        }
    }
}
