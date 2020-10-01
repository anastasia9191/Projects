using System.Runtime.Remoting.Metadata.W3cXsd2001;

namespace OOP_Exercise_2
{
    class TennisGame
    {
        private int m_score1 = 0;
        private int m_score2 = 0;
        private string player1Name;
        private string player2Name;

        public TennisGame(string player1Name, string player2Name)
        {
            this.player1Name = player1Name;
            this.player2Name = player2Name;
        }

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
            if (ifEqual(m_score1, m_score2);)
            {
               scoreEqual(m_score1);
            }
            else if (commonScore(m_score1, m_score2))
            {
                minusResult(m_score1, m_score2);
            }
            else
            {
                for (var i = 1; i < 3; i++)
                {
                    if (i == 1) tempScore = m_score1;
                    else { score += "-"; tempScore = m_score2; }
                    scoreEqual(tempScore);

                }

            }
            return score;
        }

            public string scoreEqual(int score)
            {
                switch (score)
                {
                    case 0:
                        score = "Love-All";
                        break;
                    case 1:
                        score = "Fifteen-All";
                        break;
                    case 2:
                        score = "Thirty-All";
                        break;
                    default:
                        score = "Deuce";
                        break;

                }
                return score;
            }
            public string minusResult (int score1, int score2)
            {
                var minusResult = score1 - score2;
                var score = "";
                if (minusResult == 1) score = "Advantage player1";
                else if (minusResult == -1) score = "Advantage player2";
                else if (minusResult >= 2) score = "Win for player1";
                else score = "Win for player2";
                return score;
            }
        public bool ifEqual(int score1, int score2)
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
        public bool commonScore(int score1, int score2)
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
