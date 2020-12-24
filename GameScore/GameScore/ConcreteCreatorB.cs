using System;
using System.Collections.Generic;
using System.Text;

namespace GameScore
{
    class ConcreteCreatorB : Creator
    {
        public override Player FactoryMethod()
        {
            return new ConcretePlayer2("palyer2");
        }
    }
}
