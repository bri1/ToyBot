﻿using System;
using System.Linq;

namespace Bot1
{
    public class Bot
    {
        public int? XCoordinate { get; set; } //? means that it is a nullable int, starts off as null
        public int? YCoordinate { get; set; }
        public string Direction { get; set; }
        //direction needed
        public bool HasBeenPlaced => XCoordinate != null && YCoordinate != null && Direction !=null; // automatically being calculated, so if the coordinates arent null it has been placed and it is true!

        string[] leftTurnArray = new string[] { "NORTH", "WEST", "SOUTH", "EAST" };//Decided against using enums
        string[] rightTurnArray = new string[] { "NORTH", "EAST", "SOUTH", "WEST" };

        public void Place(int x, int y, string direction) // could this be replaced with a try and catch?
        {
            if (leftTurnArray.Contains(direction))
            {
                if (!IsValid(x) || !IsValid(y))
                {
                    Console.WriteLine("Please place bot on the table");
                    return;
                }

                if (!HasBeenPlaced)
                {
                    //Console.WriteLine("Placed object");
                    

                    XCoordinate = x;
                    YCoordinate = y;
                    Direction = direction;

                    

                    Console.WriteLine($"Successfully placed: x:{XCoordinate}, y:{YCoordinate}, direction:{direction}");
                }

                else
                {
                    Console.WriteLine($"Cannot place more than one robot on table ");

                }
            }
            else
            {
                throw new Exception("incorrect direction entered. Directions available are [NORTH, SOUTH, EAST, WEST]");
            }

        }

        public void Left() // doesnt need any input parameters // needs the current location/direction and needs to be able to update it.
        {
            if (HasBeenPlaced)
            {
                //We know that the direction is going to be in the directions list. So we dont need to see if it exists, we just need to find out where it is. So we loop through and try to match
                //the input string with the string of the enum at each index and if we find it, we return the item at the next index. 
                int index = 0;
                while (index < leftTurnArray.Length)
                {
                    if (leftTurnArray[index] == Direction)
                    {
                        if (index == leftTurnArray.Length - 1)
                        { // if it's the last element in the list,then the next direction is the first element
                           Direction = leftTurnArray[0];
                            break;
                        }
                        else
                        {
                            Direction = leftTurnArray[index + 1]; // otherwise it's the next one over
                            break;
                        }
                    }
                    else { index += 1; }

                }
            }
        }

        public void Right()
        {
            if (HasBeenPlaced)
            {
                int index = 0;
                while (index < rightTurnArray.Length)
                {
                    if (rightTurnArray[index] == Direction)
                    {
                        if (index == rightTurnArray.Length - 1)
                        { // if it's the last element in the list,then the next direction is the first element
                            Direction = rightTurnArray[0];
                            break;
                        }
                        else
                        {
                            Direction = rightTurnArray[index + 1]; // otherwise it's the next one over
                            break;
                        }
                    }
                    else { index += 1; }

                }
            }


        }

        public void Move()
        {
            if (HasBeenPlaced)
            { 

                switch (Direction)
                {

                    case "NORTH":
                        if ((YCoordinate >= 0) && (YCoordinate < 4)){
                            YCoordinate += 1; // changing the y axis
                        }
                        break;

                    case "SOUTH":
                        if ((YCoordinate > 0) && (YCoordinate <= 4))
                        {
                            YCoordinate -= 1; // changing the y axis
                        }
                        break;

                    case "EAST":
                        if ((XCoordinate >= 0) && (XCoordinate < 4))
                        {
                            XCoordinate += 1; // changing the x axis
                        }
                        break;

                    case "WEST":
                        if ((XCoordinate > 0) && (XCoordinate <= 4))
                        {
                            XCoordinate -= 1; // changing the x axis
                        }
                        break;

                }


            }
        }

        public void Report()
        {
            if (HasBeenPlaced == true)
            {
                Console.WriteLine("<Report> Robot is currently here : " + XCoordinate + "," + YCoordinate + "," + Direction);
            }

            else
            {
                throw new Exception("No robot present on table.");
            }
        }

        public string ReportText()
        {
            if (HasBeenPlaced == true)
            {
                return ($"<Report> Robot is currently here : {XCoordinate}, {YCoordinate}, {Direction}");
            }

            else
            {
                return "No robot present on table.";
            }
        }



        public bool IsValid(int x)
        {
            if ((x >= 5) || (x < 0))
            {
                return false;
            }

            return true;
        }


       

    }

}

