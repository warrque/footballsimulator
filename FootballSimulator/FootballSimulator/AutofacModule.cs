using System;
using System.Collections.Generic;
using System.Text;
using Autofac;
using FootballSimulator.Helpers;
using FootballSimulator.Simulators;
using FootballSimulator.Simulators.Interfaces;

namespace FootballSimulator
{
    public class AutofacModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            AutofacHelper.RegisterAssembly(ThisAssembly, builder);

            builder.RegisterType<GameSimulator>().As<IGameSimulator>();
        }
    }
}
