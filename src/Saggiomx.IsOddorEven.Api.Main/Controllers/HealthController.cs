using System;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Saggiomx.IsOddorEven.Api.Main.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class HealthController : ControllerBase
    {
        private readonly ILogger<HealthController> _logger;

        public HealthController(ILogger<HealthController> logger)
        {
            _logger = logger ?? throw new ArgumentNullException(nameof(HealthController));
        }

        [HttpGet]
        public IActionResult Get() => Ok();
    }
}
