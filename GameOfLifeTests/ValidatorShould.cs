using GameOfLife;
using Xunit;

namespace GameOfLifeTests
{
    public class ValidatorShould
    {

        [Fact]
        public void PassUserInputWithCorrectFormat()
        {
            var validator = new Validator();
            var validationResult = validator.IsUserInputInCorrectFormat("2,2");
            Assert.True(validationResult);
        }

        [Theory]
        [InlineData("-1", "-1")]
        [InlineData("0", "0")]
        [InlineData("2", "2")]
        [InlineData("asda","asda")]
        public void FailInvalidWorldDimensions(string worldHeight, string worldWidth)
        {
            var validator = new Validator();
            var validationResult = validator.IsWorldDimensionsValid(worldHeight, worldWidth);
            Assert.False(validationResult);
        }

        [Theory]
        [InlineData("3", "3")]
        [InlineData("20", "20")]
        public void PassValidWorldDimensions(string worldHeight, string worldWidth)
        {
            var validator = new Validator();
            var validationResult = validator.IsWorldDimensionsValid(worldHeight, worldWidth);
            Assert.True(validationResult);
        }
        
        

    }
}