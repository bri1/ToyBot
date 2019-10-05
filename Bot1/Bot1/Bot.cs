using System;
using System.Collections.Generic;
using System.Text;

namespace Bot1
{
    class Bot
    {
        public int? XCoordinate { get; set; } //? means that it is a nullable int, starts off as null
        public int? YCoordinate { get; set; }

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

        public string Report()
        {
            return "hi";
        }

    }
}
