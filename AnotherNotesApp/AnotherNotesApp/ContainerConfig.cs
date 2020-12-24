using AnotherNotesApp.Core;
using Autofac;
using System;
using System.Collections.Generic;
using System.Text;

namespace AnotherNotesApp.Data
{
    public class ContainerConfig
    {
        public static IContainer Configure()
        {
            var builder = new ContainerBuilder();
            builder.RegisterType<JsonData>().As<IDataRepo>().InstancePerDependency();
            builder.RegisterType<RunApp>().As<IRunApp>().SingleInstance();
            return builder.Build();
        }
    }
}
