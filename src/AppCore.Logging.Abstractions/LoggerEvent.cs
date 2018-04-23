using System;
using System.Collections.Generic;
using System.Linq;
using AppCore.Diagnostics;

namespace AppCore.Logging
{
    /// <summary>
    /// Provides helper for building strongly typed logger delegates.
    /// </summary>
    public static class LoggerEvent
    {
        // ReSharper disable once ParameterOnlyUsedForPreconditionCheck.Local
        private static LogMessageTemplate CreateTemplate(string format, int expectedParameterCount)
        {
            Ensure.Arg.NotNull(format, nameof(format));

            var template = new LogMessageTemplate(format);
            if (template.VariableNames.Count < expectedParameterCount)
            {
                throw new ArgumentException("Number of format variables is less than the number of arguments.",
                    nameof(format));
            }

            return template;
        }

        private static IEnumerable<ILogProperty> Concat(
            IEnumerable<ILogProperty> properties,
            IEnumerable<ILogProperty> extraProperties)
        {
            return properties.Concat(extraProperties ?? Enumerable.Empty<ILogProperty>());
        }

        public static LoggerEventDelegate Define(LogLevel level, LogEventId id, string format)
        {
            LogMessageTemplate template = CreateTemplate(format, 0);
            return (logger, properties, exception) =>
            {
                if (logger.IsEnabled(level))
                {
                    logger.Log(level, id, exception, template, properties);
                }
            };
        }

        public static LoggerEventDelegate<T0> Define<T0>(LogLevel level, LogEventId id, string format)
        {
            LogMessageTemplate template = CreateTemplate(format, 1);
            return (logger, arg0, properties, exception) =>
            {
                if (logger.IsEnabled(level))
                {
                    logger.Log(
                        level,
                        id,
                        exception,
                        template,
                        Concat(new LogMessageProperties<T0>(template, arg0), properties));
                }
            };
        }

        public static LoggerEventDelegate<T0, T1> Define<T0, T1>(LogLevel level, LogEventId id, string format)
        {
            LogMessageTemplate template = CreateTemplate(format, 2);
            return (logger, arg0, arg1, properties, exception) =>
            {
                if (logger.IsEnabled(level))
                {
                    logger.Log(
                        level,
                        id,
                        exception,
                        template,
                        Concat(new LogMessageProperties<T0, T1>(template, arg0, arg1), properties));
                }
            };
        }

        public static LoggerEventDelegate<T0, T1, T2> Define<T0, T1, T2>(LogLevel level, LogEventId id, string format)
        {
            LogMessageTemplate template = CreateTemplate(format, 3);
            return (logger, arg0, arg1, arg2, properties, exception) =>
            {
                if (logger.IsEnabled(level))
                {
                    logger.Log(
                        level,
                        id,
                        exception,
                        template,
                        Concat(new LogMessageProperties<T0, T1, T2>(template, arg0, arg1, arg2), properties));
                }
            };
        }

        public static LoggerEventDelegate<T0, T1, T2, T3> Define<T0, T1, T2, T3>(LogLevel level, LogEventId id, string format)
        {
            LogMessageTemplate template = CreateTemplate(format, 4);
            return (logger, arg0, arg1, arg2, arg3, properties, exception) =>
            {
                if (logger.IsEnabled(level))
                {
                    logger.Log(
                        level,
                        id,
                        exception,
                        template,
                        Concat(
                            new LogMessageProperties<T0, T1, T2, T3>(template, arg0, arg1, arg2, arg3),
                            properties));
                }
            };
        }

        public static LoggerEventDelegate<T0, T1, T2, T3, T4> Define<T0, T1, T2, T3, T4>(LogLevel level, LogEventId id, string format)
        {
            LogMessageTemplate template = CreateTemplate(format, 5);
            return (logger, arg0, arg1, arg2, arg3, arg4, properties, exception) =>
            {
                if (logger.IsEnabled(level))
                {
                    logger.Log(
                        level,
                        id,
                        exception,
                        template,
                        Concat(
                            new LogMessageProperties<T0, T1, T2, T3, T4>(template, arg0, arg1, arg2, arg3, arg4),
                            properties));
                }
            };
        }
    }
}