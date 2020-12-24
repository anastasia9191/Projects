

using GameScore;
using System.Collections.Generic;

namespace GameScore
{
    class TennisGame : IGame
    {
        private int m_score1 = 0;
        private int m_score2 = 0;
        
       
        public void WonPoint(string playerName)
        {
            if (playerName == "player1")
                m_score1 += 1;
            else
                m_score2 += 1;
        }

        public string GetScore()
        {
            string score = "";
            var tempScore = 0;
            if (IfEqual(m_score1, m_score2))
            {
                score = ScoreEqual(m_score1);
            }
            else if (CommonScore(m_score1, m_score2))
            {
                score = MinusResult(m_score1, m_score2);


            }
            else
            {
                for (var i = 1; i < 3; i++)
                {
                    if (i == 1) tempScore = m_score1;
                    else { score += "-"; tempScore = m_score2; }
                    switch (tempScore)
                    {
                        case 0:
                            score += "Love";
                            break;
                        case 1:
                            score += "Fifteen";
                            break;
                        case 2:
                            score += "Thirty";
                            break;
                        case 3:
                            score += "Forty";
                            break;
                    }
                }
            }
            return score;
        }
        string ScoreEqual(int score1)
        {
            var score2 = "";
            switch (score1)
            {
                case 0:
                    score2 = "Love-All";
                    break;
                case 1:
                    score2 = "Fifteen-All";
                    break;
                case 2:
                    score2 = "Thirty-All";
                    break;
                default:
                    score2 = "Deuce";
                    break;
            }
            return score2;
        }
        string MinusResult(int score1, int score2)
        {
            var minusResult = score1 - score2;
            var score = "";
            if (minusResult == 1) score = "Advantage player1";
            else if (minusResult == -1) score = "Advantage player2";
            else if (minusResult >= 2) score = "Win for player1";
            else score = "Win for player2";
            return score;
        }
        bool IfEqual(int score1, int score2)
        {
            if (score1 == score2)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        bool CommonScore(int score1, int score2)
        {
            if (score1 >= 4 || score2 >= 4)
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
