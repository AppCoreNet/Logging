// Licensed under the MIT License.
// Copyright (c) 2018 the AppCore .NET project.

using System;
using AppCore.Diagnostics;
using Serilog;
using Serilog.Core;

namespace AppCore.Logging.Serilog
{
    /// <summary>
    /// Provides implementation of <see cref="ILoggerProvider"/> which creates <see cref="ILogger"/> instances
    /// which use Serilog.
    /// </summary>
    public class SerilogLoggerProvider : ILoggerProvider
    {
        private readonly Logger _logger;

        /// <summary>
        /// Initializes a new instance of the <see cref="SerilogLoggerProvider"/> class.
        /// </summary>
        /// <param name="logger">The <see cref="Logger"/> used.</param>
        /// <exception cref="ArgumentNullException">Argument <paramref name="logger"/> is <c>null</c>.</exception>
        public SerilogLoggerProvider(Logger logger)
        {
            Ensure.Arg.NotNull(logger, nameof(logger));
            _logger = logger;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="SerilogLoggerProvider"/> class.
        /// </summary>
        /// <param name="configuration">The <see cref="LoggerConfiguration"/> used.</param>
        /// <exception cref="ArgumentNullException">Argument <paramref name="configuration"/> is <c>null</c>.</exception>
        public SerilogLoggerProvider(LoggerConfiguration configuration)
            : this(configuration?.CreateLogger())
        {
        }

        /// <inheritdoc />
        public ILogger CreateLogger(string category)
        {
            return new SerilogLogger(_logger.ForContext(Constants.SourceContextPropertyName, category));
        }

        /// <inheritdoc />
        public void Dispose()
        {
            _logger.Dispose();
        }
    }
}
