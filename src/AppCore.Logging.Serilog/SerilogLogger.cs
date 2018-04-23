using System;
using AppCore.Diagnostics;

namespace AppCore.Logging
{
    /// <summary>
    /// Provides implementation of <see cref="ILogger"/> which logs to Serilog.
    /// </summary>
    public class SerilogLogger : ILogger
    {
        private readonly Serilog.ILogger _logger;
        private readonly MessageTemplateCache _messageTemplateCache;

        /// <summary>
        /// Initializes a new instance of the <see cref="SerilogLogger"/> class.
        /// </summary>
        /// <param name="logger">The logger instance to use.</param>
        /// <exception cref="ArgumentNullException">Argument <paramref name="logger"/> is <c>null</c>.</exception>
        public SerilogLogger(Serilog.ILogger logger)
        {
            Ensure.Arg.NotNull(logger, nameof(logger));

            _logger = logger;
            _messageTemplateCache = new MessageTemplateCache();
        }

        /// <inheritdoc />
        public bool IsEnabled(LogLevel level)
        {
            return _logger.IsEnabled(level.ToSerilogLogLevel());
        }

        /// <inheritdoc />
        public void Log(LogEvent @event)
        {
            var serilogEvent = new Serilog.Events.LogEvent(
                @event.Timestamp,
                @event.Level.ToSerilogLogLevel(),
                @event.Exception,
                _messageTemplateCache.Get(@event.MessageTemplate),
                @event.GetSerilogProperties(_logger));

            _logger.Write(serilogEvent);
        }
    }
}