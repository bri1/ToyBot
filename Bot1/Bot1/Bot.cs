using System;
using System.Collections.Generic;
using System.Text;

namespace Bot1
{
    class Bot
    {
        public int? XCoordinate { get; set; } //? means that it is a nullable int, starts off as null
        public int? YCoordinate { get; set; }
        //direction needed
        public bool HasBeenPlaced => XCoordinate != null && YCoordinate != null; // automatically being calculated, so if the coordinates arent null it has been placed and it is true!


        public void Place(int x, int y, string direction)
        {
            Console.WriteLine("Placed object");
            
            XCoordinate = x;
            YCoordinate = y;

            Console.WriteLine($"x:{XCoordinate}, y:{YCoordinate} direction:{direction}");
        }

        public void Left() // doesnt need any input parameters // needs the current location/direction and needs to be able to update it.
        {
        
        }

        public void Right()
        {

        }

        public void Report()
        {
            if (HasBeenPlaced == true)
            {
                Console.WriteLine("Output: " + XCoordinate + "," + YCoordinate + ",");
            }
        }
    }

}

