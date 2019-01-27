// Licensed under the MIT License.
// Copyright (c) 2018 the AppCore .NET project.

using AppCore.DependencyInjection.Facilities;
using AppCore.Logging;

// ReSharper disable once CheckNamespace
namespace AppCore.DependencyInjection
{
    /// <summary>
    /// Represents the default implementation of the <see cref="ILoggingFacility"/>.
    /// </summary>
    public class LoggingFacility : Facility, ILoggingFacility
    {
        /// <inheritdoc />
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
