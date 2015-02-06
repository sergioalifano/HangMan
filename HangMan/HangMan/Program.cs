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
            int lives = 10;
            string input = string.Empty;
            int colorIndex = 0;
           
            //list of words for the game
            List<string> listOfWords = new List<string> { "HORSE", "RAINBOW", "BUTTERFLY", "NICKELBACK", "SEEDPADTHS" };

            //pick a random word from the list of words
            string wordToGuess = RandomWord(listOfWords);

            List<string> colors = new List<string> { "Yellow", "Green" , "Blue", "Magenta","Red" };
            //set the default color of foreground to grey
            ConsoleColor colorChanged = (ConsoleColor)Enum.Parse(typeof(ConsoleColor), "Gray");

            //just show a funny text before starting the game
            InsertCoin();

            Console.Write("\nENTER YOUR NAME TO BEGIN: ");
            string userName = Console.ReadLine();

            while (playing)
            {
                Console.Clear();

                //shows the name of the game 
                DisplayWelcome();

                //shows a brief of rules to play the game
                DisplayRules();

                //print out the guessed letters
                Console.WriteLine("\n\nLetters guessed: " + CheckForTheLetter(letterGuessed, wordToGuess));

                //display lives left with a different color every time
                Console.ForegroundColor = colorChanged;
                Console.WriteLine("\n\nGuesses left: {0}", lives);
                Console.ResetColor();

                //ask to anter a letter
                Console.WriteLine();
                Console.Write("\nEnter a letter: ");
                input= Console.ReadLine();

                //add the input to all the letters guessed so far
                letterGuessed += input;

                //check if the user has guessed all the letters
                if (Winner(letterGuessed, wordToGuess))
                {
                    Console.Clear();
                    DisplayWelcome();

                    Console.WriteLine("Letters guessed: " + CheckForTheLetter(letterGuessed, wordToGuess));
                    //display victory
                    YouWin(userName);
                    playing = false;
                }
                
                    //if the guess is wrong
                else if(!wordToGuess.Contains(input.ToUpper()))
                {
                    lives--;
                    //call the function to change the color of lives left
                    colorChanged = ChangeColor(colors, ref colorIndex);

                    //if you have no more lives stop the game
                    if (lives == 0)
                    {
                        Console.Clear();
                        DisplayWelcome();

                        Console.WriteLine("Letters guessed: " + CheckForTheLetter(letterGuessed, wordToGuess));
                        Console.ForegroundColor = colorChanged;
                        Console.WriteLine("Guesses left: {0}\n", lives);
                        Console.ResetColor();

                        //display losing game
                        YouLose();
                        playing = false;
                    }       
                }
            }
            Console.ReadKey();
        }

        /// <summary>
        /// This function pick a random word from a list
        /// </summary>
        /// <returns>the string picked</returns>
        public static string RandomWord(List<string> listOfWords)
        {  
            Random ngr = new Random();
           
            //choose a random word from the list and return the string
            return listOfWords[ngr.Next(0, listOfWords.Count)];
        }

        /// <summary>
        /// This function shows the name of the game
        /// </summary>
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
            Console.WriteLine();
            Console.ResetColor();

        }

        /// <summary>
        /// Just shows a funny preview text
        /// </summary>
        static void InsertCoin()
        {
            DisplayWelcome();

            Console.Write("PLEASE INSERT COIN");
            for (int i = 0; i < 4; i++)
            {
                System.Threading.Thread.Sleep(1000);
                Console.Write(".");
            }
            Console.WriteLine("\n\nOK THIS TIME IS FOR FREE");
            System.Threading.Thread.Sleep(2000);
        }



        /// <summary>
        /// Shows brief rules on how to play
        /// </summary>
        static void DisplayRules()
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("GUESS THE FOLLOWING WORD");
            Console.ResetColor();
        }

        /// <summary>
        /// Check if the letter guessed is in the word
        /// </summary>
        /// <param name="letterToCheck">All the letter given in input by the user</param>
        /// <param name="wordToGuess">The string to guess</param>
        /// <returns>The string with the letter guessed unmasked</returns>
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

        /// <summary>
        /// Check if the user has guessed all the letters
        /// </summary>
        /// <param name="letterToCheck">Letters guessed so far</param>
        /// <param name="wordToGuess">Word to guess</param>
        /// <returns>True is he wins, false otherwise</returns>
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

        /// <summary>
        /// Pick a color from the list of the colors
        /// </summary>
        /// <param name="colors">List of available colors</param>
        /// <param name="colorIndex">Index of the list of colors</param>
        /// <returns>The color picked</returns>
        static ConsoleColor ChangeColor(List<string> colors, ref int colorIndex)
        {
            colorIndex = colorIndex  % colors.Count();

            //pick a color from the list of colors
            string color = colors[colorIndex];

            colorIndex++;

            //return the color as ConsoleColor type
            return (ConsoleColor)Enum.Parse(typeof(ConsoleColor), color);    
        }

        /// <summary>
        /// Display an animated clap of hands
        /// </summary>
        /// <param name="userName">Name of the user who is playing</param>
        static void YouWin(string userName)
        {
            for (int i = 0; i < 30; i++)
            {
                Console.Clear();
                DisplayWelcome();

                Console.ForegroundColor = ConsoleColor.Green;
                Console.Write(@"  
       !!!!  _      \\\\
       !   -'/   _  ||||
        \   /    \`-'''|
         \  |     \   /
         )  |      \  \
        /   |       \  \
                     \
       ");

            Console.WriteLine("\nCONGRATULATIONS " + userName.ToUpper());

            System.Threading.Thread.Sleep(200);
            Console.Clear();
            DisplayWelcome();

            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write(@"  
       !!!!\\\\
       !_  ||||
        \`-'''|
         \   /
         )\  \
        /  \  \
            \ 
       ");


            Console.WriteLine("\nCONGRATULATIONS " + userName.ToUpper());
            System.Threading.Thread.Sleep(200);
            }
        }


        /// <summary>
        /// Display a skull in case of lose
        /// </summary>
        static void YouLose()
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(@"    ############### 
    ##            *##                    
   #               **#                   
  #       %% %%    ***#                
 #       %%%%%%%   ****#              
#         %%%%%    *****#            
#   ###     %     ###***#             
#  # ####       #### #**#             
#  #     #     #     #**#             
#   #####  # #  #####***#             
#         #   #  *******#             
 ### #           **# ###               
     # - - - - - - #                     
      | | | | | | |                  "    );
        }
    }
}
