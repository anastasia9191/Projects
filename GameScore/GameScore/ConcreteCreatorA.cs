using System;
using System.Collections.Generic;
using System.Text;

namespace GameScore
{
    class ConcreteCreatorA : Creator
    {
        public override Player FactoryMethod()
        {
            return new ConcretePlayer1("player1");
        }
    }
}
