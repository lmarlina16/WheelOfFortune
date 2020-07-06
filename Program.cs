using System;

namespace WheelOfFortune
{
    class Program
    {
        /*Moving the flag to the Board class so we aren't using a global variable*/

        //public static bool PUZZLE_IS_SOLVED = false;


        static void Main(string[] args)
        {
            Wheel wheel = new Wheel();

            /*Setting up the data for the game*/
            Console.WriteLine("How many players are self isolating today?");
            int numOfPlayers = int.Parse(Console.ReadLine());
            Console.WriteLine("How many rounds would you like to play?");
            int numOfRounds = int.Parse(Console.ReadLine());
            Player[] players = new Player[numOfPlayers];
            Console.Clear();

            /*Looping through the players array to store each player name*/

            for (int i = 0; i < players.Length; i++)
            {
                Console.WriteLine(Environment.NewLine + $"Patient {i + 1 }, please enter your name.");
                string name = Console.ReadLine();
                players[i] = new Player(name);
            }

                Board board = new Board(numOfRounds);


            while (true)
            {
                Console.Clear();
                Console.WriteLine("Welcome to WHEEL OF FORTUNE, QUARANTINE EDITION!");
                Puzzle puzzle = board.GetPuzzle();


                //Board.DisplayMessage("Here is your word to guess: " + board.GetPuzzle().GetWordToBeDisplayed() +
                //    "\n" + Board.ENTER_LETTER_OR_WORD_MSG);

                /*Changed while loop to change based on the puzzleIsSolved member rather than true so it's easier to exit the loop*/
                while (!board.puzzleIsSolved)
                {
                    foreach (Player player in players)
                    {
                        Console.WriteLine(Environment.NewLine + $"{player.Name}, it's your turn and it's round {board.currentRound}." + Environment.NewLine);
                        Reward reward = wheel.GetRandomReward();

                        Console.WriteLine($"Press enter to spin the wheel. (Be sure to wash your hands after)." + Environment.NewLine);
                        Console.ReadLine();
                        Console.Clear();
                        
                        Console.WriteLine($"Great spin! Looks like your potential COVID-19 reward is: " + reward.ToString()+ Environment.NewLine);
                        //Console.ReadLine();

                        if (reward.IsBankruptcy())
                        {
                            Console.Clear();
                            Console.WriteLine("BIG BUMMER!  YOUR REWARD IS BANKRUPTCY!  YOU LOST YOUR MONEY FOR THIS ROUND" + Environment.NewLine);
                            player.showScoreboard();
                            Console.ReadLine();
                            player.HandleBankruptOnScores();
                            continue;
                        }
                        Console.WriteLine($"That brings your score for this round to: {player.getScoreBoard()}");
                        Board.DisplayMessage("Here is your word to guess: " + Environment.NewLine + Environment.NewLine + puzzle.GetWordToBeDisplayed() +
                            Environment.NewLine + Environment.NewLine + Board.ENTER_LETTER_OR_WORD_MSG + Environment.NewLine);
                        var userInput = Console.ReadLine();
                        board.ValidateInput(userInput, player, reward);
                        if (board.puzzleIsSolved)
                        {
                            
                            break;
                        }
                    }
                }

                if (board.currentRound > board.totalRounds)
                {
                    Console.WriteLine("Hope you survived WHEEL OF FORTUNE CORONA VIRUS EDITION. Please play again even after social distancing is over.");
                    break;
                } else
                {
                    Console.Write("Press enter to start your next round!");
                    Console.ReadLine();
                    board.currentRound++;
                    board.resetBoard();
                }

                    //ConsoleKey key = Console.ReadKey().Key;
                    //Console.ReadKey().Key != ConsoleKey.E
                    //if (key == ConsoleKey.Q)
                    //{
                    //    break;
                    //}
                    //else
                    //{

                    //    Board.DisplayMessage("AWESOME!  LET'S PLAY AGAIN");
                    //    board.puzzleIsSolved = false;
                        

                }


            }


               
            }
        }
    

