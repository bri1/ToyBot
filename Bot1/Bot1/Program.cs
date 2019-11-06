using System;

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

        //public Boolean HasIncorrectNumberOfCommands(string[] word)
        //{
        //    (words.Length == 1 && words[0] == "") || (action == "PLACE" && words.Length != 4
        //}
      
        static void HandleCommands(Bot bot)
        {
            string[] leftTurnArray = new string[] { "NORTH", "WEST", "SOUTH", "EAST" };//Decided against using enums
            string[] rightTurnArray = new string[] { "NORTH", "EAST", "SOUTH", "WEST" };

            Console.WriteLine("Enter command:");
            string input = Console.ReadLine();
            string[] words = input.Split(',',' '); // Creating an array of the words split
            string action = words[0].ToUpper();

            //validating input - checking number of words is correct
            if(((action == "PLACE")&& (words.Length != 4))|| ((words.Length <1 || words.Length>4))) //probably not the neatest way to do this error handling. Needs optimisation.
            {
                throw new Exception("Incorrect number of command fields entered.");
            }



            
            int[] coord = new int[2];
            string facing = "";
            /*if (words.Length == 4){ // checks if there are enough items being entered, to save from the error of not being able to find the nth index in words. 
                                    //Do we need to do a type check, no but should do a validity check. If any of the items are not valid they should throw an error?
                                    //Throw an error if the coordinates are >4 or < 0, if we call a move it should just not acknowledge it if it is at the edge of the board. 
                                    //Also throw an error if the direction isnt in the enum list. 
                facing = words[3].ToUpper();
            
                coord[0] = System.Convert.ToInt32(words[1]); //trying to convert the string number to an int int.
                coord[1] = System.Convert.ToInt32(words[2]);
            
            }*/   
           // int placeCount = 0; //Checks to see if Place has been called yet, nothing will work until it has been called the first time. Is there a more efficient way to do this?
            //var bot = new Bot(); //overwriting every time you run the handlecommands () and creating a new bot-- issue?
            switch (action)
            {                
                case "LEFT":
                    if (bot.HasBeenPlaced)
                    {
                    //We know that the direction is going to be in the directions list. So we dont need to see if it exists, we just need to find out where it is. So we loop through and try to match
                    //the input string with the string of the enum at each index and if we find it, we return the item at the next index. 
                    int index = 0;
                    while (index < leftTurnArray.Length){
                            if (leftTurnArray[index] == bot.Direction){
                                if (index == leftTurnArray.Length-1){ // if it's the last element in the list,then the next direction is the first element
                                    bot.Direction = leftTurnArray[0];
                                    }
                                else{
                                    bot.Direction = leftTurnArray[index+1]; // otherwise it's the next one over
                                    }
                            }     
                            else { index +=1;}
                    
                    }   
                    } 
                    
                    break;

                case "RIGHT":
                    if (bot.HasBeenPlaced){
                        int index = 0;
                        while (index < rightTurnArray.Length){
                                if (rightTurnArray[index] == bot.Direction)
                            {
                                    if (index == rightTurnArray.Length-1){ // if it's the last element in the list,then the next direction is the first element
                                    bot.Direction = rightTurnArray[0];
                                        }
                                    else{
                                    bot.Direction = rightTurnArray[index+1]; // otherwise it's the next one over
                                        }
                                }     
                                else { index +=1;}
                    
                        }   
                        }   
                  
                    
                    break;

                case "MOVE":
                    if (bot.HasBeenPlaced){ //not sure if we want to move this all across to Bot.cs?
                        
                        switch (bot.Direction)
                        {  
                            
                            case "NORTH":
                                bot.YCoordinate +=1; // changing the y axis 
                                break;

                            case "SOUTH":
                                bot.YCoordinate -=1;
                                break;
                            
                            case "EAST":
                                bot.XCoordinate +=1;// changing the x axis
                                break;

                            case "WEST":
                                bot.XCoordinate -=1;
                                break;
                            
                        }


                       }
                    break;

                case "REPORT":

                    bot.Report();
 
                    break;

                case "PLACE": // assuming that the thing refreshes every time? //if it does refresh I will lose all my values anyway?

                    facing = words[3].ToUpper();

                    coord[0] = System.Convert.ToInt32(words[1]); //trying to convert the string number to an int int.
                    coord[1] = System.Convert.ToInt32(words[2]);

                    //placeCount = 1;

                    bot.Place(coord[0], coord[1], facing);

                    break;


            }
            //Console.ReadKey(); //Waits for you to press something before it'll close the window

        }

    }
}
