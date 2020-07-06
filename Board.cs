using Microsoft.Win32.SafeHandles;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace WheelOfFortune
{
    public class Board
    {
        public const String NO_INPUT_DETECTED_MSG = "Please enter a letter or guess a word";
        public const String ENTER_LETTER_OR_WORD_MSG = "Please enter a letter or guess a word";
        public const String YOU_WON_MSG = "WOW!  AMAZING WORK!  YOU SOLVED THE PUZZLE";
        public const String WRONG_GUESS_MSG = "Sorry, your guess was incorrect.";
        public const String PLAY_AGAIN_OR_CONTINUE_MSG = "Press 1 to play again, press 2 to quit";
        public const String HERE_IS_YOUR_WORD_MSG = "Here is your word: ";


        Puzzle puzzle;
        public bool puzzleIsSolved;
        public int totalRounds;
        public int currentRound = 1;
        public Board(int rounds)
        {
            puzzle = new Puzzle();
            puzzleIsSolved = false;
            totalRounds = rounds;
             
        }

        public Puzzle GetPuzzle ()
        {
            return puzzle;
        }

       public void resetBoard()
        {
            puzzle = new Puzzle();
            puzzleIsSolved = false;
        }

        /// <summary>
        /// This method takes the input from the user which could be a string of any length. 
        /// If it is of length 1, then check if it is a valid character, i.e. a letter (and not a number or a special character)
        /// If it is longer than 1, check if it matches the puzzle
        /// Sends user a specific message depending on whether the input was valid or if it was a correct guess
        /// </summary>
        /// <param name="input">string input</param>
        /// <returns></returns>

        public void ValidateInput(string input, Player player, Reward reward)
        {
            if (input == null)
            {
                throw new NullReferenceException("Input string cannot be null");
            }
            string s = input.Trim();
            s = s.ToLower();

            if (s.Length == 0) {
                DisplayMessage(NO_INPUT_DETECTED_MSG);
            }
            else if (s.Length == 1)
            {
                char c = s[0];
                //or try to use method convert.toChar(input)
                if (Char.IsLetter(c))
                {
                    puzzle.CheckGuessedLetter(c, player, reward );
                }
                else
                {
                    DisplayMessage(WRONG_GUESS_MSG + 
                "\n" + HERE_IS_YOUR_WORD_MSG + puzzle.GetWordToBeDisplayed());
                }
            }
            else //s.length > 1
            {
                if (puzzle.IsSolved(s))
                {
                    //DisplayMessage(YOU_WON_MSG + "\n" + PLAY_AGAIN_OR_CONTINUE_MSG);
                    DisplayMessage(YOU_WON_MSG +
                       "\nTHE WORD IS: " + puzzle.GetWord());
                    puzzleIsSolved = true;
                }
                else
                {
                    DisplayMessage("Try again!\n" + HERE_IS_YOUR_WORD_MSG + puzzle.GetWordToBeDisplayed());
                }

            }
        }


        public static void DisplayMessage(string message)
        {
            Console.WriteLine(Environment.NewLine + message + Environment.NewLine);
        }




        public bool IsValidChar(char c)
        {
            if (Char.IsLetter(c))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
