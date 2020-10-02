
using System;

namespace GameScore
{
    class Program
    {
        static void Main(string[] args)
        {
            var player = new Player("player1", "player2");
            var game = new TennisGame();
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
