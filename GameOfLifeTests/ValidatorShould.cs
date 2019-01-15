using GameOfLife;
using Xunit;

namespace GameOfLifeTests
{
    public class ValidatorShould
    {
        [Fact]
        public void PassValidWorldDimensions()
        {
            var validWorldDimension = "6,6";
            var validator = new Validator();
            Assert.True(validator.IsWorldDimensionsValid(validWorldDimension));
        }


        [Fact]
        public void PassValidCoordinates()
        {
            var gridHeight = 4;
            var gridWidth = 3;
            var validCoordinate = "2,2";
            var validator = new Validator();
            
            Assert.True(validator.IsCoordinateValid(gridHeight, gridWidth, validCoordinate));
        }

    }
}