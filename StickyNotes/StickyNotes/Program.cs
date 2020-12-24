using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;
using System.Diagnostics;
using StickyNotes;
using Autofac;

namespace NotesCommandLine
{
    class Program
    {
       
        static void Main(string[] args)
        {

            var container = ContainerConfig.Configure();
            using (var scope = container.BeginLifetimeScope())
            {
                var app = scope.Resolve<IStart>();
                app.ReadCommand();
            }
        }

    }
}
