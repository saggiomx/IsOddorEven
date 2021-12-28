
using System;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Saggiomx.IsOddorEven.Api.Main.Model;
using Saggiomx.IsOddorEven.Api.Main.Servic;
using Saggiomx.IsOddorEven.Api.Main.Validator;

namespace Saggiomx.IsOddorEven.Api.Main.Controllers
{
    [ApiController]
    [Route("")]
    public class OddOrEvenController : ControllerBase
    {
        private readonly INumberValidator _numberValidator;
        private readonly IIsOddOrEvenService _isOddOrEvenService;
        private readonly ILogger<OddOrEvenController> _logger;

        public OddOrEvenController(INumberValidator numberValidator, IIsOddOrEvenService isOddOrEvenService,ILogger<OddOrEvenController> logger)
        {
            _numberValidator = numberValidator ?? throw new ArgumentNullException(nameof(numberValidator));
            _isOddOrEvenService = isOddOrEvenService ?? throw new ArgumentNullException(nameof(isOddOrEvenService));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        [HttpGet]
        [Route("IsOddOrEven/{number}")]
        public IActionResult IsOddOrEven(string number)
        {
            if (!_numberValidator.IsValid(number))
                return BadRequest(new ErrorResponse("#400BadRequest","The supplied Value is not Valid", "httpS//www.MoreInfo.com"));
            return _isOddOrEvenService.HasReminder(Convert.ToInt32(number), 2) ? Ok("Odd") : Ok("Even");
        }

        [HttpGet]
        [Route("IsOdd/{number}")]
        public IActionResult IsOdd(string number)
        {
            if (!_numberValidator.IsValid(number))
                return BadRequest(new ErrorResponse("#400BadRequest", "The supplied Value is not Valid", "httpS//www.MoreInfo.com"));
            return Ok(_isOddOrEvenService.HasReminder(Convert.ToInt32(number), 2));
        }

        [HttpGet]
        [Route("IsEven/{number}")]
        public IActionResult IsEven(string number)
        {
            if (!_numberValidator.IsValid(number))
                return BadRequest(new ErrorResponse("#400BadRequest", "The supplied Value is not Valid", "httpS//www.MoreInfo.com"));
            return Ok(!_isOddOrEvenService.HasReminder(Convert.ToInt32(number), 2));
        }
    }
}
