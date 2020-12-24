using System;
using System.Collections.Generic;
using System.Text;

namespace GameScore
{
    public abstract class Player
    {
        private string playerName;

        public Player(string playerName)
        {
            this.playerName = playerName;

        }
    }
 
}
