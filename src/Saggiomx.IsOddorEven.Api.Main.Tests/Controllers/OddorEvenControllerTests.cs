using System;
using Xunit;
using Saggiomx.IsOddorEven.Api.Main.Controllers;
using Microsoft.Extensions.Logging;
using Moq;
using Microsoft.AspNetCore.Mvc;

namespace Saggiomx.IsOddorEven.Api.Main.Tests.Controllers
{
    public class OddorEvenControllerTests
    {
        private Mock<ILogger<OddOrEvenController>> _mockLogger;
        private OddOrEvenController _oddOrEvenController;

        public OddorEvenControllerTests()
        {
            _mockLogger = new Mock<ILogger<OddOrEvenController>>();
        }

        [Fact]
        public void OddOrEvenController_Constructor_ArgumentNullException()
        {
            Assert.Throws<ArgumentNullException>(() => new OddOrEvenController(null));
        }

        [Fact]
        public void OddOrEvenController_Constructor_Success()
        {
            _oddOrEvenController = new OddOrEvenController(_mockLogger.Object);

            Assert.NotNull(_oddOrEvenController);
            Assert.IsType<OddOrEvenController>(_oddOrEvenController);
        }

        [Theory]
        [InlineData(2, true)]
        [InlineData(3, false)]
        public void OddOrEvenController_IsEven(int value, bool expected)
        {
            _oddOrEvenController = new OddOrEvenController(_mockLogger.Object);

            var result = _oddOrEvenController.IsEven(value);

            Assert.IsType<bool>(result);
            Assert.Equal(result, expected);
        }

        [Theory]
        [InlineData(2, false)]
        [InlineData(3, true)]
        public void OddOrEvenController_IsOdd(int value, bool expected)
        {
            _oddOrEvenController = new OddOrEvenController(_mockLogger.Object);

            var result = _oddOrEvenController.IsOdd(value);

            Assert.IsType<bool>(result);
            Assert.Equal(result, expected);
        }

        [Theory]
        [InlineData(2, "Even")]
        [InlineData(3, "Odd")]
        public void OddOrEvenController_IsOddOrEven_Ok(int value, string expected)
        {
            _oddOrEvenController = new OddOrEvenController(_mockLogger.Object);

            var result = _oddOrEvenController.IsOddOrEven(value);

            Assert.IsType<OkObjectResult>(result);

            var okResult = result as OkObjectResult;
            Assert.NotNull(okResult);
            Assert.Equal(200, okResult.StatusCode);
            Assert.Equal(expected, okResult.Value);
        }
    }
}
