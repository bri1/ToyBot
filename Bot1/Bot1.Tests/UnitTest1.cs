using System;
using Xunit;
using Bot1;

namespace Bot1.Tests
{
    public class UnitTest1
    {
        [Fact]
        public void Place_initial_bot_should_place_bot_on_table_successfully()
        {
            // Arrange
            var bot = new Bot();
            var xCoordinate = 0; //lower case first for variable names
            var yCoordinate = 0;
            var facing = "NORTH";
            

            // Act
            bot.Place(xCoordinate, yCoordinate, facing);


            // Assert
            Assert.Equal(xCoordinate, bot.XCoordinate);
            Assert.Equal(yCoordinate, bot.YCoordinate);
            Assert.Equal(facing, bot.Direction);
        }

        [Fact]
        public void Placing_bot_off_table_should_fail()
        {
            // Arrange
            var bot = new Bot();
            var xCoordinate = -1; //lower case first for variable names
            var yCoordinate = 0;
            var facing = "NORTH";
            var expectedXDirection = 0;

            // Act
            bot.Place(xCoordinate, yCoordinate, facing);


            // Assert
            Assert.Equal(expectedXDirection, bot.XCoordinate);
            Assert.Equal(yCoordinate, bot.YCoordinate);
            Assert.Equal(facing, bot.Direction);
        }



        //public void Test1()
        //{
        //    // Arrange
        //    // Act
        //    // Assert

        //}

    }
}
