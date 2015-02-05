using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HangMan
{
    class Program
    {
        static void Main(string[] args)
        {
            string letterGuessed = "";
            string userLetter = string.Empty;
            bool playing = true;
            int lives = 5;
            string input = string.Empty;

            //list of words
            List<string> listOfWords = new List<string> { "HORSE", "RAINBOW", "BUTTERFLY" };

            //pick a random word from the list of words
            string wordToGuess = RandomWord(listOfWords);

            List<string> colors = new List<string> { "Yellow", "Green", "Red", "Blue", "Gray", "DarkGray" };
            //set the default color of foreground to white
            ConsoleColor colorChanged = (ConsoleColor)Enum.Parse(typeof(ConsoleColor), "White");
            

            while (playing)
            {
                Console.Clear();
                DisplayWelcome();

                //print out the guessed letters
                Console.WriteLine("Letters guessed: " + CheckForTheLetter(letterGuessed, wordToGuess));

                //display lives left with a different color every time
                Console.ForegroundColor = colorChanged;
                Console.WriteLine("Guesses left: {0}", lives);
                Console.ResetColor();

                //ask to anter a letter
                Console.Write("Enter a letter: ");
                input= Console.ReadLine();

                //add the input to all the letters guessed so far
                letterGuessed += input;

                //check if the user has guessed all the letters
                if (Winner(letterGuessed, wordToGuess))
                {
                    Console.Clear();
                    DisplayWelcome();

                    Console.WriteLine("Letters guessed: " + CheckForTheLetter(letterGuessed, wordToGuess));
                    Console.WriteLine(@" CONGRATUATIONS   ");
                    playing = false;
                }

                //check if the letter guessed is correct
                else   if (wordToGuess.Contains(input.ToUpper()))
                {
                    Console.WriteLine("Coool");
                   
                }
                else
                {
                    lives--;
                    colorChanged = ChangeColor(colors);
                    //check the number of lives
                    if (lives == 0)
                    {
                        //if you have no more lives stop the game
                        Console.WriteLine("Sorry, you didn't make it");
                        playing = false;
                    }
                    else
                    {
                        Console.WriteLine("Oops wrong one...");
                    }

                   
                    
                }
               

            }


            Console.ReadKey();
        }

        /// <summary>
        /// This function pick a random word from a list
        /// </summary>
        /// <returns>a string</returns>
        public static string RandomWord(List<string> listOfWords)
        {
            
            Random ngr = new Random();
           
            //choose a random word from the list and return the string
            return listOfWords[ngr.Next(0, listOfWords.Count)];
        }

        public static void DisplayWelcome()
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine(@"██╗  ██╗ █████╗ ███╗   ██╗ ██████╗ ███╗   ███╗ █████╗ ███╗   ██╗
██║  ██║██╔══██╗████╗  ██║██╔════╝ ████╗ ████║██╔══██╗████╗  ██║
███████║███████║██╔██╗ ██║██║  ███╗██╔████╔██║███████║██╔██╗ ██║
██╔══██║██╔══██║██║╚██╗██║██║   ██║██║╚██╔╝██║██╔══██║██║╚██╗██║
██║  ██║██║  ██║██║ ╚████║╚██████╔╝██║ ╚═╝ ██║██║  ██║██║ ╚████║
╚═╝  ╚═╝╚═╝  ╚═╝╚═╝  ╚═══╝ ╚═════╝ ╚═╝     ╚═╝╚═╝  ╚═╝╚═╝  ╚═══╝
                                                                 ");
            Console.ResetColor();

        }
        

        /// <summary>
        /// check if the letter guessed is in the word
        /// </summary>
        /// <param name="letterToCheck"></param>
        /// <param name="wordToGuess"></param>
        /// <returns></returns>
        static string CheckForTheLetter(string letterToCheck, string wordToGuess)
        {
            string guessed = string.Empty;
            for (int i = 0; i < wordToGuess.Length; i++)
            {
                if (letterToCheck.ToUpper().Contains(wordToGuess[i].ToString()))
                {
                    guessed += wordToGuess[i] + " ";
                    
                }
                else
                {
                    guessed += "_" + " ";
                }

            }

            return guessed;
        }

        static bool Winner(string letterToCheck, string wordToGuess)
        {
            for (int i = 0; i < wordToGuess.Length; i++)
            {
                //if a letter is not found the game is not over
                if (!letterToCheck.ToUpper().Contains(wordToGuess[i].ToString()))
                {
                    return false;
                }
            }
           

            return true;
        }

        static ConsoleColor ChangeColor(List<string> colors)
        {
            Random gnr = new Random();

            //pick a color from the list of colors
            string color=colors[gnr.Next(0, colors.Count())];

            //return the color as ConsoleColor type
            return (ConsoleColor)Enum.Parse(typeof(ConsoleColor), color);
          
        }
    }
}
