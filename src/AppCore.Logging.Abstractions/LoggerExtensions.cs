// Licensed under the MIT License.
// Copyright (c) 2018 the AppCore .NET project.

using System;
using System.Collections.Generic;
using AppCore.Diagnostics;

namespace AppCore.Logging
{
    /// <summary>
    /// Provides extension methods for <see cref="ILogger"/>.
    /// </summary>
    public static class LoggerExtensions
    {
        internal static LogMessageTemplateCache LogMessageTemplateCache { get; set; } =
            LogMessageTemplateCache.Instance;

        internal static Func<DateTimeOffset> GetTimestamp { get; set; } =
            () => TimestampProvider.Instance.GetTimestamp();

        internal static void Log(
            this ILogger logger,
            LogLevel level,
            LogEventId id,
            Exception exception,
            LogMessageTemplate messageTemplate,
            IEnumerable<ILogProperty> properties)
        {
            logger.Log(
                new LogEvent(
                    GetTimestamp(),
                    level,
                    id,
                    messageTemplate,
                    properties,
                    exception));
        }

        /// <summary>
        /// Logs a message and/or exception with the specified <see cref="LogLevel"/>, <see cref="LogEventId"/>
        /// and properties.
        /// </summary>
        /// <param name="logger">The <see cref="ILogger"/>.</param>
        /// <param name="level">The <see cref="LogLevel"/>.</param>
        /// <param name="id">The unique identifier of the log event.</param>
        /// <param name="exception">The <see cref="Exception"/> that occured, may be <c>null</c>.</param>
        /// <param name="format">The format of the log message.</param>
        /// <param name="args">The format arguments used to format the message.</param>
        public static void Log(
            this ILogger logger,
            LogLevel level,
            LogEventId id,
            Exception exception,
            string format,
            params object[] args)
        {
            Ensure.Arg.NotNull(logger, nameof(logger));

            if (logger.IsEnabled(level))
            {
                LogMessageTemplate template = LogMessageTemplateCache.Get(format);
                if (template.VariableNames.Count != args?.Length)
                {
                    throw new ArgumentException(
                        "Number of arguments does not match the number of format variables.",
                        nameof(args));
                }

                IEnumerable<ILogProperty> properties = args?.Length == 0
                    ? LogMessageProperties.Empty
                    : new LogMessageProperties(template, args);

                Log(logger, level, id, exception, template, properties);
            }
        }

        /// <summary>
        /// Logs a <see cref="LogLevel.Trace"/> message and exception with the specified <see cref="LogEventId"/>
        /// and properties.
        /// </summary>
        /// <param name="logger">The <see cref="ILogger"/>.</param>
        /// <param name="id">The unique identifier of the log event.</param>
        /// <param name="exception">The <see cref="Exception"/> that occured, may be <c>null</c>.</param>
        /// <param name="format">The format of the log message.</param>
        /// <param name="args">The format arguments used to format the message.</param>
        public static void LogTrace(
            this ILogger logger,
            LogEventId id,
            Exception exception,
            string format,
            params object[] args)
        {
            Log(logger, LogLevel.Trace, id, exception, format, args);
        }

        /// <summary>
        /// Logs a <see cref="LogLevel.Trace"/> message with the specified <see cref="LogEventId"/> and properties.
        /// </summary>
        /// <param name="logger">The <see cref="ILogger"/>.</param>
        /// <param name="id">The unique identifier of the log event.</param>
        /// <param name="format">The format of the log message.</param>
        /// <param name="args">The format arguments used to format the message.</param>
        public static void LogTrace(this ILogger logger, LogEventId id, string format, params object[] args)
        {
            Log(logger, LogLevel.Trace, id, null, format, args);
        }

        /// <summary>
        /// Logs a <see cref="LogLevel.Debug"/> message and exception with the specified <see cref="LogEventId"/>
        /// and properties.
        /// </summary>
        /// <param name="logger">The <see cref="ILogger"/>.</param>
        /// <param name="id">The unique identifier of the log event.</param>
        /// <param name="exception">The <see cref="Exception"/> that occured, may be <c>null</c>.</param>
        /// <param name="format">The format of the log message.</param>
        /// <param name="args">The format arguments used to format the message.</param>
        public static void LogDebug(
            this ILogger logger,
            LogEventId id,
            Exception exception,
            string format,
            params object[] args)
        {
            Log(logger, LogLevel.Debug, id, exception, format, args);
        }

        /// <summary>
        /// Logs a <see cref="LogLevel.Debug"/> message with the specified <see cref="LogEventId"/> and properties.
        /// </summary>
        /// <param name="logger">The <see cref="ILogger"/>.</param>
        /// <param name="id">The unique identifier of the log event.</param>
        /// <param name="format">The format of the log message.</param>
        /// <param name="args">The format arguments used to format the message.</param>
        public static void LogDebug(this ILogger logger, LogEventId id, string format, params object[] args)
        {
            Log(logger, LogLevel.Debug, id, null, format, args);
        }

