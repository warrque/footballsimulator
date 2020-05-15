using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Autofac;

namespace FootballSimulator.Helpers
{
    public static class AutofacHelper
    {
        public static void RegisterAssembly(Assembly assembly, ContainerBuilder builder)
        {
            //helps with register of common types
            var extensions = new List<string>
            {
                "Controller",
                "Factory",
                "Handler",
                "Service",
                "Validator",
                "View"
            };

            builder.RegisterAssemblyTypes(assembly)
                .Where(type => extensions.Any(extension => type.Name.EndsWith(extension)))
                .AsImplementedInterfaces()
                .SingleInstance();
        }
    }
}
