using System;
using System.Linq;

namespace Bot1
{
    class Program
    { 

        static void Main(string[] args)
        {
            Welcome();
            var bot = new Bot();

            while (true){
                try
                {
                    HandleCommands(bot);
                }
                catch (Exception exception)
                {
                    Console.WriteLine($"Error: {exception.Message}");
                }
                
            }
            
        }
        
        static void Welcome()
        {
            Console.WriteLine("Welcome to the Toy Bot game!" + "\n" + "Please enter your command");
        }

      
        static void HandleCommands(Bot bot)
        {
          

            string[] ValidCommands = new string[] { "PLACE", "MOVE", "LEFT", "RIGHT", "REPORT" };

            Console.WriteLine("Enter command:");
            string input = Console.ReadLine();
            string[] words = input.Split(',',' '); // Creating an array of the words split
            string action = words[0].ToUpper();

            if (!ValidCommands.Contains(action))
            {
                throw new Exception("Please use a valid command. Commands available are [PLACE, MOVE, LEFT, RIGHT, REPORT]");
            }



            //validating input - checking number of words is correct
            if(((action == "PLACE")&& (words.Length != 4))|| ((words.Length <1 || words.Length>4))) 
            {
                throw new Exception("Incorrect number of command fields entered.");
            }

            



            
            int[] coord = new int[2];
            string facing = "";
            
            switch (action)
            {                
                case "LEFT":
                    bot.Left();
                    break;

                case "RIGHT":
                    bot.Right();
                    break;

                case "MOVE":
                    bot.Move();
                    break;

                case "REPORT":

                    bot.Report();
 
                    break;

                case "PLACE": 

                    facing = words[3].ToUpper();

                    coord[0] = System.Convert.ToInt32(words[1]); //trying to convert the string number to an int int.
                    coord[1] = System.Convert.ToInt32(words[2]);

                    bot.Place(coord[0], coord[1], facing);

                    break;


            }
          

        }

    }
}
