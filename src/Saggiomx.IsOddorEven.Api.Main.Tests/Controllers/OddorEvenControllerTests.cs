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

        private OddOrEvenController controller;

        public OddorEvenControllerTests()
        {
            _mockLogger = new Mock<ILogger<OddOrEvenController>>(MockBehavior.Loose);
            _validator = new Mock<INumberValidator>(MockBehavior.Strict);
            _service = new Mock<IIsOddOrEvenService>();
        }

        [Fact]
        public void OddOrEvenController_IsEven()
        {
            //arrange
            _validator.Setup(v => v.IsValid(It.IsAny<string>())).Returns(true);
            _service.Setup(s => s.HasReminder(It.IsAny<int>(), It.IsAny<int>())).Returns(true);

            controller = new OddOrEvenController(_validator.Object, _service.Object, _mockLogger.Object);

            var result = controller.IsEven(It.IsAny<string>());

            var okResult = result as OkObjectResult;
            Assert.NotNull(okResult);
            Assert.Equal(200, okResult.StatusCode);
            Assert.Equal(false,okResult.Value);

            _validator.Verify(v=> v.IsValid(It.IsAny<string>()), Times.Once);
            _service.Verify(s => s.HasReminder(It.IsAny<int>(), It.IsAny<int>()), Times.Once);
        }

    }
}
