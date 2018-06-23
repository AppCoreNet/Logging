// Licensed under the MIT License.
// Copyright (c) 2018 the AppCore .NET project.

using AppCore.DependencyInjection.Builder;
using AppCore.Logging;

// ReSharper disable once CheckNamespace
namespace AppCore.DependencyInjection
{
    public class LoggingFacility : Facility, ILoggingFacility
    {
        protected override void RegisterComponents(IComponentRegistry registry)
        {
            registry.Register<ILoggerFactory>()
                    .Add<LoggerFactory>()
                    .PerContainer()
                    .IfNoneRegistered();

            registry.Register(typeof(ILogger<>))
                    .Add(typeof(Logger<>))
                    .IfNoneRegistered();
        }
    }
}
