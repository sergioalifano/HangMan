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
            //pick a random word
            string wordToGuess = RandomWord();
            DisplayWelcome();


            string letterGuessed = "";
            string userLetter = string.Empty;
            bool playing=true;
            int lives = 5;
            string input = string.Empty;
            

            while (playing)
            {
                Console.Clear();
                DisplayWelcome();

                //print out the guessed letters
                Console.WriteLine("Letters guessed: " + CheckForTheLetter(letterGuessed, wordToGuess));

                
                Console.WriteLine("Lives left: {0}", lives);

                Console.Write("Enter a letter: ");
                input= Console.ReadLine();

                //add the input to all the letters guessed so far
                letterGuessed += input;

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
        public static string RandomWord()
        {
            //list of words
            List<string> listOfWords = new List<string> { "HORSE", "RAINBOW", "BUTTERFLY" };
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
    }
}
