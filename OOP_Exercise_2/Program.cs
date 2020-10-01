using System;

namespace OOP_Exercise_2
{
    class Program
    {
        static void Main(string[] args)
        {
            var game = new TennisGame("player1", "player2");
            string[] points = { "player1", "player1", "player2", "player2", "player1", "player1" };
            for (var i = 0; i < 6; i++)
            {
                game.WonPoint(points[i]);
                Console.WriteLine("Score: {0}", game.GetScore());
            }

            Console.ReadKey();
        }
    }
}
