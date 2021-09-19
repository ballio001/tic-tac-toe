using System;

namespace TicTacToe
{
    class Program
    {
        // 0 isn't used
        private static string[] playField = { "0", "1", "2", "3", "4", "5", "6", "7", "8", "9" };

        private static void DrawTicTacToe()
        {
            string format = "      {0} |   {1} |   {2}    ";
            string separator = "     ---------------";
            Console.WriteLine(format, playField[1], playField[2], playField[3]);
            Console.WriteLine(separator);
            Console.WriteLine(format, playField[4], playField[5], playField[6]);
            Console.WriteLine(separator);
            Console.WriteLine(format, playField[7], playField[8], playField[9]);
        }

        private static string[] EnterPlayers()
        {
            Console.WriteLine("Welcome to Tic Tac Toe!");
            Console.WriteLine("This is a 2 player game.");
            Console.WriteLine("Please Enter your name to be displayed as Player 1: ");
            var player1 = Console.ReadLine();
            Console.WriteLine("What would the name of player 2 be?");
            var player2 = Console.ReadLine();
            Console.WriteLine("{0} will be using O's, and {1} is X.", player1, player2);
            Console.WriteLine("");

            Console.ReadLine();
            Console.Clear();

            return new[] { player1, player2 };
        }

        //check lines & wins
        private static bool IsLine(int index0, int index1, int index2, string Symbol)
        {
            return playField[index0] == Symbol && playField[index1] == Symbol && playField[index2] == Symbol;
        }

        static bool CheckWin(bool win)
        {
            //O
            if (IsLine(1, 2, 3, "O") || IsLine(4, 5, 6, "O") || IsLine(7, 8, 9, "O")//vertical
                || IsLine(1, 5, 9, "O") || IsLine(7, 5, 3, "O")//diagonal
                || IsLine(1, 4, 7, "O") || IsLine(2, 5, 8, "O") || IsLine(7, 5, 3, "O")//horizontal
                )
            {
                win = true;
                return true;
            }
            //X
            if (IsLine(1, 2, 3, "X") || IsLine(4, 5, 6, "X") || IsLine(7, 8, 9, "X")//vertical
                || IsLine(1, 5, 9, "X") || IsLine(7, 5, 3, "X")//diagonal
                || IsLine(1, 4, 7, "X") || IsLine(2, 5, 8, "X") || IsLine(7, 5, 3, "X")//horizontal
                )
            {
                win = true;
                return true;
            }
            return false;
        }

        public static void ShowScore(string player1, int score1, string player2, int score2)
        {
            DrawTicTacToe();
            Console.WriteLine("Score: {0} - {1}     {2} - {3}", player1, score1, player2, score2);

        }

        //FIX: If nothing if filled in then it should ask again
        //Ask player for input from the minimum given and maximum given
        private static int PlayerInput(string playerInput, int min, int max)
        {
            bool correctInput = false;
            int input = 0;

            while (correctInput == false || correctInput == null)
            {
                Console.WriteLine(playerInput);
                input = int.Parse(Console.ReadLine());
                if (input >= min && input <= max)
                {
                    correctInput = true;
                }
            }
            return input;
        }

        //player take turns
        private static bool TakeTurns(string player1, string player2, int turn)
        {
            if (turn == 1)
            {
                Console.WriteLine("{0}'s ({1}) turn", player1, "O");
                var next = PlayerInput("Which position would you like to set.", 1, 9);
                if (OccupiedSpot(next, "X", "O") == false) return true;
            }
            else
            {
                Console.WriteLine("{0}'s ({1}) turn", player2, "X");
                var next = PlayerInput("Which position would you like to set.", 1, 9);
                if (OccupiedSpot(next, "O", "X") == false) return true;
            }
            return false;
        }

        //check if position is occupied
        private static bool OccupiedSpot(int move, string opponent, string currentPlayer)
        {
            if (playField[move] == opponent)
            {
                Console.WriteLine("You can't steal positions of the other player! ");
                Console.Write("Try again.");
                Console.ReadLine();
                Console.Clear();
                return true;
            }
            playField[move] = currentPlayer;
            return false;
        }
        //Ask player after the game is played.
        private static bool Replay()
        {
            Console.WriteLine("Would you like to continue the game?");
            Console.WriteLine("1. Play again.");
            Console.WriteLine("2. Quit.");
            //Logic
            var replay = PlayerInput("", 1, 2);
            Console.Clear();
            if (replay == 1)
            {
                return true;
            }
            Console.WriteLine("The game has ended.");
            Console.ReadLine();
            return false;
        }

        static void Main(string[] args)
        {
            string[] players = EnterPlayers();
            PlayingGame(players);
        }

        private static void PlayingGame(string[] players)
        {
            string player1 = players[0];
            string player2 = players[1];

            bool playing = true;
            int score1 = 0, score2 = 0;
            bool win = false;
            int turn = 1;

            //ERR: FIX Showing Scoreboard
            while (playing)
            {
                if (win == false)
                {
                    //check if somebody has won
                    //FIX: never goes to true
                    win = CheckWin(win);
                    //take turn
                    while (win == false)
                    {
                        //shows scores and draws field
                        ShowScore(player1, score1, player2, score2);
                        TakeTurns(player1, player2, turn);

                        //turns
                        if (turn == 1)
                        {
                            turn = 2;
                            Console.Clear();
                        }
                        else
                        {
                            turn = 1;
                            Console.Clear();
                        }
                    }
                    //reset game
                    Console.Clear();
                    DrawTicTacToe();

                    //draw
                    if (win == false)
                    {
                        Console.WriteLine("It's a draw.");
                        Console.WriteLine("Score: {0} - {1}     {2} - {3}", player1, score1, player2, score2);
                        playing = Replay();
                    }

                    //score calculation
                    if (win == true)
                    {
                        if (turn == 1)
                        {
                            score1++;
                            Console.WriteLine("{0} wins! ", player1);
                            playing = Replay();
                        }
                        else if (turn == 2)
                        {
                            score2++;
                            Console.WriteLine("{0} wins! ", player2);
                            playing = Replay();
                        }
                    }
                }
            }
        }
    }
}

