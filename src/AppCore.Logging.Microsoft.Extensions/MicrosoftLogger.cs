// Licensed under the MIT License.
// Copyright (c) 2018 the AppCore .NET project.

using System;
using AppCore.Diagnostics;
using MicrosoftLogging = Microsoft.Extensions.Logging;

namespace AppCore.Logging.Microsoft.Extensions
{
    /// <summary>
    /// Provides implementation of <see cref="ILogger"/> which logs to Microsoft.Extensions.Logging.
    /// </summary>
    public class MicrosoftLogger : ILogger
    {
        private readonly MicrosoftLogging.ILogger _logger;

        /// <summary>
        /// Initializes a new instance of the <see cref="MicrosoftLogger"/> class.
        /// </summary>
        /// <param name="logger">The logger instance to use.</param>
        /// <exception cref="ArgumentNullException">Argument <paramref name="logger"/> is <c>null</c>.</exception>
        public MicrosoftLogger(MicrosoftLogging.ILogger logger)
        {
            Ensure.Arg.NotNull(logger, nameof(logger));
            _logger = logger;
        }

        /// <inheritdoc />
        public bool IsEnabled(LogLevel level)
        {
            return _logger.IsEnabled(level.ToMicrosoftLogLevel());
        }

        /// <inheritdoc />
        public void Log(LogEvent @event)
        {
            _logger.Log<object>(
                @event.Level.ToMicrosoftLogLevel(),
                @event.Id.ToMicrosoftEventId(),
                @event.GetKeyValueProperties(),
                @event.Exception,
                (s, e) => LogEventFormatter.Format(@event, e));
        }
    }
}
