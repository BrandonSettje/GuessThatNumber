using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuessThatNumber
{
    public class Program
    {
        //the number the rng will come up with
        static int NumberToGuess = 0;
        //keep track of guesses
        static int guessCounter = 0;
        //what the user guess is
        static int userGuess = 0;
        //rng
        public static Random rng = new Random();
        static void Main(string[] args)
        {
            gameRunner();
            Console.ReadKey();
        
        }
        
        /// <summary>
        /// guess that number game 
        /// </summary>
        public static void gameRunner()
        {       //rng for Number that user should guess
            NumberToGuess = rng.Next(1, 101);
                //talk to user
            Console.WriteLine("Let's play a game of Guess that Number!");
                //tell them the rules    
            Console.WriteLine("The number is between 1 and 100.");
                //have them enter a number
            Console.Write("Enter your guess: ");
                    //while the user input is unequal to computernumber
                     while (userGuess != NumberToGuess)
                    {   //read the user input
                        string userInputs = Console.ReadLine();
                         //validate to make sure numbers are between 1 and 100
                         if (ValidateInput(userInputs))
                        {   
                             //starts loop to see if guess is too high or low
                            if (IsGuessTooHigh(userGuess))
                            {
                                //tells the user what to do if wrong
                            Console.WriteLine("Too high, guess again!");
                            Console.Write("Guess again: ");
                            }
                                //if its too low, tells user
                            else if (IsGuessTooLow(userGuess))
                            {
                            Console.WriteLine("Too low, guess again!");
                            Console.Write(" Guess again: ");
                            }
                         }
                         else 
                         {     
                                Console.Write("Invalid. Please guess again: ");
                          }
                        }
                        
                    //if user guesses it on first try   
                     if (guessCounter == 0)
                     {
                         guessCounter++;
                         Console.WriteLine("Are you psychic?");
                     }
                         //once user gets the numbertoGuess
                     else
                     {
                         guessCounter++;
                         Console.WriteLine();
                         Console.WriteLine("Took you long enough");
                         Console.WriteLine("It took you {0} guesses.", guessCounter);
                     }
               
        }
        /// <summary>
        /// validate results to a number 1- 100
        /// </summary>
        /// <param name="userInput">what the user puts in</param>
        /// <returns> nothing, tells gamerunner to stop or keep going</returns>
        public static bool ValidateInput(string userInput)
        {
            //check to make sure that the users input is a valid number between 1 and 100.
            int userNumber = 0;
            if (int.TryParse(userInput, out userNumber))
            {
                // is a number in the range
                if (userNumber >= 1 && userNumber <= 100)
                {
                    // the inout is between 100 and 1
                    userGuess = userNumber;
                    return true;
                }
                else
                {
                    //its not between 1 and 100
                    return false;
                }
            }
            else
            {
                //not a number at all
                return false;
            }
        }
       /// <summary>
       /// for the testers
       /// </summary>
       /// <param name="number"></param>
        public static void SetNumberToGuess(int number)
        {
            //TODO: make this function override your global variable holding the number the user needs to guess.  This is used only for testing methods.
            NumberToGuess = number;

        }
        /// <summary>
        /// if the user guess is too high
        /// </summary>
        /// <param name="userGuess">what the user put in for a guess</param>
        /// <returns>true or false depending on rank of guess</returns>
        public static bool IsGuessTooHigh(int userGuess)
        {
            //TODO: return true if the number guessed by the user is too high
            if (userGuess > NumberToGuess)
            {
                guessCounter++;
                
                return true;
            }
            return false;
        }
        /// <summary>
        /// if the user guess is too low
        /// </summary>
        /// <param name="userGuess">the user guess</param>
        /// <returns>true or false depending on rank of guess</returns>
        public static bool IsGuessTooLow(int userGuess)
        {
            //TODO: return true if the number guessed by the user is too low
            if (userGuess < NumberToGuess)
            {
                guessCounter++;
                
                return true;
            }
            return false;
        }
    }
}
