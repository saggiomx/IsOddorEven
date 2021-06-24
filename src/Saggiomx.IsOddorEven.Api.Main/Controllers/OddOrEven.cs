
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Saggiomx.IsOddorEven.Api.Main.Controllers
{
    [ApiController]
    [Route("")]
    public class OddOrEvenController : ControllerBase
    {
        private readonly ILogger<OddOrEvenController> _logger;

        public OddOrEvenController(ILogger<OddOrEvenController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        [Route("IsOddOrEven/{number}")]
        public IActionResult IsOddOrEven(int number) => HasReminder(number, 2) ? Ok("Odd") : Ok("Even");

        [HttpGet]
        [Route("IsOdd/{number}")]
        public bool IsOdd(int number) => HasReminder(number, 2);

        [HttpGet]
        [Route("IsEven/{number}")]
        public bool IsEven(int number) => !HasReminder(number, 2);

        private bool HasReminder(int dividend, int divisor) => dividend % divisor != 0;
    }
}
