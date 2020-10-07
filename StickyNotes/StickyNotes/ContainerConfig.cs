using Autofac;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace StickyNotes
{
    public static class ContainerConfig
    {
        public static IContainer Configure()
        {
            var builder = new ContainerBuilder();
            builder.RegisterType<Start>().As<IStart>().InstancePerLifetimeScope().PropertiesAutowired(PropertyWiringOptions.AllowCircularDependencies);
            builder.RegisterType<FunctionalityOfTheNotes>().InstancePerLifetimeScope().As<IFunctionalytyOfTheNotes>().PropertiesAutowired(PropertyWiringOptions.AllowCircularDependencies);
            builder.RegisterType<FileWork>().As<IFileWork>().InstancePerLifetimeScope().PropertiesAutowired(PropertyWiringOptions.AllowCircularDependencies);
            builder.RegisterType<Application>().As<IApplication>().InstancePerLifetimeScope().PropertiesAutowired(PropertyWiringOptions.AllowCircularDependencies);
            return builder.Build();
        }
    }
}
