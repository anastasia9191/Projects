using System;
using System.Collections.Generic;
using System.Text;

namespace StickyNotes
{
    interface IStart
    {
        void ReadCommand();
        void CommandsAvailable();
    }
}
