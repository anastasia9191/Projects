using System;
using System.Collections.Generic;
using System.Text;

namespace GameScore
{
    interface IGame
    {
        public void WonPoint(string playerName);
        public string GetScore();
        public string ScoreEqual(int score1);
        public string MinusResult(int score1, int score2);
        public bool IfEqual(int score1, int score2);
        public bool CommonScore(int score1, int score2);
    }
}
