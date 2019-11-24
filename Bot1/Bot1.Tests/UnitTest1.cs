using System;
using Xunit;
using Bot1;
using System.IO;


namespace Bot1.Tests
{

    public class BotUnitTest1 : BaseTest //implementing (inheriting it) BaseTest in BotUnitTest1 - BotUnitTest1 is now a subclass of BaseTest
    {
        //private readonly Bot _testBot; //only ever making changes to it in the constructor

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


        //[Theory]
        //[InlineDataAttribute(0, 0, "NORTH")]
        //[InlineDataAttribute(0, 0, "SOUTH")]
        //[InlineDataAttribute(0, 0, "EAST")]
        //[InlineDataAttribute(0,0, "WEST")]


        //public void Left_command_should_change_bot_direction_in_anticlockwise_direction(int xCoordinate, int yCoordinate, string direction)
        //{
        //    //Arrange
        //    _testBot.Place(xCoordinate, yCoordinate, direction);
            

        //    //Act
        //    _testBot.Left();

        //    //Assert
        //    switch (direction) {
        //        case "NORTH":
        //            Assert.Equal("WEST", _testBot.Direction);
        //            break;  //Can we put breaks in a test?
        //        case "SOUTH":
        //            Assert.Equal("EAST", _testBot.Direction);

        //            break;

        //        case "EAST":
        //            Assert.Equal("NORTH", _testBot.Direction);

        //            break;

        //        case "WEST":
        //            Assert.Equal("SOUTH", _testBot.Direction);

        //            break;
        //    }

        
        //}



        [Theory]
        [InlineDataAttribute(0, 0, "NORTH",0,0, "WEST")]
        [InlineDataAttribute(0, 0, "SOUTH",0,0,"EAST")]
        [InlineDataAttribute(0, 0, "EAST",0,0,"NORTH")]
        [InlineDataAttribute(0, 0, "WEST",0,0,"SOUTH")]
        public void Left_command_should_change_bot_direction_in_anticlockwise_direction2(
            int xCoordinate, int yCoordinate,string direction,
            int expectedX, int expectedY, 
            string expectedDirection)
        {
            //Arrange
            _testBot.Place(xCoordinate, yCoordinate, direction);
            
            //Act
            _testBot.Left();
            
            //Assert
            Assert.Equal(expectedX, _testBot.XCoordinate);
            Assert.Equal(expectedY, _testBot.YCoordinate);
            Assert.Equal(expectedDirection, _testBot.Direction);

        }


    


















        [Theory]
        [InlineDataAttribute(1, 1, "NORTH",1,2,"NORTH")]
        [InlineDataAttribute(1, 1, "SOUTH", 1, 0, "SOUTH")]
        [InlineDataAttribute(1, 1, "EAST", 2, 1, "EAST")]
        [InlineDataAttribute(1, 1, "WEST", 0, 1, "WEST")]





        //MIGHT NEED TO RENAME THIS ONE
        public void Move_command_should_increase_coordinate_by_one_in_facing_direction(
            int xCoordinate, int yCoordinate, string direction,
            int expectedX, int expectedY, string expectedDirection)
        {
            //Arrange
            _testBot.Place(xCoordinate, yCoordinate, direction);


            //Act
            _testBot.Move();

            //Assert

            Assert.Equal(expectedX, _testBot.XCoordinate);
            Assert.Equal(expectedY, _testBot.YCoordinate);
            Assert.Equal(expectedDirection, _testBot.Direction);


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
        [InlineDataAttribute(0, 0, "SOUTH", "<Report> Robot is currently here : 0,0,SOUTH")]
        [InlineDataAttribute(0, 0, "WEST", "<Report> Robot is currently here : 0,0,WEST")]
        [InlineDataAttribute(0, 3, "WEST", "<Report> Robot is currently here : 0,3,WEST")]
        [InlineDataAttribute(4, 4, "NORTH", "<Report> Robot is currently here : 4,4,NORTH")]
        [InlineDataAttribute(4, 4, "EAST", "<Report> Robot is currently here : 4,4,EAST")]
        public void Report_command_output_correct_details(int xCoordinate, int yCoordinate, string direction, string expectedOutput)
        {
            //Arrange
            _testBot.Place(xCoordinate, yCoordinate, direction);



            //using means that it will be disposed once the using ends
            //general output of the console is StdOut(). And errors are generally sent to ErrorOut()
            using (StringWriter testSW = new StringWriter())
            {
                Console.SetOut(testSW);
                //open scope for using, sets the scope of the stringwriter
                //redirecting console output from standard OUT (stdout) to the new stringwriter

                //Act
                _testBot.Report();

                //Assert
                var actualOutput = testSW.ToString().Replace(Environment.NewLine,"");
                Assert.Equal(expectedOutput, actualOutput);
                testSW.Dispose();

            }

            var standardOutput = new StreamWriter(Console.OpenStandardOutput());
            standardOutput.AutoFlush = true;
            Console.SetOut(standardOutput);
            //Redirects the console output back to standard output as previously the tests were running into the 
            //error that they were trying to access a closed textWriter - aka stringwriter.
            //As tests are running concurrently, the different tests are trying to write to the same textWriter but it closes after the first so it was getting confused.
            //https://docs.microsoft.com/en-us/dotnet/api/system.console.setout?view=netframework-4.8

        }







    }
}

//Group of tests= Test suite
//Testing all individual commands
//