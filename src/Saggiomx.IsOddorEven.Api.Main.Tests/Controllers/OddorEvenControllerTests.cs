using System;
using Xunit;
using Saggiomx.IsOddorEven.Api.Main.Controllers;
using Microsoft.Extensions.Logging;
using Moq;
using Microsoft.AspNetCore.Mvc;
using Saggiomx.IsOddorEven.Api.Main.Model;
using Saggiomx.IsOddorEven.Api.Main.Servic;
using Saggiomx.IsOddorEven.Api.Main.Validator;

namespace Saggiomx.IsOddorEven.Api.Main.Tests.Controllers
{
    public class OddorEvenControllerTests
    {
        private Mock<ILogger<OddOrEvenController>> _mockLogger;
        private Mock<INumberValidator> _validator;
        private Mock<IIsOddOrEvenService> _service;
        private OddOrEvenController _oddOrEvenController;

        public OddorEvenControllerTests()
        {
            _mockLogger = new Mock<ILogger<OddOrEvenController>>(MockBehavior.Loose);
            _validator = new Mock<INumberValidator>(MockBehavior.Strict);
            _service = new Mock<IIsOddOrEvenService>();
        }

        [Fact]
        public void OddOrEvenController_Constructor_ArgumentNullException_Validator()
        {
            Assert.Throws<ArgumentNullException>(() => new OddOrEvenController(null, _service.Object, _mockLogger.Object));
        }

        [Fact]
        public void OddOrEvenController_Constructor_ArgumentNullException_Service()
        {
            Assert.Throws<ArgumentNullException>(() => new OddOrEvenController(_validator.Object, null, _mockLogger.Object));
        }

        [Fact]
        public void OddOrEvenController_Constructor_ArgumentNullException_Logger()
        {
            Assert.Throws<ArgumentNullException>(
                () => new OddOrEvenController(_validator.Object, _service.Object, null));
        }

        [Fact]
        public void OddOrEvenController_Constructor_Success()
        {
            _oddOrEvenController = new OddOrEvenController(_validator.Object, _service.Object, _mockLogger.Object);

            Assert.NotNull(_oddOrEvenController);
            Assert.IsType<OddOrEvenController>(_oddOrEvenController);
        }

        [Fact]
        public void OddOrEvenController_IsEven()
        {
            _validator.Setup(v => v.IsValid(It.IsAny<string>())).Returns(true);
            _service.Setup(s => s.HasReminder(It.IsAny<int>(), It.IsAny<int>())).Returns(true);

            _oddOrEvenController = new OddOrEvenController(_validator.Object, _service.Object, _mockLogger.Object);

            var result = _oddOrEvenController.IsEven(It.IsAny<string>());

            var okResult = result as OkObjectResult;
            Assert.NotNull(okResult);
            Assert.Equal(200, okResult.StatusCode);
            Assert.Equal(false, okResult.Value);

            _validator.Verify(v => v.IsValid(It.IsAny<string>()), Times.Once());
            _service.Verify(s => s.HasReminder(It.IsAny<int>(), It.IsAny<int>()), Times.Once());
        }

        [Fact]
        public void OddOrEvenController_400Response()
        {
            _validator.Setup(v => v.IsValid(It.IsAny<string>())).Returns(false);
            _service.Setup(s => s.HasReminder(It.IsAny<int>(), It.IsAny<int>())).Returns(true);

            _oddOrEvenController = new OddOrEvenController(_validator.Object, _service.Object, _mockLogger.Object);

            var result = _oddOrEvenController.IsEven(It.IsAny<string>());

            var errorResult = result as BadRequestObjectResult;
            Assert.NotNull(errorResult);
            Assert.Equal(400, errorResult.StatusCode);
            Assert.IsType<ErrorResponse>(errorResult.Value);

            _validator.Verify(v => v.IsValid(It.IsAny<string>()), Times.Once());
            _service.Verify(s => s.HasReminder(It.IsAny<int>(), It.IsAny<int>()), Times.Never);
        }

        [Fact]
        public void OddOrEvenController_IsOdd()
        {
            _validator.Setup(v => v.IsValid(It.IsAny<string>())).Returns(true);
            _service.Setup(s => s.HasReminder(It.IsAny<int>(), It.IsAny<int>())).Returns(true);

            _oddOrEvenController = new OddOrEvenController(_validator.Object, _service.Object, _mockLogger.Object);

            var result = _oddOrEvenController.IsOdd(It.IsAny<string>());

            var okResult = result as OkObjectResult;
            Assert.NotNull(okResult);
            Assert.Equal(200, okResult.StatusCode);
            Assert.Equal(true, okResult.Value);
        }

        [Fact]
        public void OddOrEvenController_IsOddOrEven_Ok()
        {
            _validator.Setup(v => v.IsValid(It.IsAny<string>())).Returns(true);
            _service.Setup(s => s.HasReminder(It.IsAny<int>(), It.IsAny<int>())).Returns(true);

            _oddOrEvenController = new OddOrEvenController(_validator.Object, _service.Object, _mockLogger.Object);

            var result = _oddOrEvenController.IsEven(It.IsAny<string>());

            var okResult = result as OkObjectResult;
            Assert.NotNull(okResult);
            Assert.Equal(200, okResult.StatusCode);
            Assert.Equal(false, okResult.Value);
        }

    }
}
