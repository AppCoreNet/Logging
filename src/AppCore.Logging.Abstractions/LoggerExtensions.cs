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

        public static void Log(
            this ILogger logger,
            LogLevel level,
            LogEventId id,
            Exception exception,
            string format,
            params ILogProperty[] properties)
        {
            Ensure.Arg.NotNull(logger, nameof(logger));

            if (logger.IsEnabled(level))
            {
                LogMessageTemplate template = LogMessageTemplateCache.Get(format);
                Log(logger, level, id, exception, template, properties);
            }
        }

        public static void Log(this ILogger logger, LogLevel level, LogEventId id, Exception exception, string format, params object[] args)
        {
            Ensure.Arg.NotNull(logger, nameof(logger));

            if (logger.IsEnabled(level))
            {
                LogMessageTemplate template = LogMessageTemplateCache.Get(format);
                if (template.VariableNames.Count != args.Length)
                {
                    throw new ArgumentException(
                        "Number of arguments does not match the number of format variables.",
                        nameof(args));
                }

                IEnumerable<ILogProperty> properties = args == null || args.Length == 0
                    ? (IEnumerable<ILogProperty>) null
                    : new LogMessageProperties(template, args);

                Log(logger, level, id, exception, template, properties);
            }
        }


        public static void LogTrace(this ILogger logger, LogEventId id, Exception exception, string format, params ILogProperty[] properties)
        {
            Log(logger, LogLevel.Trace, id, exception, format, properties);
        }

        public static void LogTrace(this ILogger logger, LogEventId id, Exception exception, string format, params object[] args)
        {
            Log(logger, LogLevel.Trace, id, exception, format, args);
        }

        public static void LogTrace(this ILogger logger, LogEventId id, string format, params ILogProperty[] properties)
        {
            Log(logger, LogLevel.Trace, id, null, format, properties);
        }

        public static void LogTrace(this ILogger logger, LogEventId id, string format, params object[] args)
        {
            Log(logger, LogLevel.Trace, id, null, format, args);
        }

        public static void LogDebug(this ILogger logger, LogEventId id, Exception exception, string format, params ILogProperty[] properties)
        {
            Log(logger, LogLevel.Debug, id, exception, format, properties);
        }

        public static void LogDebug(this ILogger logger, LogEventId id, Exception exception, string format, params object[] args)
        {
            Log(logger, LogLevel.Debug, id, exception, format, args);
        }

        public static void LogDebug(this ILogger logger, LogEventId id, string format, params ILogProperty[] properties)
        {
            Log(logger, LogLevel.Debug, id, null, format, properties);
        }

        public static void LogDebug(this ILogger logger, LogEventId id, string format, params object[] args)
        {
            Log(logger, LogLevel.Debug, id, null, format, args);
        }

        public static void LogInfo(this ILogger logger, LogEventId id, Exception exception, string format, params ILogProperty[] properties)
        {
            Log(logger, LogLevel.Info, id, exception, format, properties);
        }

        public static void LogInfo(this ILogger logger, LogEventId id, Exception exception, string format, params object[] args)
        {
            Log(logger, LogLevel.Info, id, exception, format, args);
        }

        public static void LogInfo(this ILogger logger, LogEventId id, string format, params ILogProperty[] properties)
        {
            Log(logger, LogLevel.Info, id, null, format, properties);
        }

        public static void LogInfo(this ILogger logger, LogEventId id, string format, params object[] args)
        {
            Log(logger, LogLevel.Info, id, null, format, args);
        }

        public static void LogWarning(this ILogger logger, LogEventId id, Exception exception, string format, params ILogProperty[] properties)
        {
            Log(logger, LogLevel.Warning, id, exception, format, properties);
        }

        public static void LogWarning(this ILogger logger, LogEventId id, Exception exception, string format, params object[] args)
        {
            Log(logger, LogLevel.Warning, id, exception, format, args);
        }

        public static void LogWarning(this ILogger logger, LogEventId id, string format, params ILogProperty[] properties)
        {
            Log(logger, LogLevel.Warning, id, null, format, properties);
        }

        public static void LogWarning(this ILogger logger, LogEventId id, string format, params object[] args)
        {
            Log(logger, LogLevel.Warning, id, null, format, args);
        }

        public static void LogError(this ILogger logger, LogEventId id, Exception exception, string format, params ILogProperty[] properties)
        {
            Log(logger, LogLevel.Error, id, exception, format, properties);
        }

        public static void LogError(this ILogger logger, LogEventId id, Exception exception, string format, params object[] args)
        {
            Log(logger, LogLevel.Error, id, exception, format, args);
        }

        public static void LogError(this ILogger logger, LogEventId id, string format, params ILogProperty[] properties)
        {
            Log(logger, LogLevel.Error, id, null, format, properties);
        }

        public static void LogError(this ILogger logger, LogEventId id, string format, params object[] args)
        {
            Log(logger, LogLevel.Error, id, null, format, args);
        }

        public static void LogCritical(this ILogger logger, LogEventId id, Exception exception, string format, params ILogProperty[] properties)
        {
            Log(logger, LogLevel.Critical, id, exception, format, properties);
        }

        public static void LogCritical(this ILogger logger, LogEventId id, Exception exception, string format, params object[] args)
        {
            Log(logger, LogLevel.Critical, id, exception, format, args);
        }

        public static void LogCritical(this ILogger logger, LogEventId id, string format, params ILogProperty[] properties)
        {
            Log(logger, LogLevel.Critical, id, null, format, properties);
        }

        public static void LogCritical(this ILogger logger, LogEventId id, string format, params object[] args)
        {
            Log(logger, LogLevel.Critical, id, null, format, args);
        }
    }
}
