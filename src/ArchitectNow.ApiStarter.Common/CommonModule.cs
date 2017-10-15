﻿using ArchitectNow.ApiStarter.Common.Models.Options;
using ArchitectNow.ApiStarter.Common.MongoDb;
using Autofac;
using Microsoft.Extensions.Configuration;

namespace ArchitectNow.ApiStarter.Common
{
    public class CommonModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterAssemblyTypes(ThisAssembly).AsImplementedInterfaces();

            builder.RegisterType<DataContext>().As<IDataContext>()
                .InstancePerLifetimeScope();

            builder.Register(ctx => ctx.Resolve<IConfiguration>().CreateOptions<MongoOptions>("mongo"))
                .AsSelf().SingleInstance();

            //TODO:  Compare this registration to what is in the AN.Framework project
            builder.Register(ctx => ctx.Resolve<IConfiguration>().CreateOptions<JwtIssuerOptions>("jwtIssuerOptions"))
                .AsSelf().SingleInstance();

            builder.Register(ctx => ctx.Resolve<IConfiguration>().CreateOptions<EnvironmentOptions>("environment"))
                .AsSelf().SingleInstance();
        }
    }
}