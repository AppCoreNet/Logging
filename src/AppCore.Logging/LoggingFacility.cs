// Licensed under the MIT License.
// Copyright (c) 2018 the AppCore .NET project.

using AppCore.DependencyInjection.Builder;
using AppCore.Logging;

// ReSharper disable once CheckNamespace
namespace AppCore.DependencyInjection
{
    public class LoggingFacility : Facility, ILoggingFacility
    {
        public LoggingFacility()
        {
            Register<ILoggerFactory>()
                .Add<LoggerFactory>()
                .PerContainer()
                .IfNoneRegistered();

            Register(typeof(ILogger<>))
                .Add(typeof(Logger<>))
                .IfNoneRegistered();
        }
    }
}
