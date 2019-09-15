using System;

namespace Bot1
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            string[] words = input.Split(','); // Creating an array of the words split
            var movements = new Movement();
            string action = words[0].ToUpper();
            switch (action)
            { /*need to find a way to be able to update the original values after moving -> needs to be passed through the constructors of
                the different Movement methods but that would be too messy. There is be a simpler way to achieve this. Rework the approach. */
                case "PLACE":
                    movements.Place(System.Convert.ToInt32(words[1]), System.Convert.ToInt32(words[2]), words[3]);
                    break;
                case "LEFT":
                    movements.Left();
                    break;

                case "RIGHT":
                    movements.Right();
                    break;

                case "REPORT":
                    string output = movements.Report();
                    break;


            }
        }
    }
}
