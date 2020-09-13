// Licensed under the MIT License.
// Copyright (c) 2018 the AppCore .NET project.

using System.Collections.Generic;
using Serilog.Events;

namespace AppCore.Logging.Serilog
{
    internal static class LogEventExtensions
    {
        public static LogEventLevel ToSerilogLogLevel(this LogLevel level)
        {
            return (LogEventLevel) level;
        }

        public static IEnumerable<LogEventProperty> GetSerilogProperties(this LogEvent @event, global::Serilog.ILogger logger)
        {
            IReadOnlyList<LogProperty> eventProperties = @event.Properties;
            var properties = new LogEventProperty[eventProperties.Count + 1];
            for (int i = 0; i < eventProperties.Count; i++)
            {
                logger.BindProperty(eventProperties[i].Name, eventProperties[i].Value, true, out LogEventProperty logEventProperty);
                properties[i] = logEventProperty;
            }

            properties[eventProperties.Count] = new LogEventProperty(
                SerilogPropertyNames.EventId,
                new ScalarValue(@event.Id));

            return properties;
        }
    }
}
