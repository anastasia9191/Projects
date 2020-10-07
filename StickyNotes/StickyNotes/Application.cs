using System;
using System.Collections.Generic;
using System.Text;

namespace StickyNotes
{
    class Application : IApplication
    {
        IStart _start;
        public Application(IStart start)
        {
            _start = start;
        }

        public void Run()
        {

            _start.ReadCommand();
            Console.ReadLine();
        }

    }
}
