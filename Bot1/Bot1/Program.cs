using System;

namespace Bot1
{
    class Program
    {
        static void Main(string[] args)
        {   //loop through to find the current direction and then the next item tells the new direction. Not feasible for bigger enum sets but for the four directions should be fine.
            String[] leftTurnArray = ["NORTH","WEST","SOUTH","EAST"];//Decided against using enums
            String[] rightTurnArray = ["NORTH","EAST","SOUTH","WEST"];


            Console.WriteLine("Welcome to the Toy Bot game!"+ "\n" + "Please enter your command"); // double check if this works with the new line.
            string input = Console.ReadLine();
            string[] words = input.Split(','); // Creating an array of the words split
            string action = words[0].ToUpper();
            if (words.Length == 4){ // checks if there are enough items being entered, to save from the error of not being able to find the nth index in words. 
                                    //Do we need to do a type check, no but should do a validity check. If any of the items are not valid they should throw an error?
                                    //Throw an error if the coordinates are >4 or < 0, if we call a move it should just not acknowledge it if it is at the edge of the board. 
                                    //Also throw an error if the direction isnt in the enum list. 
                string facing = words[3].ToUpper();
                int[] coord = [System.Convert.ToInt32(words[1]), System.Convert.ToInt32(words[2])]; // structure is wrong here - fix
            }   
            int placeCount = 0; //Checks to see if Place has been called yet, nothing will work until it has been called the first time. Is there a more efficient way to do this?
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
                    //movements.Right();}
                    }
                    break;

                case "REPORT":
                    if (placeCount == 1){
                    Console.WriteLine("Output: " + coord[0] + "," + coord[1], + "," + facing);}
                    break;
                
                case "PLACE":
                    movements.Place(System.Convert.ToInt32(words[1]), System.Convert.ToInt32(words[2]), words[3]);
                    placeCount = 1;
                    break;


            }
        }
    }
}
