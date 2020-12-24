using AnotherNotesApp.Core;
using AnotherNotesApp.Data;
using Autofac;
using System;

namespace AnotherNotesApp
{
    class Program
    {
        static void Main(string[] args)
        {
            var container = ContainerConfig.Configure();
            using (var scope = container.BeginLifetimeScope())
            {
                var app = scope.Resolve<IRunApp>();
                app.Start();
            }
        }
    }
}
