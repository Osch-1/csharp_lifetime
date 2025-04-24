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
        private readonly IServiceProvider _serviceProvider;

        public LifetimeController(
            ISingletonService singletonService,
            IScopedService scopedService,
            ITransientService transientService,
            IServiceProvider serviceProvider)
        {
            _singletonService = singletonService;
            _scopedService = scopedService;
            _transientService = transientService;
            _serviceProvider = serviceProvider;
        }

        [HttpGet("singleton")]
        public IActionResult GetSingleton()
        {
            var singleton2 = (ISingletonService)_serviceProvider.GetService(typeof(ISingletonService));
            return Ok(new
            {
                Singleton_1 = _singletonService.Id,
                Singleton_2 = singleton2?.Id
            });
        }

        [HttpGet("scoped")]
        public IActionResult GetScoped()
        {
            var scoped2 = (IScopedService)_serviceProvider.GetService(typeof(IScopedService));
            return Ok(new
            {
                Scoped_1 = _scopedService.Id,
                Scoped_2 = scoped2?.Id
            });
        }

        [HttpGet("transient")]
        public IActionResult GetTransient()
        {
            var transient2 = (ITransientService)_serviceProvider.GetService(typeof(ITransientService));
            return Ok(new
            {
                Transient_1 = _transientService.Id,
                Transient_2 = transient2?.Id
            });
        }
    }
}
