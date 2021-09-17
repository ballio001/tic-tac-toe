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
            Console.WriteLine("Welcome to Tic Tac Toe!");
            Console.WriteLine("This is a 2 player game.");
            Console.WriteLine("Please Enter your name to be displayed as Player 1: ");
            var player1 = Console.ReadLine();
            Console.WriteLine("What is the name of player 2?");
            var player2 = Console.ReadLine();
            Console.WriteLine("{0} will be using O's, and {1} is X.", player1[0], player2[1]);
            Console.WriteLine("");

            //random who begins first
            Random rnd = new Random();
            int first = rnd.Next(1, 2);
            if(first == 1)
            {
                Console.WriteLine("{0} goes first.", player1[0]);
            }
            else
            {
                Console.WriteLine("{0} goes first.", player2[0]);
            }
            Console.WriteLine("press enter to continue....");
            Console.ReadLine();
            Console.Clear();

            return new[] { player1, player2 };
        }

        static void Main(string[] args)
        {
            Console.WriteLine("");

            DrawTicTacToe();
        }
    }
}
