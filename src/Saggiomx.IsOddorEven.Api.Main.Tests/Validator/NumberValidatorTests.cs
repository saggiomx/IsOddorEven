using Saggiomx.IsOddorEven.Api.Main.Validator;
using Xunit;

namespace Saggiomx.IsOddorEven.Api.Main.Tests.Validator
{
    public class NumberValidatorTests
    {
        [Theory]
        [InlineData("1", true)]
        [InlineData("s", false)]
        [InlineData("-1", false)]
        public void NumberValidator_IsValid_Success(string value, bool expected)
        {
            //Arrange
            var numberValidator = new NumberValidator();
            //Act
            var result = numberValidator.IsValid(value);
            //Assert
            Assert.IsType<bool>(result);
            Assert.Equal(expected, result);
        }


        [Fact]
        public void NumberValidator_IsValid_True()
        {
            //Arrange
            var numberValidator = new NumberValidator();
            //Act
            var result = numberValidator.IsValid("1");
            //Assert
            Assert.IsType<bool>(result);
            Assert.Equal(true, result);
        }

        [Theory]
        [InlineData("s", false)]
        [InlineData("-1", false)]
        public void NumberValidator_IsValid_False(string value, bool expected)
        {
            //Arrange
            var numberValidator = new NumberValidator();
            //Act
            var result = numberValidator.IsValid(value);
            //Assert
            Assert.IsType<bool>(result);
            Assert.Equal(expected, result);
        }

    }
}
