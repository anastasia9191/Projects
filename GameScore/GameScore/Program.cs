
using System;

namespace GameScore
{
    class Program
    {
        static void Main(string[] args)
        {
            TennisGame game = new TennisGame(new Player("player2"), new Player("player2"));
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