        /// <summary>
        /// Logs a <see cref="LogLevel.Info"/> message and exception with the specified <see cref="LogEventId"/>
        /// and properties.
        /// </summary>
        /// <param name="logger">The <see cref="ILogger"/>.</param>
        /// <param name="id">The unique identifier of the log event.</param>
        /// <param name="exception">The <see cref="Exception"/> that occured, may be <c>null</c>.</param>
        /// <param name="format">The format of the log message.</param>
        /// <param name="args">The format arguments used to format the message.</param>
        public static void LogInfo(
            this ILogger logger,
            LogEventId id,
            Exception exception,
            string format,
            params object[] args)
        {
            Log(logger, LogLevel.Info, id, exception, format, args);
        }

        /// <summary>
        /// Logs a <see cref="LogLevel.Info"/> message with the specified <see cref="LogEventId"/> and properties.
        /// </summary>
        /// <param name="logger">The <see cref="ILogger"/>.</param>
        /// <param name="id">The unique identifier of the log event.</param>
        /// <param name="format">The format of the log message.</param>
        /// <param name="args">The format arguments used to format the message.</param>
        public static void LogInfo(this ILogger logger, LogEventId id, string format, params object[] args)
        {
            Log(logger, LogLevel.Info, id, null, format, args);
        }

        /// <summary>
        /// Logs a <see cref="LogLevel.Warning"/> message and exception with the specified <see cref="LogEventId"/>
        /// and properties.
        /// </summary>
        /// <param name="logger">The <see cref="ILogger"/>.</param>
        /// <param name="id">The unique identifier of the log event.</param>
        /// <param name="exception">The <see cref="Exception"/> that occured, may be <c>null</c>.</param>
        /// <param name="format">The format of the log message.</param>
        /// <param name="args">The format arguments used to format the message.</param>
        public static void LogWarning(
            this ILogger logger,
            LogEventId id,
            Exception exception,
            string format,
            params object[] args)
        {
            Log(logger, LogLevel.Warning, id, exception, format, args);
        }

        /// <summary>
        /// Logs a <see cref="LogLevel.Warning"/> message with the specified <see cref="LogEventId"/> and properties.
        /// </summary>
        /// <param name="logger">The <see cref="ILogger"/>.</param>
        /// <param name="id">The unique identifier of the log event.</param>
        /// <param name="format">The format of the log message.</param>
        /// <param name="args">The format arguments used to format the message.</param>
        public static void LogWarning(this ILogger logger, LogEventId id, string format, params object[] args)
        {
            Log(logger, LogLevel.Warning, id, null, format, args);
        }

        /// <summary>
        /// Logs a <see cref="LogLevel.Error"/> message and exception with the specified <see cref="LogEventId"/>
        /// and properties.
        /// </summary>
        /// <param name="logger">The <see cref="ILogger"/>.</param>
        /// <param name="id">The unique identifier of the log event.</param>
        /// <param name="exception">The <see cref="Exception"/> that occured, may be <c>null</c>.</param>
        /// <param name="format">The format of the log message.</param>
        /// <param name="args">The format arguments used to format the message.</param>
        public static void LogError(
            this ILogger logger,
            LogEventId id,
            Exception exception,
            string format,
            params object[] args)
        {
            Log(logger, LogLevel.Error, id, exception, format, args);
        }

        /// <summary>
        /// Logs a <see cref="LogLevel.Error"/> message with the specified <see cref="LogEventId"/> and properties.
        /// </summary>
        /// <param name="logger">The <see cref="ILogger"/>.</param>
        /// <param name="id">The unique identifier of the log event.</param>
        /// <param name="format">The format of the log message.</param>
        /// <param name="args">The format arguments used to format the message.</param>
        public static void LogError(this ILogger logger, LogEventId id, string format, params object[] args)
        {
            Log(logger, LogLevel.Error, id, null, format, args);
        }

        /// <summary>
        /// Logs a <see cref="LogLevel.Critical"/> message and exception with the specified <see cref="LogEventId"/>
        /// and properties.
        /// </summary>
        /// <param name="logger">The <see cref="ILogger"/>.</param>
        /// <param name="id">The unique identifier of the log event.</param>
        /// <param name="exception">The <see cref="Exception"/> that occured, may be <c>null</c>.</param>
        /// <param name="format">The format of the log message.</param>
        /// <param name="args">The format arguments used to format the message.</param>
        public static void LogCritical(
            this ILogger logger,
            LogEventId id,
            Exception exception,
            string format,
            params object[] args)
        {
            Log(logger, LogLevel.Critical, id, exception, format, args);
        }

        /// <summary>
        /// Logs a <see cref="LogLevel.Critical"/> message with the specified <see cref="LogEventId"/> and properties.
        /// </summary>
        /// <param name="logger">The <see cref="ILogger"/>.</param>
        /// <param name="id">The unique identifier of the log event.</param>
        /// <param name="format">The format of the log message.</param>
        /// <param name="args">The format arguments used to format the message.</param>
        public static void LogCritical(this ILogger logger, LogEventId id, string format, params object[] args)
        {
            Log(logger, LogLevel.Critical, id, null, format, args);
        }
    }
}
