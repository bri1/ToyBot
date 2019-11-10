using System;
using Xunit;
using Bot1;

namespace Bot1.Tests
{

    public class BotUnitTest1
    {
        private readonly Bot _testBot; //only ever making changes to it in the constructor

        public BotUnitTest1()
        {
           _testBot = new Bot();
        }

        [Theory]
        [InlineDataAttribute(0,0,"NORTH")]
        [InlineDataAttribute(1, 2, "SOUTH")]
        [InlineDataAttribute(4, 2, "EAST")]

        public void Place_initial_bot_should_place_bot_on_table_successfully(int xCoordinate, int yCoordinate, string direction)
        {
            // Arrange
                             

            // Act
            _testBot.Place(xCoordinate, yCoordinate, direction);


            // Assert
            Assert.Equal(xCoordinate, _testBot.XCoordinate);
            Assert.Equal(yCoordinate, _testBot.YCoordinate);
            Assert.Equal(direction, _testBot.Direction);
        }

        [Theory]
        [InlineDataAttribute(3, 5, "WEST")]
        [InlineDataAttribute(3, 7, "WEST")]
        public void Placing_bot_off_table_should_fail(int xCoordinate, int yCoordinate, string direction)
        {
            // Arrange
                                 


            // Act
            _testBot.Place(xCoordinate, yCoordinate, direction);


            // Assert
            Assert.Null(_testBot.XCoordinate);
            Assert.Null(_testBot.YCoordinate);
            Assert.Null(_testBot.Direction);
        }



    }
}

//Group of tests= Test suite
//Testing all individual commands
//