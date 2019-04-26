// Licensed under the MIT License.
// Copyright (c) 2018 the AppCore .NET project.

using AppCore.DependencyInjection;
using AppCore.DependencyInjection.Facilities;
using Serilog;
using Serilog_ILogger = global::Serilog.ILogger;

namespace AppCore.Logging.Serilog
{
    /// <summary>
    /// Provides Serilog based logging.
    /// </summary>
    public class SerilogLoggingExtension : FacilityExtension<ILoggingFacility>
    {
        /// <summary>
        /// Gets or sets the <see cref="Serilog_ILogger"/> to use. If <c>null</c> the static <see cref="Log.Logger"/> is used.
        /// </summary>
        public Serilog_ILogger Logger { get; set; }

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
