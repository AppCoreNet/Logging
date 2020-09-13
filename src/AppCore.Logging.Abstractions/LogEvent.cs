// Licensed under the MIT License.
// Copyright (c) 2018 the AppCore .NET project.

using System;
using System.Collections.Generic;
using System.Linq;

namespace AppCore.Logging
{
    /// <summary>
    /// Represents a log event.
    /// </summary>
    public sealed class LogEvent
    {
        /// <summary>
        /// Gets the timestamp of the event.
        /// </summary>
        public DateTimeOffset Timestamp { get; }

        /// <summary>
        /// Gets the log level of the event.
        /// </summary>
        public LogLevel Level { get; }

        /// <summary>
        /// Gets the unique identifier of the event.
        /// </summary>
        public LogEventId Id { get; }

        /// <summary>
        /// Gets the <see cref="LogMessageTemplate"/> used to render the event.
        /// </summary>
        public LogMessageTemplate MessageTemplate { get; }

        /// <summary>
        /// Gets the properties that are logged.
        /// </summary>
        public IReadOnlyList<LogProperty> Properties { get; }

        /// <summary>
        /// Gets the <see cref="System.Exception"/> that will be logged.
        /// </summary>
        /// <remarks>
        /// Might be <c>null</c> if no <see cref="System.Exception"/> occured.
        /// </remarks>
        public Exception Exception { get; }

        /// <summary>
        /// Initializes a new instance of the <see cref="LogEvent"/> struct.
        /// </summary>
        /// <param name="timestamp">The timestamp of the event.</param>
        /// <param name="level">The log level of the event</param>
        /// <param name="id">The unique identifier of the event</param>
        /// <param name="messageTemplate">The <see cref="LogMessageTemplate"/> used to render the event.</param>
        /// <param name="properties">The properties that are logged.</param>
        /// <param name="exception">The <see cref="System.Exception"/> that will be logged.</param>
        public LogEvent(
            DateTimeOffset timestamp,
            LogLevel level,
            LogEventId id,
            LogMessageTemplate messageTemplate,
            IReadOnlyList<LogProperty> properties = null,
            Exception exception = null
        )
        {
            Timestamp = timestamp;
            Level = level;
            Id = id;
            MessageTemplate = messageTemplate ?? LogMessageTemplate.Empty;
            Properties = properties ?? LogMessageProperties.Empty;
            Exception = exception;
        }
    }
}