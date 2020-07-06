using System;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace WheelOfFortune
{
    public class Puzzle
    {
        private string word;
        List<char> wrongGuesses;
        List<char> correctGuesses;
        int numUniqueChars; 
        public Puzzle()
        {
            word = new PuzzleLibrary().GetNextPuzzle().ToLower();
            wrongGuesses = new List<char>();
            correctGuesses = new List<char>();
            numUniqueChars = getNumUniqueChars(this.word);
        }

        public string GetWord()
        {
            return word;
        }

    //checkGuessedLetter takes in a char (letter) from the method inside Board that handles validation. checkGuessedLetter has a flag to track
    //if a match is found (this ensures catching multiple letters). The method loops through each letter inside word and looks for a match to the 
    //char that was passed in. If a match is found, change the flag.

    //If the guessed letter is found to be a match, we'll need to change the display in the appropriate place on the display. This method hasn't been written yet.

    //If the guessed letter isn't a match, call the handleWrongGuess method which stores the wrong guess and communicates to the user.
   
        public void CheckGuessedLetter(char letter, Player player, Reward reward)
        {
            bool isMatch = false;
            foreach(char l in word)
            {
                if (l.Equals(letter) && !correctGuesses.Contains(l))
                {
                    isMatch = true;
                    correctGuesses.Add(letter);
                }
            }

            if (isMatch)
            {

                //player.showScoreboard();
                if (correctGuesses.Count == numUniqueChars)
                {
                    Board.DisplayMessage(Board.YOU_WON_MSG + 
                       "\nTHE WORD IS: " + word + "\n" + Board.PLAY_AGAIN_OR_CONTINUE_MSG);
                    //Board.DisplayMessage(Board.YOU_WON_MSG +
                    //"\nTHE WORD IS: " + word);
                    //Console.WriteLine("We got bugs, yo");

                    //Program.PUZZLE_IS_SOLVED = true;

                }
                else
                {
                    //call the change display method so that the "-" is replaced by the correct letter.
                    player.UpdateRewards(reward);
                    Board.DisplayMessage("Great Guess!  Here is your new updated word\n" +
                            GetWordToBeDisplayed()) ;
                }
            } else
            {
                HandleWrongGuess(letter);
            }
        }

        //handleWrongGuess method stores the wrong guess and communicates to the user. I think the Console should go to the Board instead.

        void HandleWrongGuess(char letter)
        {
            wrongGuesses.Add(letter);
            Board.DisplayMessage(Board.WRONG_GUESS_MSG + 
                "\n" + Environment.NewLine + GetWordToBeDisplayed());
        }


        //isSolved is triggered by the valdiation method inside Board when a user types in an entire word. isSolved compares the user guess to the word
        //to see if they are a match. 

        //If a match is found, we'll need to change the display to be the word instead of "-".

        //If the guess isn't the entire word, we should trigger a method in the Board class to tell the user they lost the game becuase their guess was incorrect.
        public bool IsSolved(string guess)
        {
            if (word.Equals(guess))
            {         
                return true;
            } else
            {
                return false;
            }
        }


        /* getWordToBeDisplayed -  takes input word and returns a dashed version of the word.  All correctly guessed letters 
         * are preserved in the word.  The letters that have not been guessed correctly yet are replaced with a dash
         */
        public string GetWordToBeDisplayed()
        {
            StringBuilder sb = new StringBuilder(word.Length);

            for (int i = 0; i < word.Length; i++) //i = 0, out = "-",   i = 1, out = "-O", 
            {
                char currentChar = word[i];
                if (correctGuesses.Contains(currentChar))
                { ///puzzle = "LOovv"  current guesses: O,  need to return: -Oo-
                    sb.Append(currentChar);

                }
                else
                {
                    sb.Append('-');
                }
                
            }
            return sb.ToString();

        }

        private int getNumUniqueChars(string s)
        {
            int count = 0;
            List<char> charsInString = new List<char>();
            for (int i = 0; i < s.Length; i++)
            {
                char currentChar = s[i];
                if (!charsInString.Contains(currentChar))
                {
                    count++;
                }
            }

            return count;
        }


    }
}

//Some psudeo code from our mob programming on 3/13:

// possible input/paths - bad input||null, char, string
// bad input - msg, stay in loop
// char - if alpha - correct 
//                         (is phrase complete? yes, you win. game over; no, stay in loop), 
//                     wrong
//                         loop; 
//         non alpha - wrong
//                         loop;
// string - right (You win, game over.), 
//           wrong (stay in loop)


/* If input is 1 char length, send it to a method that processes characters.  If input is longer, send it
* to method that processes strings and looks for a match with the puzzle */
