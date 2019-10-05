using System;

namespace Bot1
{
    class Program
    { 

        static void Main(string[] args)
        {
            Welcome();
            
            while (true){
                try
                {
                    HandleCommands();
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

      
        static void HandleCommands()
        {
            string[] leftTurnArray = new string[] { "NORTH", "WEST", "SOUTH", "EAST" };//Decided against using enums
            string[] rightTurnArray = new string[] { "NORTH", "EAST", "SOUTH", "WEST" };

            Console.WriteLine("Enter command:");
            string input = Console.ReadLine();
            string[] words = input.Split(',',' '); // Creating an array of the words split
           
            //validating input - checking number of words is correct
            if ((words.Length == 1 && words[0] == "") || (words.Length != 4))
            {
                throw new Exception("Incorrect number of command fields entered.");
            }



            string action = words[0].ToUpper();
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
            int placeCount = 0; //Checks to see if Place has been called yet, nothing will work until it has been called the first time. Is there a more efficient way to do this?
            var bot = new Bot();
            switch (action)
            {                
                case "LEFT":
                    if (placeCount == 1){
                    //We know that the direction is going to be in the directions list. So we dont need to see if it exists, we just need to find out where it is. So we loop through and try to match
                    //the input string with the string of the enum at each index and if we find it, we return the item at the next index. 
                    int index = 0;
                    while (index < leftTurnArray.Length){
                            if (leftTurnArray[index] == facing){
                                if (index == leftTurnArray.Length-1){ // if it's the last element in the list,then the next direction is the first element
                                    facing = leftTurnArray[0];
                                    }
                                else{
                                    facing = leftTurnArray[index+1]; // otherwise it's the next one over
                                    }
                            }     
                            else { index +=1;}
                    
                    }   
                    } 
                    
                    break;

                case "RIGHT":
                    if (placeCount == 1){
                        int index = 0;
                        while (index < rightTurnArray.Length){
                                if (rightTurnArray[index] == facing){
                                    if (index == rightTurnArray.Length-1){ // if it's the last element in the list,then the next direction is the first element
                                        facing = rightTurnArray[0];
                                        }
                                    else{
                                        facing = rightTurnArray[index+1]; // otherwise it's the next one over
                                        }
                                }     
                                else { index +=1;}
                    
                        }   
                        }   
                  
                    
                    break;

                case "MOVE":
                    if (placeCount == 1){
                        
                        switch (facing){  
                            
                            case "NORTH":
                                coord[1] +=1; // changing the y axis 
                                break;

                            case "SOUTH":
                                coord[1] -=1;
                                break;
                            
                            case "EAST":
                                coord[0] +=1;// changing the x axis
                                break;

                            case "WEST":
                                coord[0] -=1;
                                break;
                            
                        }


                       }
                    break;

                case "REPORT":
                    if (placeCount == 1){
                        Console.WriteLine("Output: " + coord[0] + "," + coord[1] + "," + facing);}
                    break;
                
                case "PLACE": // assuming that the thing refreshes every time? //if it does refresh I will lose all my values anyway?

                    facing = words[3].ToUpper();

                    coord[0] = System.Convert.ToInt32(words[1]); //trying to convert the string number to an int int.
                    coord[1] = System.Convert.ToInt32(words[2]);

                    placeCount = 1;

                    bot.Place(coord[0], coord[1], facing);

                    break;


            }
            //Console.ReadKey(); //Waits for you to press something before it'll close the window

        }

    }
}
