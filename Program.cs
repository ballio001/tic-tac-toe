using System;

namespace TicTacToe
{
    class Program
    {
        private static string[] Pos = { "0", "1", "2", "3", "4", "5", "6", "7", "8" };

        private static void DrawTicTacToe()
        {
            Console.WriteLine("      {0} |   {1} |   {2}    ", Pos[0], Pos[1], Pos[2]);
            Console.WriteLine("     ---------------");
            Console.WriteLine("      {0} |   {1} |   {2}    ", Pos[3], Pos[4], Pos[5]);
            Console.WriteLine("     ---------------");
            Console.WriteLine("      {0} |   {1} |   {2}    ", Pos[6], Pos[7], Pos[8]);
        }

        private static string[] EnterPlayers()
        {
            string[] players = EnterPlayers();
            string player1 = players[0];
            string player2 = players[1];
            Console.WriteLine("Welcome to Tic Tac Toe!");
            Console.WriteLine("This is a 2 player game.");
            Console.WriteLine("Please Enter your name to be displayed as Player 1: ");
            //var player1 = Console.ReadLine();
            Console.WriteLine("What is the name of player 2?");
            //var player2 = Console.ReadLine();
            Console.WriteLine("{0} will be using O's, and {1} is X.", player1[0], player2[1]);
            Console.WriteLine("");

            //random who begins first
            Random rnd = new Random();
            int first = rnd.Next(1, 2);
            if (first == 1)
            {
                Console.WriteLine("{0} goes first.", player1[0]);
            }
            else
            {
                Console.WriteLine("{0} goes first.", player2[0]);
            }

            Console.WriteLine("press enter to continue...");
            Console.ReadLine();
            Console.Clear();

            return new[] { player1, player2 };
        }

        //check lines & wins
        private static bool IsLine(int index0, int index1, int index2, string Symbol)
        {
            return Pos[index0] == Symbol && Pos[index1] == Symbol && Pos[index2] == Symbol;
        }

        static bool Checkwin()
        {
            //O
            if (IsLine(0, 1, 2, "O") || IsLine(3, 4, 5, "O") || IsLine(6, 7, 8, "O")//vertical
                || IsLine(0, 4, 8, "O") || IsLine(6, 4, 2, "O")//diagonal
                || IsLine(0, 3, 6, "O") || IsLine(1, 4, 7, "O") || IsLine(6, 4, 2, "O")//horizontal
                )
            {
                return true;
            }

            //X
            if (IsLine(0, 1, 2, "X") || IsLine(3, 4, 5, "X") || IsLine(6, 7, 8, "X")//vertical
                || IsLine(0, 4, 8, "X") || IsLine(6, 4, 2, "X")//diagonal
                || IsLine(0, 3, 6, "X") || IsLine(1, 4, 7, "X") || IsLine(6, 4, 2, "X")//horizontal
                )
            {
                return true;
            }
            return false;
        }

        static void Main(string[] args)
        {
            Console.WriteLine("");
            DrawTicTacToe();
        }
    }
}

