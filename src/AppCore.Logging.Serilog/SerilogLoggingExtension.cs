// Licensed under the MIT License.
// Copyright (c) 2018 the AppCore .NET project.

using AppCore.DependencyInjection.Facilities;
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
    public class SerilogLoggingExtension : FacilityExtension<ILoggingFacility>
    {
        /// <summary>
        /// Gets or sets the <see cref="ILogger"/> to use. If <c>null</c> the static <see cref="Log.Logger"/> is used.
        /// </summary>
        public ILogger Logger { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether to dispose the logger.
        /// </summary>
        public bool Dispose { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="SerilogLoggingExtension"/> class.
        /// </summary>
        /// <remarks>Uses </remarks>
        public SerilogLoggingExtension()
        {
        }

        /// <inheritdoc />
        protected override void RegisterComponents(IComponentRegistry registry, ILoggingFacility facility)
        {
            registry.Register<ILoggerProvider>()
                    .Add(c => new SerilogLoggerProvider(Logger, Dispose))
                    .PerContainer()
                    .IfNotRegistered();
        }
    }
}
