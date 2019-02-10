// Licensed under the MIT License.
// Copyright (c) 2018 the AppCore .NET project.

using AppCore.DependencyInjection.Facilities;
using AppCore.Diagnostics;
using AppCore.Logging;
using AppCore.Logging.Serilog;
using Serilog;
using ILogger = Serilog.ILogger;

// ReSharper disable once CheckNamespace
namespace AppCore.DependencyInjection
{
    /// <summary>
    /// Provides Serilog based logging.
    /// </summary>
    public class SerilogLoggingFacilityExtension : FacilityExtension<ILoggingFacility>
    {
        private readonly ILogger _logger;

        /// <summary>
        /// Initializes a new instance of the <see cref="SerilogLoggingFacilityExtension"/> class.
        /// </summary>
        /// <remarks>Uses </remarks>
        public SerilogLoggingFacilityExtension()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="SerilogLoggingFacilityExtension"/> class.
        /// </summary>
        /// <param name="logger">The logger which is used.</param>
        public SerilogLoggingFacilityExtension(ILogger logger)
        {
            Ensure.Arg.NotNull(logger, nameof(logger));
            _logger = logger;
        }

        /// <inheritdoc />
        protected override void RegisterComponents(IComponentRegistry registry, ILoggingFacility facility)
        {
            if (_logger == null)
            {
                registry.Register<ILogger>()
                        .Add(c => Log.Logger)
                        .IfNotRegistered();
            }
            else
            {
                registry.Register<ILogger>()
                        .Add(_logger)
                        .IfNotRegistered();
            }

            registry.Register<ILoggerProvider>()
                    .Add<SerilogLoggerProvider>()
                    .PerContainer()
                    .IfNotRegistered();
        }
    }
}
