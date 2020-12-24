using System;
using System.Collections.Generic;
using System.Text;

namespace GameScore
{
    interface IGame
    {
         public void WonPoint(string playerName);
         public string GetScore();
        
    }
}
