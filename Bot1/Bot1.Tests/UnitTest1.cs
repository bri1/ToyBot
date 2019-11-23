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


        [Theory]
        [InlineDataAttribute(0, 0, "NORTH")]
        [InlineDataAttribute(0, 0, "SOUTH")]
        [InlineDataAttribute(0, 0, "EAST")]
        [InlineDataAttribute(0,0, "WEST")]


        public void Left_command_should_change_bot_direction_in_anticlockwise_direction(int xCoordinate, int yCoordinate, string direction)
        {
            //Arrange
            _testBot.Place(xCoordinate, yCoordinate, direction);
            

            //Act
            _testBot.Left();

            //Assert
            switch (direction) {
                case "NORTH":
                    Assert.Equal("WEST", _testBot.Direction);
                    break;  //Can we put breaks in a test?
                case "SOUTH":
                    Assert.Equal("EAST", _testBot.Direction);

                    break;

                case "EAST":
                    Assert.Equal("NORTH", _testBot.Direction);

                    break;

                case "WEST":
                    Assert.Equal("SOUTH", _testBot.Direction);

                    break;
            }

        
        }



        [Theory]
        [InlineDataAttribute(0, 0, "NORTH")]
        [InlineDataAttribute(0, 0, "SOUTH")]
        [InlineDataAttribute(0, 0, "EAST")]
        [InlineDataAttribute(0, 0, "WEST")]


        public void Right_command_should_change_bot_direction_in_clockwise_direction(int xCoordinate, int yCoordinate, string direction)
        {
            //Arrange
            _testBot.Place(xCoordinate, yCoordinate, direction);


            //Act
            _testBot.Right();

            //Assert
            switch (direction)
            {
                case "NORTH":
                    Assert.Equal("EAST", _testBot.Direction);
                    break;
                case "SOUTH":
                    Assert.Equal("WEST", _testBot.Direction);

                    break;

                case "EAST":
                    Assert.Equal("SOUTH", _testBot.Direction);

                    break;

                case "WEST":
                    Assert.Equal("NORTH", _testBot.Direction);

                    break;
            }


        }

        //MIGHT NEED TO RENAME THIS ONE
        public void Move_command_should_increase_coordinate_by_one_in_facing_direction(int xCoordinate, int yCoordinate, string direction)
        {
            //Arrange
            _testBot.Place(xCoordinate, yCoordinate, direction);


            //Act
            _testBot.Move();

            //Assert
            switch (direction)
            {
                case "NORTH":
                    Assert.Equal(yCoordinate + 1, _testBot.YCoordinate);
                    Assert.Equal(xCoordinate, _testBot.XCoordinate);
                    Assert.Equal(direction, _testBot.Direction);
                    break;
                case "SOUTH":
                    Assert.Equal(yCoordinate, _testBot.YCoordinate);
                    Assert.Equal(xCoordinate, _testBot.XCoordinate);
                    Assert.Equal(direction, _testBot.Direction);
                    break;

                case "EAST":
                    Assert.Equal(yCoordinate, _testBot.YCoordinate);
                    Assert.Equal(xCoordinate, _testBot.XCoordinate);
                    Assert.Equal(direction, _testBot.Direction);
                    break;

                case "WEST":
                    Assert.Equal(yCoordinate, _testBot.YCoordinate);
                    Assert.Equal(xCoordinate, _testBot.XCoordinate);
                    Assert.Equal(direction, _testBot.Direction);

                    break;
            }

        }

       

        [Theory]
        [InlineDataAttribute(0, 0, "SOUTH")]
        [InlineDataAttribute(0, 0, "WEST")]
        [InlineDataAttribute(0, 3, "WEST")]
        [InlineDataAttribute(4, 4, "NORTH")]
        [InlineDataAttribute(4, 4, "EAST")]
        [InlineDataAttribute(1, 4, "NORTH")]
        [InlineDataAttribute(4, 3, "EAST")]
               
        public void Move_command_should_do_nothing_when_bot_is_trying_to_move_off_edge_of_table(int xCoordinate, int yCoordinate, string direction)
        {
            //Arrange
            _testBot.Place(xCoordinate, yCoordinate, direction);


            //Act
            _testBot.Move();

            //Assert
            Assert.Equal(xCoordinate, _testBot.XCoordinate);
            Assert.Equal(yCoordinate, _testBot.YCoordinate);
            Assert.Equal(direction, _testBot.Direction);
                       
        }



        [Theory]
        [InlineDataAttribute(0, 0, "SOUTH")]
        [InlineDataAttribute(0, 0, "WEST")]
        [InlineDataAttribute(0, 3, "WEST")]
        [InlineDataAttribute(4, 4, "NORTH")]
        [InlineDataAttribute(4, 4, "EAST")]
        public void Report_command_output_correct_details(int xCoordinate, int yCoordinate, string direction)
        {
            //Arrange
            _testBot.Place(xCoordinate, yCoordinate, direction);


            //Act
            _testBot.Report();

            //Assert

            //Assert.Equal( , _testBot.Report.GetOutput())



        }







    }
}

//Group of tests= Test suite
//Testing all individual commands
//