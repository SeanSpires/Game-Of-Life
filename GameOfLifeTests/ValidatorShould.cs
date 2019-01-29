using System.Runtime.InteropServices;
using GameOfLife;
using Xunit;

namespace GameOfLifeTests
{
    public class ValidatorShould
    {
        [Theory]
        [InlineData("1,1")]
        [InlineData("2,3")]
        public void PassValidWorldDimensions(string validWorldDimension)
        {
            var validator = new Validator();
            Assert.True(validator.IsWorldDimensionsValid(validWorldDimension));
        }


        [Theory]
        [InlineData("0,0")]
        [InlineData("-1,1")]
        [InlineData("1,-1")]
        [InlineData("-2,-2")]
        public void FailInvalidWorldDimensions(string invalidWorldDimensions)
        {
            var validator = new Validator();
            Assert.False(validator.IsWorldDimensionsValid(invalidWorldDimensions));
        }

        [Theory]
        [InlineData("0,0", 3, 3)]
        [InlineData("1,1", 3 ,3)]
        [InlineData("2,2", 3, 3)]
        public void PassValidCoordinates(string validCoordinate, int gridHeight, int gridWidth)
        {
            var validator = new Validator();            
            Assert.True(validator.IsUserInputValid(validCoordinate,gridHeight, gridWidth));
        }
        
        [Theory]
        [InlineData("-1,-1", 3, 3)]
        [InlineData("-1,1", 3 ,3)]
        [InlineData("1,-1", 3 ,3)]
        [InlineData("1,3", 3 ,3)]
        [InlineData("3,1", 3 ,3)]
        [InlineData("3,3", 3, 3)]
        public void FailInvalidCoordinates(string invalidCoordinate, int gridHeight, int gridWidth)
        {
            var validator = new Validator();            
            Assert.False(validator.IsUserInputValid(invalidCoordinate,gridHeight, gridWidth));
        }

    }
}