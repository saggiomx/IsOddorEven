using System;
using Xunit;
using Saggiomx.IsOddorEven.Api.Main.Controllers;
using Microsoft.Extensions.Logging;
using Moq;
using Microsoft.AspNetCore.Mvc;

namespace Saggiomx.IsOddorEven.Api.Main.Tests.Controllers
{
    public class HealthControllerTests
    {
        private Mock<ILogger<HealthController>> _mockLogger;
        private HealthController _healthController;
        public HealthControllerTests()
        {
            _mockLogger = new Mock<ILogger<HealthController>>();
        }

        [Fact]
        public void HealthController_Constructor_ArgumentNullException()
        {
            Assert.Throws<ArgumentNullException>(() => new HealthController(null));
        }

        [Fact]
        public void HealthController_Constructor_Success()
        {
            _healthController = new HealthController(_mockLogger.Object);

            Assert.NotNull(_healthController);
            Assert.IsType<HealthController>(_healthController);
        }

        [Fact]
        public void HealthController_Get_Success()
        {
            _healthController = new HealthController(_mockLogger.Object);

            var result = _healthController.Ok();

            Assert.NotNull(result);
            Assert.IsType<OkResult>(result);
            Assert.Equal(200, result.StatusCode);
        }
    }
}
