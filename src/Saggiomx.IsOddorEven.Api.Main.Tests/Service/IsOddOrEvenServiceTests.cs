using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Saggiomx.IsOddorEven.Api.Main.Servic;
using Xunit;

namespace Saggiomx.IsOddorEven.Api.Main.Tests.Service
{
    public class IsOddOrEvenServiceTests
    {
        [Theory]
        [InlineData(2, 3, true)]
        [InlineData(2, 2, false)]
        public void IsOddOrEvenService_HasRemider_True(int dividend, int divisor, bool expectedResult)
        {
            //Arrange
            var isOddOrEvenService = new IsOddOrEvenService();
            //Act
            var result = isOddOrEvenService.HasReminder(dividend, divisor);
            //Assert
            Assert.NotNull(result);
            Assert.IsType<bool>(result);
            Assert.Equal(expectedResult,result);
        }

        [Fact]
        public void IsOddOrEvenService_HasRemider_DividedByZeroException()
        {
            //Arrange
            var isOddOrEvenService = new IsOddOrEvenService();
            //Assert
            Assert.Throws<DivideByZeroException>(() =>isOddOrEvenService.HasReminder(2, 0));
        }
    }
}
