using System;
using System.Collections.Generic;
using System.Text;
using Autofac;

namespace FootballSimulator.Autofac
{
    public static class IocContainer
    {
        public static IContainer RegisterAutofac()
        {
            //registers the module with Autofac
            var builder = new ContainerBuilder();
            builder.RegisterModule<AutofacModule>();
            return builder.Build();
        }
    }
}
